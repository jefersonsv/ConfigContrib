using ConfigContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public static class Settings
    {
        public static readonly string KEY_STRING = AppSettings.Get<string>(nameof(KEY_STRING));
        public static readonly int KEY_INT = AppSettings.Get<int>(nameof(KEY_INT));
        public static readonly bool KEY_BOOL = AppSettings.Get<bool>(nameof(KEY_BOOL));
    }
}