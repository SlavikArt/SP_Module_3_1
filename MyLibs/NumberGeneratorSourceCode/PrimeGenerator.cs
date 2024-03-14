namespace NumberGenerator
{
    public class PrimeGenerator : NumberGenerator
    {
        public PrimeGenerator(int lowerBound = 0, int upperBound = int.MaxValue) 
            : base(lowerBound, upperBound) { }

        public override void Generate()
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (isCancelled)
                    break;

                if (IsPrime(i))
                    numbers.Add(i);
            }
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;
            return true;
        }
    }
}
