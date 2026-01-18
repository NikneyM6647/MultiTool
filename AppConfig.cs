using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTool
{
    internal class AppConfig
    {
        public string WatchFolder { get; set; } = @"D:\testnote\Downloads";
        public Dictionary<string, string> Rules { get; set; } = new(StringComparer.OrdinalIgnoreCase)
        {
            { ".png", "png" }, { ".jpg", "png" }, { ".jpeg", "png" },
            { ".mp4", "vid" }, { ".avi", "vid" }, { ".mkv", "vid" },
            { ".exe", "exe" },
            { ".mp3", "mus" }, { ".wav", "mus" },
            { ".torrent", "torr" },
            { ".ico", "ico" },
            { ".pdf", "doc" }, { ".doc", "doc" }, { ".docx", "doc" }, { ".odt", "doc" },
            { ".zip", "torr" }, { ".rar", "torr" }, { ".jar", "exe" }, {".txt", "doc"}
        };
    }
}
