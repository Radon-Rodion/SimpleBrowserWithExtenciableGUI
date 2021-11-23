using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesLibraryForSPP7
{
    public class WidthInLinesAttributes : System.Attribute
    {
        public int WidthInLines { get; set; }

        public WidthInLinesAttributes()
        { }

        public WidthInLinesAttributes(int widthInLines)
        {
            WidthInLines = widthInLines;
        }
    }
}
