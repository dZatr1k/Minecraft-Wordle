using MinecraftWordle.Extensions;
using System;
using System.Linq;
using UnityEngine;

namespace MinecraftWordle.Crafting
{
	[Serializable]
	public class CraftPattern
	{
		[SerializeField] private LinePattern[] _lines;
        
        private uint _lineItemCount;

        public int Length => (int)_lineItemCount;

        private CraftPattern(uint lineItemCount, LinePattern[] lines)
        {
            _lineItemCount = lineItemCount;

            if (lines == null)
                throw new ArgumentNullException("Lines is null.");

            if(lines.All(x => x == null || x.Length == lineItemCount) == false)
                throw new ArgumentException($"Line must contains {lineItemCount} items.");

            _lines = lines;
        }

        public CraftPattern(uint lineItemCount)
        {
            _lineItemCount = lineItemCount;
            _lines = new LinePattern[(int)lineItemCount];

            for (int i = 0; i < Length; i++)
            {
                _lines[i] = new LinePattern(lineItemCount);
            }
        }

        public CraftPattern GetUpLeftEdgeNormalizedPattern()
        {
            var lines = _lines
                .SkipWhile(x => x.IsEmpty())
                .ToList();
            lines.FillTo(Length, () => new LinePattern(_lineItemCount));
            
            int lineSpacing = lines
                .Select(x => x.GetNonEmptyItemIndex())
                .Min();
            lines.ForEach(x => x.Resize(lineSpacing));

            Debug.Log(lineSpacing);
            return new CraftPattern(_lineItemCount, lines.ToArray());
        }

        public override string ToString()
        {
            var result = "";
            _lines.ToList().ForEach(x => result += x.ToString() + "\n");
            return result;
        }
    }
}
