using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesLibraryForSPP7
{
    public class TopSpanInLinesAttribute : System.Attribute
    {
        public int TopSpanInLines { get; set; }

        public TopSpanInLinesAttribute()
        { }

        public TopSpanInLinesAttribute(int topSpanInLines)
        {
            TopSpanInLines = topSpanInLines;
        }
    }
}
