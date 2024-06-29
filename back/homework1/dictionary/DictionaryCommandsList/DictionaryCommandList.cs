using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary.DictionaryCommandsList
{
    public static class DictionaryCommandList
    {
        public static string CommandAddTranslation { get; } = "addtranslation";
        public static string CommandRemoveTranslation { get; } = "removetranslation";
        public static string CommandChangeTranslation { get; } = "changetranslation";
        public static string CommandTranslate { get; } = "translate";
        public static string CommandExit { get; } = "exit";
    }
}
