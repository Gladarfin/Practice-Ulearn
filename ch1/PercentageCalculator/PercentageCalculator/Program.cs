using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PercentageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 3 числа через пробел(исходная сумма, процентная ставка, срок вклада в месяцах): ");
            double sumAmount=Calculate(Console.ReadLine());
            Console.Write("Итоговая сумма: ");
            Console.WriteLine(Math.Round(sumAmount,2));
            Console.ReadKey();
        }

        public static double Calculate(string userInput)
        {
            string[] inputData = userInput.Split(' ');
            double sum = Convert.ToDouble(inputData[0], CultureInfo.InvariantCulture);
            double percent = Convert.ToDouble(inputData[1], CultureInfo.InvariantCulture);
            int period = Convert.ToInt32(inputData[2]);
            double percent_for_period = percent / 100 / 12;
            double finalAmount = sum * Math.Pow(1 + percent_for_period, period);
            return finalAmount;
        }

    }
}
