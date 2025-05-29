using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace InvestModel
{
    public class Tasks
    {
        static public void Invest(List<int[]> glArray, int[] cost)
        {
            List<int[][]> resultCost = new List<int[][]>(); //Стоимость результата
            int a = glArray.Count;

            for (int i = glArray.Count - 1; i > 0; i--)
            {
                int[] SecondStlb = glArray[i]; //Последний столбец
                int[] FirstStlb = glArray[i - 1]; //Предпоследний столбец
                int prFinalCost = cost[1]; //Начальная стоимость
                int step = cost[1]; //Шаг
                List<int> resultStPr = new List<int>(); //Лист максимальных значений

                for (int k = 0; k < SecondStlb.Length; k++)
                {
                    int fix = prFinalCost; //Фиксация значения
                    int start = 0; //Начальное значение
                    List<int[]> fine = new List<int[]>(); //Штрафы

                    for (int j = 0; j < fix + 1; j = j + step)
                    {
                        fine.Add(new int[] { start, prFinalCost }); //Добавление штрафа
                        start += step; //Увеличение значения
                        prFinalCost -= step; //Уменьшение начальной стоимости
                    }

                    prFinalCost = fix + step; //Увеличение начальной стоимости для следующего прохода цикла
                    List<int> numericList = new List<int>(); //Лист всех значений

                    for (int j = 0; fine.Count > j; j++)
                    {
                        int[] raspred = fine[j]; //Значение распределения

                        if (raspred[0] > 0 && raspred[1] == 0)
                        {
                            int index = cost.ToList().IndexOf(raspred[0]); //Получение индекса числа из стоимости
                            numericList.Add(FirstStlb[index - 1]); //Добавление в лист всех значений
                        }
                        else if (raspred[1] > 0 && raspred[0] == 0)
                        {
                            int index = cost.ToList().IndexOf(raspred[1]); //Получение индекса числа из стоимости
                            numericList.Add(SecondStlb[index - 1]); //Добавление в лист всех значений
                        }
                        else if (raspred[0] > 0 && raspred[1] > 0)
                        {
                            int index = cost.ToList().IndexOf(raspred[1]); //Получение индекса числа из стоимости
                            int index2 = cost.ToList().IndexOf(raspred[0]); //Получение индекса числа из стоимости
                            numericList.Add(SecondStlb[index - 1] + FirstStlb[index2 - 1]); //Добавление в лист всех значений
                        }
                    }

                    List<int[]> fineNew = new List<int[]>(); //Лист для записи без лишних штрафов
                    for (int j = 0; numericList.Count > j; j++)
                    {
                        if (numericList[j] == numericList.Max())
                        {
                            fineNew.Add(fine[j]); //Добавление в лист
                        }
                    }

                    resultStPr.Add(numericList.Max()); //Заполнение столбца
                    resultCost.Add(fineNew.ToArray()); //Заполнение стоимости
                }
                glArray.RemoveAt(i);                           //
                glArray.RemoveAt(i - 1);                       // Объединение строк
                glArray.Add(resultStPr.ToArray());             //

                if (glArray.Count == 1)
                {
                    Console.WriteLine($"Функция: {resultStPr[resultStPr.Count - 1]}"); //Получение значения функции
                    int count = 0; //Счетчик
                    int indexCost = cost.Length - 1; //Индекс
                    int indexCostSt = cost.Length - 1; //Резервный индекс
                    for (int j = 0; a > j; j++)
                    {
                        if (j == a - 1)
                        {
                            count -= resultStPr.Count; //Уменьшение стоимости, чтобы остаться на текущем шаге
                            Console.WriteLine($"{j + 1} - {resultCost[resultCost.Count - count - cost.Length + indexCostSt][0][1]}"); //Запись в консоль
                        }
                        else
                        {
                            Console.WriteLine($"{j + 1} - {resultCost[resultCost.Count - count - cost.Length + indexCost][0][0]}"); //Запись в консоль
                            indexCostSt = indexCost; //Присваивание значению резервного индекса значение индекса
                            indexCost = cost.ToList().IndexOf(resultCost[resultCost.Count - count - cost.Length + indexCost][0][1]); //Получение индекса из стоимости
                            count += resultStPr.Count; //Увеличение стоимости
                        }
                    }
                }
            }
        }
    }
}