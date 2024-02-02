using System.Collections.Generic;
using System.Linq;

namespace MinecraftWordle.Crafting
{
    public class CraftPatternComparer : IComparer<CraftPattern>
	{
        public int Compare(CraftPattern x, CraftPattern y)
        {
            if (x.Length != y.Length)
                return 1;
            x = x.GetUpLeftEdgeNormalizedPattern();
            y = y.GetUpLeftEdgeNormalizedPattern();
            var xLines = x.Lines.ToList();
            var yLines = y.Lines.ToList();
            for (int i = 0; i < xLines.Count; i++)
            {
                var xLine = xLines[i].Items.ToList();
                var yLine = yLines[i].Items.ToList();
                for (int j = 0; j < xLine.Count; j++)
                {
                    if (yLine[j] == null && xLine[j] == null)
                        continue;
                    if (yLine[j] == null || xLine[j] == null)
                        return 1;
                    if (yLine[j].Equals(xLine[j]) == false)
                        return 1;
                }
            }
            return 0;
        }
    }
}
