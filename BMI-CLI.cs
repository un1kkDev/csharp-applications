using System;

namespace my_console_app
{
    class Program
    {
        const string VERSION_NUMBER = "1.0";
        const string BMI = "bmi", HELPS = "--helps", VERSION = "--version", HEIGHT = "--height", WEIGHT = "--weight";
        static void Main(string[] args)
        {
            try
            {
                if (args[0] != BMI) getError();
                switch (args[1])
                {
                    case HELPS:
                        if (args.Length != 2) getError();
                        printHelp();
                        break;
                    case VERSION:
                        if (args.Length != 2) getError();
                        printVersion();
                        break;
                    case HEIGHT:
                        if (args[3] != WEIGHT) getError();
                        printBmi(args[2], args[4]);
                        break;
                    case WEIGHT:
                        if (args[3] != HEIGHT) getError();
                        printBmi(args[4], args[2]);
                        break;
                    default:
                        getError();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid command :(");
                Console.WriteLine("Use --helps switch to show help");
            }

        }

        static void printHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Use these switch to run program:");
            Console.WriteLine($"{HEIGHT}        Your height (centimeters)");
            Console.WriteLine($"{WEIGHT}        Your weight (kilograms)");
            Console.WriteLine($"{VERSION}       Show current version");
            Console.WriteLine($"{HELPS}         Show command list");
        }

        static void printVersion()
        {
            Console.WriteLine();
            Console.WriteLine($"Current version is: {VERSION_NUMBER}");
        }

        static void printBmi(string height, string weight)
        {
            var bmi = bmiCalculator(Convert.ToDouble(height), Convert.ToDouble(weight));
            Console.WriteLine();
            Console.WriteLine("Your BMI score is:");
            Console.WriteLine(bmi);
            Console.WriteLine($"Your Status is: {checkStatus(bmi)}");
        }

        static double bmiCalculator(double height, double weight)
        {
            return weight / Math.Pow(height / 100, 2);
        }

        static string checkStatus(double bmi)
        {
            if (bmi < 18.5) return "Below normal weight";
            if (bmi < 25) return "Normal weight";
            if (bmi < 30) return "Overweight";
            return "Obesity";
        }

        static void getError()
        {
            throw new Exception();
        }
    }
}
