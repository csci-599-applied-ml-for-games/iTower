using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Json;

namespace Client
{
    public class ClientStat
    {
        public static Stack<Node> finalPath = new Stack<Node>();
        public static  bool placeTower = false;
        public static Vector3 pos= new Vector3(0f, 0f, 0f);
        public static bool finishTower = true;
        public static string receivedMsg = "";//for test only
        public static int money = 0;
        public static int lives = 0;
        public static bool nextWave = false;
        public static bool sendJson = false;
        public static List<MonsterJson>monsterList=new List<MonsterJson>();
        public static List<TowerJson>towerList = new List<TowerJson>();
        
    }
}