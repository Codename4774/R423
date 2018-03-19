using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Classes.Models
{
    [Serializable]
    public class LineSerializeState
    {
        public int Id { get; set; }

        public Point[] Points { get; set; }

        public LineSerializeState(int id, Point[] points)
        {
            this.Points = points;
            Id = id;
        }

        public LineSerializeState()
        {
        }
    }
}
