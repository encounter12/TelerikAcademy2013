namespace AdapterPattern
{
    public class GameObjectAdapter : GameObject
    {
        private readonly AdapteeGameObject legacyGameObject = new AdapteeGameObject();

        public override void Translate(Vector3 position)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int z = (int)position.Z;

            legacyGameObject.MoveToLocation(x, y, z);
        }
    }
}