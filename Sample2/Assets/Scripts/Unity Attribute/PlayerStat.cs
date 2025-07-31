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
        public string name = "�ȳ�?";
        public int age;
        public enum Type
        {
            ������, ��, ����, ��, ����, �ٶ�
        }

        public string speak = "������ �ݰ���";
        [Space(10)]
        [TextArea(3, 5)]
        public string info = "...";
    }


    [Header("Mastersetting")]
    public string UserName;

    [ContextMenuItem("�ʱ�ȭ", "playerReset")]
    public player magical_char;
    

    public void playerReset()
    {
        player newgirl = new player();

        newgirl.name = "�̸��� ������";
        newgirl.magicaltype = player.Type.������;
        newgirl.speak = "������ �ݰ���!";
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

