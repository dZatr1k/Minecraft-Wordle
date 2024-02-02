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

        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;

            var random = new Random();
            while (n > 1)
            {
                int k = random.Next(n--);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
        }
    }
}
