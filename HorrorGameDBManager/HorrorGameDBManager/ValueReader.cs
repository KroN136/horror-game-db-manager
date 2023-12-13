namespace HorrorGameDBManager
{
    internal static class ValueReader
    {
        public static byte ReadByte(string message, string errorMessage = $"Введите целое число в диапазоне от 0 до 255.")
        {
            byte output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !byte.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        public static byte? ReadNullableByte(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 255 (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            byte parseOutput = 0;
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !byte.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        public static ushort ReadUShort(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 65 535.")
        {
            ushort output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !ushort.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        public static ushort? ReadNullableUShort(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 65 535 (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            ushort parseOutput = 0;
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !ushort.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        public static ulong ReadULong(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 18 446 744 073 709 551 615.")
        {
            ulong output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !ulong.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        public static string ReadString(string message, string errorMessage = "Введите непустую строку.")
        {
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || input.ToLower().Equals("null"))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input;
        }

        public static bool ReadBool(string message, string errorMessage = "Возможные формы ответа: true, yes, y, false, no, n, истина, да, д, ложь, нет, н.")
        {
            string[] trueOptions = new string[] { "true", "yes", "y", "истина", "да", "д" };
            string[] falseOptions = new string[] { "false", "no", "n", "ложь", "нет", "н" };
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!trueOptions.Contains(input) && !falseOptions.Contains(input)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return trueOptions.Contains(input);
        }

        public static bool? ReadNullableBool(string message, string errorMessage = "Возможные формы ответа: true, yes, y, false, no, n, истина, да, д, ложь, нет, н (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            string[] trueOptions = new string[] { "true", "yes", "y", "истина", "да", "д" };
            string[] falseOptions = new string[] { "false", "no", "n", "ложь", "нет", "н" };
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !trueOptions.Contains(input) && !falseOptions.Contains(input)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : trueOptions.Contains(input);
        }

        public static DateTime? ReadNullableDateTime(string message, string errorMessage = "Введите значение типа DateTime (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            DateTime parseOutput = new(0);
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !DateTime.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        public static float ReadFloat(string message, string errorMessage = "Введите значение типа float.")
        {
            float output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !float.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        public static float? ReadNullableFloat(string message, string errorMessage = "Введите значение типа float (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            float parseOutput = float.NaN;
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !float.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }
    }
}
