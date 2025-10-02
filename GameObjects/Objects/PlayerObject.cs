using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.GameObjects.Objects
{
    public class PlayerObject : Character
    {
        public override string CharacterSign => "🧙‍♂️";
        public PlayerObject(string name, string gender, string birthplace)
        {
            Name = name;
            Gender = gender;
            Birthplace = birthplace;
        }
    }
}
