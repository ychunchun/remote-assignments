using Microsoft.Extensions.DependencyInjection;
using System;

namespace Assignment_2
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }

    public class SimpleCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    public class AdvancedCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
        int sum = 0;
        int start = Math.Min(a, b);  //較小的數字作為起始值
        int end = Math.Max(a, b);  //較大數字作為結束值

        for (int i = start; i <= end; i++)
        {
            sum += i;
        }

        return sum;
        }

        public int Subtract(int a, int b)
        {
            int result = a;  //a做為結果的初始值

            for (int i = Math.Min(a, b) + 1; i <= Math.Max(a, b); i++)
            //Math.Min(a, b) + 1 作為起始值，為了避免將 a 自己納入運算,5-5?(錯誤)
            {
                result -= i;
            }

            return result;
        }
    }

    public class CalculatorController
    {
        private readonly ICalculator _calculator;
        private readonly string _calculatorType;

        public CalculatorController(ICalculator calculator, string calculatorType)
        {
            _calculator = calculator;
            _calculatorType = calculatorType;
        }

        public void Calculate(int a, int b)
        {
            if (_calculatorType == "Simple")
            {
                Console.WriteLine($"Using Simple Calculator: {a} + {b} = {_calculator.Add(a, b)}");
                Console.WriteLine($"Using Simple Calculator: {a} - {b} = {_calculator.Subtract(a, b)}");
            }
            else if (_calculatorType == "Advanced")
            {
                Console.WriteLine($"Using Advanced Calculator: {a} + {b} = {_calculator.Add(a, b)}");
                Console.WriteLine($"Using Advanced Calculator: {a} - {b} = {_calculator.Subtract(a, b)}");
            }
            else
            {
                Console.WriteLine("Invalid calculator type.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 建立一個 DI 容器來使用 SimpleCalculator
            var simpleServiceProvider = new ServiceCollection()
                .AddTransient<ICalculator, SimpleCalculator>()
                .AddTransient<CalculatorController>()
                .AddSingleton<string>("Simple")
                .BuildServiceProvider();

            // 從 SimpleCalculator 的 DI 容器中解析 CalculatorController
            var simpleCalculatorController = simpleServiceProvider.GetService<CalculatorController>();

            // 使用 SimpleCalculator 進行兩個整數的計算
            simpleCalculatorController.Calculate(5, 10);

            // 建立一個 DI 容器來使用 AdvancedCalculator
            var advancedServiceProvider = new ServiceCollection()
                .AddTransient<ICalculator, AdvancedCalculator>()
                .AddTransient<CalculatorController>()
                .AddSingleton<string>("Advanced")
                .BuildServiceProvider();

            // 從 AdvancedCalculator 的 DI 容器中解析 CalculatorController
            var advancedCalculatorController = advancedServiceProvider.GetService<CalculatorController>();

            // 使用 AdvancedCalculator 進行兩個整數的計算
            advancedCalculatorController.Calculate(5, 10);

        }
    }
}
