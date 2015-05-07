namespace SortNames.Core
{
    public class Name
    {
        public Name()
        {
        }

        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public string First { get; set; }

        public string Last { get; set; }

        /// <summary>
        /// Enables unit test equality assertion
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            var toCompareWith = other as Name;
            if (toCompareWith == null) return false;

            return First == toCompareWith.First &&
                Last == toCompareWith.Last;
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Last.GetHashCode();
        }
    }
}
