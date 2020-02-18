using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System.Text;


namespace Client
{
    public class ClientMain
    {
        public ClientControl client;

        public void init()
        {
            client = new ClientControl();
            client.Connect("127.0.0.1", 8081);
            
            Thread threadReceive = new Thread(receive);
            threadReceive.IsBackground = true;
            threadReceive.Start();

           
        }
        

        public void send(string message)
        {
            client.Send(message);
        }

        public void sendPath(Stack<Node> path)
        {
            client.sendPath(path);
        }

        public List<Coordinate> toStackList(Stack<Node> path)
        {
            List<Coordinate>lists = new List<Coordinate>();
            foreach (var point in path)
            {
                Coordinate coordinate = new Coordinate(point.GridPosition.x, point.GridPosition.y);
                lists.Add(coordinate);
            }

            return lists;
        }

        private void receive()
        {
            while (true)
            {
                ClientStat.receivedMsg = client.Receive();
                Debug.Log(ClientStat.receivedMsg);
                if (!ClientStat.receivedMsg.Equals(""))
                {
                    ClientStat.finishTower = false;
                    TowerList myTower = parseJson(ClientStat.receivedMsg);
                    // string[] str = ClientStat.receivedMsg.Split(',');
                    // float[] floats = Array.ConvertAll(str, float.Parse);
                    for (int i = 0; i < myTower.tower_list.Count; i++)
                    {
                        ClientStat.pos = new Vector3(myTower.tower_list[i].x, myTower.tower_list[i].y, 0f);
                    }
                    
                    
                    ClientStat.placeTower = true;
                    ClientStat.nextWave = true;
                }
            }
        }

        public void writeJson()
        {
            // Create User object.
            var myWave = new Wave(ClientStat.money, ClientStat.lives, ClientStat.monsterList, ClientStat.towerList);

            // Create a stream to serialize the object to.
            var ms = new MemoryStream();

            // Serializer the User object to the stream.
            var ser = new DataContractJsonSerializer(typeof(Wave));
            ser.WriteObject(ms, myWave);
            byte[] json = ms.ToArray();
            ms.Close();
            send(Encoding.UTF8.GetString(json, 0, json.Length));
        }

// Deserialize a JSON stream to a User object.
        public TowerList parseJson(string json)
        {
            var myTower = new TowerList();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(myTower.GetType());
            myTower = ser.ReadObject(ms) as TowerList;
            ms.Close();
            return myTower;
        }
        
    }
}