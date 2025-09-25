using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Saving
{
    public class SaveData
    {
        public string UUID { get; set; }
        public CharacterMaster Character { get; set; }
        public SaveData(CharacterMaster character)
        {
            // Create a new uuid by combining character name together with a short uuid
            string uuid = Guid.NewGuid().ToString("N").Substring(0,8);
            UUID = $"{character.Name}_{uuid}";
            Character = character;
        }
    }
}
