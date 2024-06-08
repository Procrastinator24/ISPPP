using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPPP
{
	[Serializable]
	public class Workpiece
	{
		public int number { get; set; }
		public int[] times { get; set; }

		static public int[] GetOrder(Workpiece[] workpieces)
		{
			int[] order = new int[workpieces.Length];
			for (int i = 0; i < workpieces.Length; i++)
			{
				order[i] = workpieces[i].number;
			}
			return order;
		}
		static public Workpiece[] Copy(Workpiece[] workpieces)
		{
			Workpiece[] copyWorkpieces = new Workpiece[workpieces.Length];
			for (int i = 0; i < workpieces.Length; i++)
			{
				copyWorkpieces[i] = new Workpiece { number = workpieces[i].number, times = new int[workpieces[i].times.Length] };
				Array.Copy(workpieces[i].times, copyWorkpieces[i].times, workpieces[i].times.Length);
			}

			return copyWorkpieces;
		}
		static public Workpiece[] Generate(int n, int m, int minTime, int maxTime)
		{
			Random rnd = new Random();

			Workpiece[] workpieces = new Workpiece[m];
			for (int i = 0; i < workpieces.Length; i++)
			{
				workpieces[i] = new Workpiece { number = i + 1, times = new int[n] };
				for (int j = 0; j < n; j++)
				{
					workpieces[i].times[j] = rnd.Next(minTime, maxTime);
				}
			}

			return workpieces;
		}
	}
}
