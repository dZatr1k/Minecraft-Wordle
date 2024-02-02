using MinecraftWordle.Extensions;
using MinecraftWordle.Item;
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

        public CraftPattern(uint lineItemCount)
        {
            _lineItemCount = lineItemCount;
            _lines = new LinePattern[(int)lineItemCount];

            for (int i = 0; i < Length; i++)
            {
                _lines[i] = new LinePattern(lineItemCount);
            }
        }

        public CraftPattern(uint lineItemCount, LinePattern[] lines)
        {
            _lineItemCount = lineItemCount;

            if (lines == null)
                throw new ArgumentNullException("Lines is null.");

            if (lines.All(x => x == null || x.Length == lineItemCount) == false)
                throw new ArgumentException($"Line must contains {lineItemCount} items.");

            _lines = lines;
        }

        public void SetItem(ItemModel item, uint row, uint column)
        {
            _lines[column].SetItem(item, row);
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

            return new CraftPattern(_lineItemCount, lines.ToArray());
        }
    }
}
