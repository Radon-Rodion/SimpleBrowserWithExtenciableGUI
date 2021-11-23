using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesLibraryForSPP7
{
    public class HeightInLinesAttribute : System.Attribute
    {
        public int HeightInLines { get; set; }

        public HeightInLinesAttribute()
        { }

        public HeightInLinesAttribute(int heightInLines)
        {
            HeightInLines = heightInLines;
        }
    }
}
