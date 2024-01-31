using System;
using System.Collections.Generic;

namespace MinecraftWordle.Extensions
{
	public static class ListTExtensions
	{
		public static void FillTo<T>(this List<T> list, int count)
		{
			while(list.Count < count)
			{
                list.Add(default);
			}
		}

        public static void FillTo<T>(this List<T> list, int count, Func<T> getDefault)
        {
            while (list.Count < count)
            {
                list.Add(getDefault());
            }
        }
    }
}
