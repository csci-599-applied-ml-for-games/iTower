using System.Collections.Generic;

namespace Client
{
    public class MonsterJson
    {
        public int type;
        public List<Coordinate> posList;

        public MonsterJson()
        {
            
        }

        public MonsterJson(int type, List<Coordinate> myList)
        {
            this.type = type;
            this.posList = myList;
        }
    }
}