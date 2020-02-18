using System.Collections.Generic;

namespace Client
{
    public class TowerList
    {
        public List<TowerJson> tower_list;

        public TowerList()
        {
            
        }

        public TowerList(List<TowerJson>myList)
        {
            this.tower_list = myList;
        }
    }
}