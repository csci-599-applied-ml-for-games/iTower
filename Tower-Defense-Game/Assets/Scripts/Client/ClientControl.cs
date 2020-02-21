using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


public class ClientControl
{
    private Socket clientSocket;

    public ClientControl()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Connect(string ip, int port)
    {
        clientSocket.Connect(ip, port);
        
    }

    public string Receive()
    {
        byte[] msg = new byte[1024];
        int msgLen = clientSocket.Receive(msg);
        // Debug.Log("server says: " + Encoding.UTF8.GetString(msg, 0, msgLen));
        return Encoding.UTF8.GetString(msg, 0, msgLen);
    }

    public void Send(string msg)
    {
        clientSocket.Send(Encoding.UTF8.GetBytes(msg));
    }
    
    public void sendPath(Stack<Node>finalPath)
    {
        // client.Send();
        List<String>lists = new List<string>();
        foreach (var coord in finalPath)
        {
            lists.Add(coord.GridPosition.x+" "+coord.GridPosition.y);
        }
        Send(String.Join(", ", lists.ToArray()));
    }
}