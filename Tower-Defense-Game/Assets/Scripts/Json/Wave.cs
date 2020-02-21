using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Client
{
    public class Wave
    {
        public int money;
        public int lives;
        public List<MonsterJson> monsterList;
        public List<TowerJson> towerList;
        public string status = "ok";

        public Wave()
        {
            
        }
        public Wave(int money, int lives, List<MonsterJson>monsterList, List<TowerJson>towerList)
        {
            this.money = money;
            this.lives = lives;
            this.monsterList = monsterList;
            this.towerList = towerList;
        }

    }
}