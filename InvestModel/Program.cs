
using InvestModel;
using System.Runtime.ConstrainedExecution;

List<int[]> glArray = new List<int[]> 
{ 
    new int[] { 8, 16, 25, 36, 44, 62 },
    new int[] { 10, 20, 28, 40, 48, 62 },
    new int[] { 12, 21, 27, 38, 50, 63 },
    new int[] { 11, 23, 30, 37, 51, 63},
};

int[] cost = { 0, 20, 40, 60, 80, 100, 120 };

Tasks.Invest(glArray, cost);