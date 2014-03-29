namespace AdapterPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameObject go = new GameObjectAdapter();
            go.Translate(new Vector3 { X = 5, Y = 1, Z = -20 });
        }
    }
}