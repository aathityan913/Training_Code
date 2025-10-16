

namespace csharp.training.congruent.apps
{
    // Custom exception for invalid even number
    public class EvenNumberException : Exception
    {
        public EvenNumberException(string message) : base(message)
        {
        }
    }

    // Custom data type that only accepts even unsigned integers
    public struct EvenUint
    {
        private uint _value;

        public uint Value
        {
            get => _value;
            set
            {
                if (value % 2 != 0)
                    throw new EvenNumberException("Only even numbers are allowed for EvenUint!");
                _value = value;
            }
        }

        // Constructor
        public EvenUint(uint value)
        {
            if (value % 2 != 0)
                throw new EvenNumberException("Only even numbers are allowed for EvenUint!");
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string s= Console.ReadLine();
            try
            {
                Console.Write("Enter an even unsigned integer: ");
                string input = Console.ReadLine();



            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"❌ Exception: {e.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format exception");
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
            }
        }
    }
}

