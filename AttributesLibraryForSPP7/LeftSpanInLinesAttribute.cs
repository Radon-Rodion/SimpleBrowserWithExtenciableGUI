using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesLibraryForSPP7
{
    public class LeftSpanInLinesAttribute : System.Attribute
    {
        public int LeftSpanInLines { get; set; }

        public LeftSpanInLinesAttribute()
        { }

        public LeftSpanInLinesAttribute(int leftSpanInLines)
        {
            LeftSpanInLines = leftSpanInLines;
        }
    }
}
