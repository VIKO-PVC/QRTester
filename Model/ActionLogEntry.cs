using System;
using System.Drawing;

namespace Model
{
    public class ActionLogEntry
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
