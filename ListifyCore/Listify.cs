namespace ListifyCore
{
    public class Listify
    {
        public int Start { get; }
        public int End { get; }
        public Listify(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();

                var value = Start + index;
                if (value > End) 
                    throw new IndexOutOfRangeException();

                return value;
            }
        }
    }
}
