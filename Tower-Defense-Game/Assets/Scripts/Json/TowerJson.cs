namespace Client
{
    public class TowerJson
    {
        public int type;
        public float x;
        public float y;

        public TowerJson()
        {
            
        }

        public TowerJson(float x, float y, int type)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }
}