namespace Assets.Scripts.Entities
{
    public class IDGenerator
    {
        private int nextId = 1;

        public int GenerateID()
        {
            return nextId++;
        }
    }
}