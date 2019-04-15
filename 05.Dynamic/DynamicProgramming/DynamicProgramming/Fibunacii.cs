namespace DynamicProgramming
{
    public class Fibunacii
    {
        public static long[] numbers;

        public Fibunacii(int fibNum)
        {
            numbers = new long[fibNum + 1];

        }

        public long Fib(int n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var result = Fib(n - 1) + Fib(n - 2);

            numbers[n] = result;

            return result;
        }
    }
}
