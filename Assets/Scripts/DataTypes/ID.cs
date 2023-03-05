namespace DataTypes
{
    public class ID
    {
        private static int nextID = 0;

        public int Value { get; }

        public ID()
        {
            Value = nextID;
            nextID++;
        }

        public static implicit operator int(ID id) { return  id.Value; }
    }
}