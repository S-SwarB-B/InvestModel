using InvestModel;

List<int[]> glArray = new List<int[]>  //Лист для теста
{ 
    new int[] { 8, 16, 25, 36, 44, 62 },
    new int[] { 10, 20, 28, 40, 48, 62 },
    new int[] { 12, 21, 27, 38, 50, 63 },
    new int[] { 11, 23, 30, 37, 51, 63},
};

int[] cost = { 0, 20, 40, 60, 80, 100, 120 }; //Стоимость для теста


List<int[]> glArray2 = new List<int[]> //Лист для теста
{
    new int[] { 10, 15, 24, 33 },
    new int[] { 9, 16, 22, 34 },
    new int[] { 7, 13, 20, 32 },
    new int[] { 8, 14, 21, 40 },
};

int[] cost2 = { 0, 50, 100, 150, 200 }; //Стоимость для теста

List<int[]> glArray3 = new List<int[]> //Лист для теста
{
    new int[] { 10, 14, 26, 38 },
    new int[] { 12, 15, 25, 39 },
    new int[] { 11, 12, 20, 37 },
    new int[] { 9, 16, 24, 40 },
};

int[] cost3 = { 0, 50, 100, 150, 200 }; //Стоимость для теста


Tasks.Invest(glArray3, cost3);