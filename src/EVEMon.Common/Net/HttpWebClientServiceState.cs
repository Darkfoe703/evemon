using System;
using EVEMon.Common.SettingsObjects;

namespace EVEMon.Common.Net
{
    /// <summary>
    /// Conainer class for HttpWebService settings and state
    /// </summary>
    public static class HttpWebClientServiceState
    {
        private static readonly object s_syncLock = new object();
        private static ProxySettings s_proxy = new ProxySettings();

        /// <summary>
        /// The maximum size of a download section.
        /// </summary>
        public static int MaxBufferSize => 8192;

        /// <summary>
        /// The minimum size if a download section.
        /// </summary>
        public static int MinBufferSize => 1024;

        /// <summary>
        /// The user agent string for requests.
        /// </summary>
        public static string UserAgent
        {
            get
            {
                var architecture = Environment.Is64BitOperatingSystem
                    ? "x64"
                    : "x86";

                return $"{EveMonClient.FileVersionInfo.ProductName}/{EveMonClient.FileVersionInfo.FileVersion}" +
                       $" ({Environment.OSVersion.VersionString}; {architecture})";
            }
        }

        /// <summary>
        /// The maximum redirects allowed for a request.
        /// </summary>
        public static int MaxRedirects => 5;

        /// <summary>
        /// A ProxySetting instance for the custom proxy to be used.
        /// </summary>
        public static ProxySettings Proxy
        {
            get
            {
                lock (s_syncLock)
                {
                    return s_proxy;
                }
            }
            set
            {
                lock (s_syncLock)
                {
                    s_proxy = value;
                }
            }
        }
    }
}