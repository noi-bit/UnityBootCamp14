using System;
using System.Collections.Generic;
using UnityEngine;
using static InspectorAttributes;

public class PlayerStat : MonoBehaviour
{
    [Serializable]
    public class player
    {
        public Type magicaltype;
        public string name = "안녕?";
        public int age;
        public enum Type
        {
            디지털, 불, 번개, 물, 대지, 바람
        }

        public string speak = "만나서 반가워";
        [Space(10)]
        [TextArea(3, 5)]
        public string info = "...";
    }


    [Header("Mastersetting")]
    public string UserName;

    [ContextMenuItem("초기화", "playerReset")]
    public player magical_char;
    

    public void playerReset()
    {
        player newgirl = new player();

        newgirl.name = "이름을 지어줘";
        newgirl.magicaltype = player.Type.디지털;
        newgirl.speak = "만나서 반가워!";
        newgirl.info = "....";
        magical_char = newgirl;
    }
    [Space(30)]
    [Range(0, 100)] public int Scale;
    public enum musiclist
    {

    }
    [Space(30)]
    [Range(0, 100)] public int cute;
    public void Moving()
    {
    }
}

