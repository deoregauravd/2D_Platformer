using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset textJson;
    [System.Serializable] 

    public class player
    {
        public string name;
        public int health;
        public int power;
    }

    [System.Serializable]
    public class PlayerList
    {
        public player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    void Start()
    {
       // myPlayerList = JsonUtility.fromJson<PlayerList>(textJson.text);
      myPlayerList = JsonUtility.FromJson<PlayerList>(textJson.text);

    }
}

