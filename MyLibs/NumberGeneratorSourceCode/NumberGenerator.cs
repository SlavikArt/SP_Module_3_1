namespace NumberGenerator
{
    public abstract class NumberGenerator
    {
        protected int lowerBound;
        protected int upperBound;
        protected List<int> numbers;
        protected volatile bool isCancelled;

        public NumberGenerator(int lowerBound = 0, int upperBound = int.MaxValue)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            isCancelled = false;
            numbers = new List<int>();
        }

        public void Stop()
        {
            isCancelled = true;
        }

        public List<int> GetNumbers()
        {
            return numbers;
        }

        public void PrintNumbers()
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }

        public abstract void Generate();
    }
}
