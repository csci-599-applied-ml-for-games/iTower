using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class ClientStat
    {
        public static Stack<Node> finalPath = new Stack<Node>();
        public static  bool placeTower = false;
        public static Vector3 pos= new Vector3(0f, 0f, 0f);
        public static bool finishTower = false;
    }
}