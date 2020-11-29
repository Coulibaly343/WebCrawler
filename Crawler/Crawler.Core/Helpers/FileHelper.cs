using System;
using System.IO;

namespace Crawler.Core.Helpers
{
    public static class FileHelper
    {
        public static string GetFileName(Uri url)
            => $"{DateTime.Now.Millisecond}{Path.GetExtension(url.AbsoluteUri)}";

    }
}
