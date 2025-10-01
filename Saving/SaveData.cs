using LordsOfArda.GameObjects.Objects;
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
        public PlayerObject Player{ get; set; }
        public SaveData(PlayerObject player)
        {
            // Create a new uuid by combining character name together with a short uuid
            string uuid = Guid.NewGuid().ToString("N").Substring(0,8);
            UUID = $"{player.Name}_{uuid}";
            Player = player;
        }
    }
}
