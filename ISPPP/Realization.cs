using ISPPP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ISPPP
{
    #region Jonson
    //Сортировка по максимальному времени изготовления детали на станке среди всех деталей. 
    public class NWorkpieceComparerMaxTime : IComparer<Workpiece>
    {
        public int Compare(Workpiece p1, Workpiece p2)
        {
            int res = find_max_time(p1) - find_max_time(p2);
			if (res < 0) return -1;
			if (res > 0) return 1;
			return 0;
        }

        public int find_max_time(Workpiece p)
        {
            int max = p.times[0];
            for (int i = 0; i < p.times.Length; i++)
            {
                if (max < p.times[i])
                {
                    max = p.times[i];
                }
            }

            return max;
        }
    }
    //Сортировка по максимальному времени изготовления детали на станке среди всех деталей. (Не одно и то же, что с MaxTime, reverse не поможет)
    public class NWorkpieceComparerMinTime : IComparer<Workpiece>
    {
        public int Compare(Workpiece p1, Workpiece p2)
        {
            int res = find_min_time(p1) - find_min_time(p2);
            if (res < 0) return -1;
            if (res > 0) return 1;
            return 0;
        }

        public int find_min_time(Workpiece p)
        {
            int min = p.times[0];

            for (int i = 0; i < p.times.Length; i++)
            {
                if (min > p.times[i])
                {
                    min = p.times[i];
                }
            }

            return min;
        }
    }
    //Сортировка по станку с указанным индексом 
    public class NWorkpieceComparerTimeIndex : IComparer<Workpiece>
    {
        int index = 0;
        public NWorkpieceComparerTimeIndex(int index)
        {
            this.index = index;
        }
        public int Compare(Workpiece p1, Workpiece p2)
        {
            int res = p1.times[index] - p2.times[index];
			if (res < 0) return -1;
			if (res > 0) return 1;
			return 0;
        }
    }

    //Workpiece - массив деталей для каждой из которых имеется массив времени изготовленияя на каждом станке. 
    static public class JonsonsMethod
    {
        //n - количество станков, m - время выполнения деталей
        static public Workpiece[] Jonson(Workpiece[] workpieces_times, int type_generalization = 1)
        {
            if (workpieces_times[0].times.Length == 2)
            {
                return JonsonClassic(workpieces_times);
            }

            switch (type_generalization)
            {
                case 1:
                    {
                        return Jonson_1(workpieces_times);
                    }
                case 2:
                    {
                        return Jonson_2(workpieces_times);
                    }
                case 3:
                    {
                        return Jonson_3(workpieces_times);
                    }
                case 4:
                    {
                        return Jonson_4(workpieces_times);
                    }
                case 5:
                    {
                        return Jonson_5(workpieces_times);
                    }
                default:
                    {
                        throw new Exception("Нет такого обобщения");
                    }
            }
        }

        static public Workpiece[] JonsonClassic(Workpiece[] workpieces)
        {
            Array.Sort(workpieces, new NWorkpieceComparerMinTime());

            int start_pos = 0;
            int end_pos = workpieces.Length - 1;
            //queue
            Workpiece[] workpieces_order = new Workpiece[workpieces.Length];

            for (int i = 0; i < workpieces.Length; i++)
            {
                if (workpieces[i].times[0] > workpieces[i].times[1])
                {
                    workpieces_order[end_pos] = new Workpiece { number = workpieces[i].number, times = workpieces[i].times };
                    end_pos--;
                }
                else
                {
                    workpieces_order[start_pos] = new Workpiece { number = workpieces[i].number, times = workpieces[i].times };
                    start_pos++;
                }
            }

            return workpieces_order;
        }

        //Сортировка по первому станку, время - по возрастанию. 
        static public Workpiece[] Jonson_1(Workpiece[] workpieces_times)
        {
            Array.Sort(workpieces_times, new NWorkpieceComparerTimeIndex(0));

            return workpieces_times;
        }
        //Сортировка по последнему станку, время - по убыванию
        static public Workpiece[] Jonson_2(Workpiece[] workpieces_times)
        {
            Array.Sort(workpieces_times, new NWorkpieceComparerTimeIndex(workpieces_times[0].times.Length - 1));
            Array.Reverse(workpieces_times);

            return workpieces_times;
        }

        //Если время одинаковое, то разницы нет, какая деталь будет первой? Если есть, то убрать reverse и переписать алгоритм записи наоборот. 
        static public Workpiece[] Jonson_3(Workpiece[] workpieces_times)
        {
            Array.Sort(workpieces_times, new NWorkpieceComparerMaxTime());
            Array.Reverse(workpieces_times);

            return workpieces_times;
        }

        //Внешний цикл по деталям
        //Вложенный цикл - по станкам. Считаем суммарное время обработки на всех станках для каждой детали, потом сортируем. 
        static public Workpiece[] Jonson_4(Workpiece[] workpieces_times)
        {
            Workpiece[] sorted_workpieces = Jonson_4_get_pos(workpieces_times);

            for (int i = 0; i < sorted_workpieces.Length; i++)
            {
                for (int j = 0; j < workpieces_times.Length; j++)
                {
                    if (sorted_workpieces[i].number == workpieces_times[j].number)
                    {
                        sorted_workpieces[i].times = workpieces_times[j].times;
                    }
                }
            }

            return sorted_workpieces;
        }
        //number - суммаю. Возврат отсортирован по убыванию
        static public Workpiece[] Jonson_4_get_pos(Workpiece[] workpieces_times)
        {
            Workpiece[] workpieces_sum_time = new Workpiece[workpieces_times.Length];

            for (int i = 0; i < workpieces_times.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < workpieces_times[i].times.Length; j++)
                {
                    sum += workpieces_times[i].times[j];
                }
                workpieces_sum_time[i] = new Workpiece { number = workpieces_times[i].number, times = new int[1] { sum } };
            }

            Array.Sort(workpieces_sum_time, new NWorkpieceComparerTimeIndex(0));
            Array.Reverse(workpieces_sum_time);

            return workpieces_sum_time;
        }

        static public Workpiece[] Jonson_5(Workpiece[] workpieces_times)
        {
            Workpiece[] workpieces = Jonson_5_get_pos(workpieces_times);

            for (int i = 0; i < workpieces.Length; i++)
            {
                for (int j = 0; j < workpieces_times.Length; j++)
                {
                    if (workpieces[i].number == workpieces_times[j].number)
                    {
                        workpieces[i].times = workpieces_times[j].times;
                    }
                }
            }

            return workpieces;
        }

        static public Workpiece[] Jonson_5_get_pos(Workpiece[] workpieces_times)
        {
            Workpiece[] tmp = Workpiece.Copy(workpieces_times);
            Workpiece[] workpieces_order_1 = Jonson_1(tmp);
            tmp = Workpiece.Copy(workpieces_times);
            Workpiece[] workpieces_order_2 = Jonson_2(tmp);
            tmp = Workpiece.Copy(workpieces_times);
            Workpiece[] workpieces_order_3 = Jonson_3(tmp);
            tmp = Workpiece.Copy(workpieces_times);
            Workpiece[] workpieces_order_4 = Jonson_4(tmp);

            Workpiece[][] workpieces_orders = new Workpiece[4][];
            workpieces_orders[0] = workpieces_order_1;
            workpieces_orders[1] = workpieces_order_2;
            workpieces_orders[2] = workpieces_order_3;
            workpieces_orders[3] = workpieces_order_4;

            Workpiece[] workpieces_sum_time = new Workpiece[workpieces_times.Length];

            for (int i = 0; i < workpieces_times.Length; i++)
            {
                int pos_sum = 0;
                int index = -1;
                int number = workpieces_times[i].number;

                for (int j = 0; j < workpieces_orders.Length; j++)
                {
                    index = Array.FindIndex(workpieces_orders[j], w => w.number == number);
                    pos_sum += index + 1;
                }
                workpieces_sum_time[i] = new Workpiece { number = number, times = new int[1] { pos_sum } };
            }

            Array.Sort(workpieces_sum_time, new NWorkpieceComparerTimeIndex(0));

            return workpieces_sum_time;
        }
    }
    #endregion Jonson

    #region PetrovSokolicin
    static public class PetrovSokolicinMethod
    {
        static public Workpiece[] GetSum1Workpieces(Workpiece[] workpieces)
        {
            Workpiece[] res_workpieces = ExtendWorkpieces(workpieces);

            Array.Sort(workpieces, new NWorkpieceComparerTimeIndex(workpieces[0].times.Length - 3));

            return workpieces;
        }

        static public Workpiece[] GetSum2Workpieces(Workpiece[] workpieces)
        {
            Workpiece[] res_workpieces = ExtendWorkpieces(workpieces);

            Array.Sort(workpieces, new NWorkpieceComparerTimeIndex(workpieces[0].times.Length - 2));
            Array.Reverse(workpieces);

            return workpieces;
        }

        static public Workpiece[] GetDifferenceWorkpieces(Workpiece[] workpieces)
        {
            Workpiece[] res_workpieces = ExtendWorkpieces(workpieces);

            Array.Sort(workpieces, new NWorkpieceComparerTimeIndex(workpieces[0].times.Length - 1));
            Array.Reverse(workpieces);

            return workpieces;
        }
       
        static public Workpiece[] Petrov_Sokolicin(Workpiece[] workpieces, bool has_sums_format = true)
        {
            int delta = 0;
            if (has_sums_format == true)
            {
                delta = 3;
            }

            for (int i = 1; i < workpieces[0].times.Length - delta; i++)
            {
                workpieces[0].times[i] = workpieces[0].times[i] + workpieces[0].times[i - 1];
            }

            for (int i = 1; i < workpieces.Length; i++)
            {
                workpieces[i].times[0] = workpieces[i].times[0] + workpieces[i - 1].times[0];
            }

            for (int i = 1; i < workpieces.Length; i++)
            {
                for (int j = 1; j < workpieces[i].times.Length - delta; j++)
                {
                    workpieces[i].times[j] = workpieces[i].times[j] + Math.Max(workpieces[i].times[j - 1], workpieces[i - 1].times[j]);
                }
            }

            return workpieces;
        }

		static public Workpiece[] ExtendWorkpieces(Workpiece[] workpieces)
        {
            int[] sum1 = GetSum1(workpieces);
            int[] sum2 = GetSum2(workpieces);
            int[] difference = GetDifference(workpieces);

            for (int i = 0; i < workpieces.Length; i++)
            {
                int[] times = new int[workpieces[i].times.Length + 3];
                Array.Copy(workpieces[i].times, times, workpieces[i].times.Length);

                int length = workpieces[i].times.Length;
                workpieces[i].times = times;
                workpieces[i].times[length] = sum1[i];
                workpieces[i].times[length + 1] = sum2[i];
                workpieces[i].times[length + 2] = difference[i];
            }

            return workpieces;
        }


        static public int[] GetSum1(Workpiece[] workpieces)
        {
            int[] sums1 = new int[workpieces.Length];
            for (int i = 0; i < workpieces.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < workpieces[i].times.Length - 1; j++)
                {
                    sum += workpieces[i].times[j];
                }
                sums1[i] = sum;
            }

            return sums1;
        }
        static public int[] GetSum2(Workpiece[] workpieces)
        {
            int[] sums2 = new int[workpieces.Length];
            for (int i = 0; i < workpieces.Length; i++)
            {
                int sum = 0;
                for (int j = 1; j < workpieces[i].times.Length; j++)
                {
                    sum += workpieces[i].times[j];
                }
                sums2[i] = sum;
            }

            return sums2;
        }
        static public int[] GetDifference(Workpiece[] workpieces)
        {
            int[] sum1 = GetSum1(workpieces);
            int[] sum2 = GetSum2(workpieces);

            for (int i = 0; i < workpieces.Length; i++)
            {
                sum2[i] -= sum1[i];
            }

            return sum2;
        }
    }
    #endregion PetrovSokolicin
}