using System;

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("===== Built-in Type Min and Max Values =====\n");

                try
                {
                    Console.WriteLine($"byte     : Min = {byte.MinValue}, Max = {byte.MaxValue}");
                    Console.WriteLine($"sbyte    : Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}");
                    Console.WriteLine($"short    : Min = {short.MinValue}, Max = {short.MaxValue}");
                    Console.WriteLine($"ushort   : Min = {ushort.MinValue}, Max = {ushort.MaxValue}");
                    Console.WriteLine($"int      : Min = {int.MinValue}, Max = {int.MaxValue}");
                    Console.WriteLine($"uint     : Min = {uint.MinValue}, Max = {uint.MaxValue}");
                    Console.WriteLine($"long     : Min = {long.MinValue}, Max = {long.MaxValue}");
                    Console.WriteLine($"ulong    : Min = {ulong.MinValue}, Max = {ulong.MaxValue}");
                    Console.WriteLine($"float    : Min = {float.MinValue}, Max = {float.MaxValue}");
                    Console.WriteLine($"double   : Min = {double.MinValue}, Max = {double.MaxValue}");
                    Console.WriteLine($"decimal  : Min = {decimal.MinValue}, Max = {decimal.MaxValue}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Overflow error while retrieving numeric limits: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error while displaying numeric limits: {ex.Message}");
                }

                Console.WriteLine("\n===== Other Built-in Types =====\n");

                try
                {
                    Console.WriteLine($"char     : Min = {(int)char.MinValue}, Max = {(int)char.MaxValue} ('{char.MaxValue}')");
                    Console.WriteLine($"bool     : Values = {bool.FalseString}, {bool.TrueString}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while displaying other type limits: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected program error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
