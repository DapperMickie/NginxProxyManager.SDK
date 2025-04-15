using NginxProxyManager.SDK.Models.Streams;
using NginxProxyManager.SDK.Resources.Interfaces;

namespace NginxProxyManager.SDK.Resources
{
    /// <summary>
    /// Builder for creating stream requests
    /// </summary>
    public class StreamBuilder : IStreamBuilder
    {
        private readonly NginxProxyManager.SDK.Models.Streams.Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamBuilder"/> class.
        /// </summary>
        public StreamBuilder()
        {
            _stream = new NginxProxyManager.SDK.Models.Streams.Stream
            {
                TcpForwarding = true,
                UdpForwarding = false,
                Enabled = true,
                Meta = new StreamMeta
                {
                    NginxOnline = true,
                    NginxError = null
                }
            };
        }

        /// <inheritdoc/>
        public IStreamBuilder WithOwnerUserId(int ownerUserId)
        {
            _stream.OwnerUserId = ownerUserId;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithIncomingPort(int incomingPort)
        {
            _stream.IncomingPort = incomingPort;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithForwardingHost(string forwardingHost)
        {
            _stream.ForwardingHost = forwardingHost;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithForwardingPort(int forwardingPort)
        {
            _stream.ForwardingPort = forwardingPort;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithTcpForwarding(bool tcpForwarding)
        {
            _stream.TcpForwarding = tcpForwarding;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithUdpForwarding(bool udpForwarding)
        {
            _stream.UdpForwarding = udpForwarding;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithEnabled(bool enabled)
        {
            _stream.Enabled = enabled;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithCertificateId(int? certificateId)
        {
            _stream.CertificateId = certificateId;
            return this;
        }

        /// <inheritdoc/>
        public IStreamBuilder WithMeta(StreamMeta meta)
        {
            _stream.Meta = meta;
            return this;
        }

        /// <inheritdoc/>
        public NginxProxyManager.SDK.Models.Streams.Stream Build()
        {
            return _stream;
        }
    }
} 