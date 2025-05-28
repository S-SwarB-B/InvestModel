using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestModel
{
    public class Tasks
    {
        static public void Invest(List<int[]> glArray, int[]cost)
        {
            List<int[,]> resultCost = new List<int[,]>();

            for (int i = glArray.Count - 1; i > 0; i--) 
            {
                int[] SecondStlb = glArray[i];
                int[] FirstStlb = glArray[i - 1];
                int prFinalCost = cost[1];
                int step = cost[1];

                List<int> resultSt = new List<int>();
                

                for (int k = 0; k < SecondStlb.Length; k++)
                {
                    int fix = prFinalCost;
                    int start = 0;
                    List<int[]> fine = new List<int[]>();
                    for (int j = 0; j < fix + 1; j = j + step)
                    {
                        fine.Add(new int[] { start, prFinalCost });
                        start += step;
                        prFinalCost -= step;
                    }
                    prFinalCost = fix + step;

                    List<int> numericList = new List<int>();

                    for (int j = 0; fine.Count > j; j++)
                    {
                        int[] ints2 = fine[j];
                                       
                        if (ints2[0] > 0 && ints2[1] == 0)
                        {
                           int index = cost.ToList().IndexOf(ints2[0]);
                           numericList.Add(FirstStlb[index - 1]);
                        }
                        else if (ints2[1] > 0 && ints2[0] == 0)
                        {
                            int index = cost.ToList().IndexOf(ints2[1]);
                            numericList.Add(SecondStlb[index - 1]);
                        }
                        else if (ints2[0] > 0 && ints2[1] > 0)
                        {
                            int index = cost.ToList().IndexOf(ints2[1]);
                            int index2 = cost.ToList().IndexOf(ints2[0]);
                            numericList.Add(SecondStlb[index - 1] + FirstStlb[index2 - 1]);
                        }
                        int b = 0;
                    }
                    resultSt.Add(numericList.Max());
                }
            }
        }
    }
}
