using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class DialogueMaster
    {
        Guid ID { get; set; }
        string Language { get; set; }
        string Narration { get; set; }
        string Speaker { get; set; }
        string[] Options { get; set; }
        List<string> Events { get; set; }

        public DialogueMaster(string language, string narration, string speaker, string[] options, List<string> events)
        {
            ID = Guid.NewGuid();
            Language = language;
            Narration = narration;
            Speaker = speaker;
            Options = options;
            Events = events;
        }
    }
}
