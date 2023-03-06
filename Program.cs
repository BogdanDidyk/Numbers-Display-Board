namespace NumbersDisplayBoard
{
    public static class LongExtension
    {
        public static byte[] GetDigits(this long num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Input number is a negative number!");
            }

            List<byte> digits = new List<byte>();
            do
            {
                digits.Add((byte)(num % 10));
                num /= 10;
            }
            while (num > 0);

            digits.Reverse();
            return digits.ToArray();
        }
    }

    public static class NumbersDisplayBoard
    {
        // Character set for a seven-segment display
        private static Dictionary<byte, string[]> NumberSymbols = new Dictionary<byte, string[]>()
        {
            { 0, new string[] { " _ ", "| |", "|_|" } },
            { 1, new string[] { "   ", " | ", " | " } },
            { 2, new string[] { " _ ", " _|", "|_ " } },
            { 3, new string[] { " _ ", " _|", " _|" } },
            { 4, new string[] { "   ", "|_|", "  |" } },
            { 5, new string[] { " _ ", "|_ ", " _|" } },
            { 6, new string[] { " _ ", "|_ ", "|_|" } },
            { 7, new string[] { " _ ", "  |", "  |" } },
            { 8, new string[] { " _ ", "|_|", "|_|" } },
            { 9, new string[] { " _ ", "|_|", " _|" } }
        };

        public static void Show(long num, string separator = "   ")
        {
            byte[] digits = num.GetDigits();

            for (byte i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(separator, digits.Select(digit => NumberSymbols[digit][i])));
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            NumbersDisplayBoard.Show(26, "**");
            NumbersDisplayBoard.Show(0);
            NumbersDisplayBoard.Show(long.MaxValue);

            Console.ReadKey();
        }
    }
}