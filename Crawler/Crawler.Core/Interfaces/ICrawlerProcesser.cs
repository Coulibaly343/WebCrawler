using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Core.Interfaces
{
    public interface ICrawlerProcesser
    {
        Task<IEnumerable<string>> Process(Uri uri);
    }
}
