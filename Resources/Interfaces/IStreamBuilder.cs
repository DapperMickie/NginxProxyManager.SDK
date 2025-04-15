using NginxProxyManager.SDK.Models.Streams;

namespace NginxProxyManager.SDK.Resources.Interfaces
{
    /// <summary>
    /// Interface for building stream requests
    /// </summary>
    public interface IStreamBuilder
    {
        /// <summary>
        /// Sets the owner user ID
        /// </summary>
        /// <param name="ownerUserId">The owner user ID</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithOwnerUserId(int ownerUserId);

        /// <summary>
        /// Sets the incoming port
        /// </summary>
        /// <param name="incomingPort">The incoming port</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithIncomingPort(int incomingPort);

        /// <summary>
        /// Sets the forwarding host
        /// </summary>
        /// <param name="forwardingHost">The forwarding host</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithForwardingHost(string forwardingHost);

        /// <summary>
        /// Sets the forwarding port
        /// </summary>
        /// <param name="forwardingPort">The forwarding port</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithForwardingPort(int forwardingPort);

        /// <summary>
        /// Sets whether TCP forwarding is enabled
        /// </summary>
        /// <param name="tcpForwarding">Whether TCP forwarding is enabled</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithTcpForwarding(bool tcpForwarding);

        /// <summary>
        /// Sets whether UDP forwarding is enabled
        /// </summary>
        /// <param name="udpForwarding">Whether UDP forwarding is enabled</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithUdpForwarding(bool udpForwarding);

        /// <summary>
        /// Sets whether the stream is enabled
        /// </summary>
        /// <param name="enabled">Whether the stream is enabled</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithEnabled(bool enabled);

        /// <summary>
        /// Sets the certificate ID
        /// </summary>
        /// <param name="certificateId">The certificate ID</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithCertificateId(int? certificateId);

        /// <summary>
        /// Sets the metadata
        /// </summary>
        /// <param name="meta">The metadata</param>
        /// <returns>The stream builder</returns>
        IStreamBuilder WithMeta(StreamMeta meta);

        /// <summary>
        /// Builds the stream
        /// </summary>
        /// <returns>The built stream</returns>
        NginxProxyManager.SDK.Models.Streams.Stream Build();
    }
} 