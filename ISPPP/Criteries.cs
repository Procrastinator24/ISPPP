using ISPPP;
using System;
using System.Collections.Generic;

namespace ISPPP
{
    public interface ICriteria
    {
        string description { get; }
        object CountCriteria(Workpiece[] workpiece, int delta = 0);
        string GetInfo(Workpiece[] workpieces, int delta = 0);
    }
    public class TotalDownTimeCriteria : ICriteria
    {
        public string description { get => "Суммарное время простоя"; }

        //With Counted sums
        public object CountCriteria(Workpiece[] workpieces, int delta = 0)
        {
            double sum = 0;
            //Время простоя всех машин перед началом работы
            for (int i = 1; i < workpieces[0].times.Length - delta; i++)
            {
                sum += workpieces[0].times[i - 1];
            }

            for (int j = 1; j < workpieces[0].times.Length - delta; j++)
            {
                for (int i = 1; i < workpieces.Length; i++)
                {
                    if (workpieces[i].times[j - 1] > workpieces[i - 1].times[j])
                    {
                        sum += (workpieces[i].times[j - 1] - workpieces[i - 1].times[j]);
                    }
                }
            }


            return sum;
        }
        public string GetInfo(Workpiece[] workpieces, int delta = 0)
        {
            double sum = (double)CountCriteria(workpieces, delta);

            string info = description + " : " + sum + Environment.NewLine;

            return info;
        }
    }
    public class DownTimeEveryMAchineCriteria : ICriteria
    {
        public string description { get => "Суммарное время простоя каждого станка"; }
        //With Counted sums
        public object CountCriteria(Workpiece[] workpieces, int delta = 0)
        {
            double[] sums = new double[workpieces[0].times.Length - delta];
            //Время простоя каждой машины перед началом работы
            for (int i = 1; i < workpieces[0].times.Length - delta; i++)
            {
                //Предыдущее время изготовления + ...
                sums[i] = workpieces[0].times[i - 1];
            }

            for (int j = 1; j < workpieces[0].times.Length - delta; j++)
            {
                for (int i = 1; i < workpieces.Length; i++)
                {
                    if (workpieces[i].times[j - 1] > workpieces[i - 1].times[j])
                    {
                        sums[j] += (workpieces[i].times[j - 1] - workpieces[i - 1].times[j]);
                    }
                }
            }

            return sums;
        }

        public string GetInfo(Workpiece[] workpieces, int delta = 0)
        {
            double[] sum = (double[])CountCriteria(workpieces, delta);

            string info = description + " : " + Environment.NewLine;
            for (int i = 0; i < sum.Length; i++)
            {
                info += $"станок № {i + 1} : {sum[i]}" + Environment.NewLine;
            }

            return info;
        }
    }
    public class MachineTimeStartCriteria : ICriteria
    {
        public string description { get => "Время начала работы станка"; }
        //With Counted sums
        public object CountCriteria(Workpiece[] workpieces, int delta = 0)
        {
            double[] start_time = new double[workpieces[0].times.Length - delta];
            //Время простоя каждой машины перед началом работы
            for (int i = 1; i < workpieces[0].times.Length - delta; i++)
            {
                //Предыдущее время изготовления + ...
                start_time[i] = workpieces[0].times[i - 1];
            }

            return start_time;
        }

        public string GetInfo(Workpiece[] workpieces, int delta = 0)
        {
            double[] start_time = (double[])CountCriteria(workpieces, delta);

            string info = description + " : " + Environment.NewLine;
            for (int i = 0; i < start_time.Length; i++)
            {
                info += $"станок № {i + 1} : {start_time[i]}" + Environment.NewLine;
            }

            return info;
        }
    }

    public class MachineTimeEndCriteria : ICriteria
    {
        public string description { get => "Время окончания работы станка"; }
        //With Counted sums
        public object CountCriteria(Workpiece[] workpieces, int delta = 0)
        {
            double[] start_time = new double[workpieces[0].times.Length - delta];
            //Время простоя каждой машины перед началом работы
            
            for (int i = 0; i < workpieces[0].times.Length - delta; i++)
            {
                //Предыдущее время изготовления + ...
                start_time[i] = workpieces[workpieces.Length - 1].times[i];
            }

            return start_time;
        }

        public string GetInfo(Workpiece[] workpieces, int delta = 0)
        {
            double[] start_time = (double[])CountCriteria(workpieces, delta);

            string info = description + " : " + Environment.NewLine;
            for (int i = 0; i < start_time.Length; i++)
            {
                info += $"станок № {i + 1} : {start_time[i]}" + Environment.NewLine;
            }

            return info;
        }
    }
   public class TotalTimeWorkCriteria : ICriteria
    {
        public string description { get => "Суммарное время изготовления детали"; }

        //With Counted sums
        public object CountCriteria(Workpiece[] workpieces, int delta = 0)
        {
            double time = workpieces[workpieces.Length - 1].times[workpieces[0].times.Length - delta - 1];
            return time;
        }
        public string GetInfo(Workpiece[] workpieces, int delta = 0)
        {
            double time = (double)CountCriteria(workpieces, delta);

            string info = description + " : " + time + Environment.NewLine;

            return info;
        }
    }
    
    class CriteriesMethods
    {
        static public IComparer<(MethodType algoritm, object criteriaRes, int[] partsOrder)> GetComparerByCriteria(ICriteria criteria)
        {
            if (criteria as TotalDownTimeCriteria != null)
            {
                return new DefaultArrSort();
            }

            if (criteria as DownTimeEveryMAchineCriteria != null)
            {
                return new TwoArrsSort();
            }

            if (criteria as MachineTimeStartCriteria != null)
            {
                return new TwoArrsSort();
            }

            if (criteria as MachineTimeEndCriteria != null)
            {
                return new TwoArrsSort();
            }

            if (criteria as TotalTimeWorkCriteria != null)
            {
                return new DefaultArrSort();
            }

            throw new Exception("Неопределнный критерий");
        }
        //Начиная с минимального времени
        class DefaultArrSort : IComparer<(MethodType algoritm, object criteriaRes, int[] partsOrder)>
        {
            public int Compare((MethodType algoritm, object criteriaRes, int[] partsOrder) x, (MethodType algoritm, object criteriaRes, int[] partsOrder) y)
            {
                double res = (double)x.criteriaRes - (double)y.criteriaRes;
                return res < 0 ? -1 : res > 0 ? 1 : 0;
            }
        }
        //Начиная с минимального времени
        class TwoArrsSort : IComparer<(MethodType algoritm, object criteriaRes, int[] partsOrder)>
        {
            public int Compare((MethodType algoritm, object criteriaRes, int[] partsOrder) x, (MethodType algoritm, object criteriaRes, int[] partsOrder) y)
            {
                int res = 0;
                double tmp;
                double[] timesX = (double[])x.criteriaRes;
                double[] timesY = (double[])y.criteriaRes;
                for (int i = 0; i < timesX.Length; i++)
                {
                    tmp = timesX[i] - timesY[i];
                    if (tmp > 0)
                    {
                        return 1;
                    }
                    else if (tmp < 0)
                    {
                        return -1;
                    }
                }

                return res;
            }
        }
        static public ICriteria[] GetAllCriteries()
        {
            ICriteria[] criterias = new ICriteria[] { new DownTimeEveryMAchineCriteria(), new TotalDownTimeCriteria(), new MachineTimeStartCriteria(), new MachineTimeEndCriteria(), new TotalTimeWorkCriteria() };

            return criterias;
        }
    }
}
