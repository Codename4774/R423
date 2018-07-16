using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R423.Model
{
    public class SelectedMode
    {
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string Speed { get; }
        public string Direction { get; }

        public SelectedMode(int id, string name, string speed, string type, string direction)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Speed = speed;
            this.Direction = direction;
        }
    }
}
