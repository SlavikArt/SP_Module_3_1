namespace NumberGenerator
{
    public class FibonacciGenerator : NumberGenerator
    {
        public FibonacciGenerator(int lowerBound = 0, int upperBound = int.MaxValue)
            : base(lowerBound, upperBound) { }

        public override void Generate()
        {
            int a = lowerBound;
            int b = 1;
            while (a <= upperBound)
            {
                if (isCancelled)
                    break;

                numbers.Add(a);

                int temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}
