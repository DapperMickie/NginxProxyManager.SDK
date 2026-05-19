using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NginxProxyManager.SDK.Tests;

internal sealed class RecordingHttpMessageHandler : HttpMessageHandler
{
    private readonly Queue<Func<HttpRequestMessage, HttpResponseMessage>> _responses;

    public List<HttpRequestMessage> Requests { get; } = new();
    public List<string?> RequestBodies { get; } = new();

    public RecordingHttpMessageHandler(params Func<HttpRequestMessage, HttpResponseMessage>[] responses)
    {
        _responses = new Queue<Func<HttpRequestMessage, HttpResponseMessage>>(responses);
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Requests.Add(request);
        RequestBodies.Add(request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken));

        if (_responses.Count == 0)
        {
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") };
        }

        return _responses.Dequeue()(request);
    }
}
