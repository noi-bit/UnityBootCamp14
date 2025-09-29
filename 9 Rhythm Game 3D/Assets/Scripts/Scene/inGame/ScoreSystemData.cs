using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;
    public int lv;

    public SaveData(int score, int lv)
    {
        this.score = score;
        this.lv = lv;
    }
    
}

public static class ScoreSystemData
{
    //������ ��ġ ����
    private static string Path => Application.persistentDataPath + "/saves/";
                                          //������ ���忡 ���� �ٸ���

    public static void Save(SaveData data, string playername)
    {
        //������ ��ΰ� �ִ��� Ȯ��
        if(!Directory.Exists(Path))
        {
            //���ٸ� ������ش�
            Directory.CreateDirectory(Path);
        }

        //��ü�� Json���·� ������ش� -> Json������ �ؽ�Ʈ�� ��� �ֱ�
        string saveJson = JsonUtility.ToJson(data);
        /*
         "SaveData"
         {
            "�����"
         }
         */

        //      --> c:/user/../{saves}/{playername}.json
        string saveFilePath = Path + playername + ".json"; 

        //����ִ� �ؽ�Ʈ�� ���� ���Ϸ� ������ֱ�
        File.WriteAllText(saveFilePath, saveJson);

    }

    public static SaveData Load(string filename)
    {
        string saveFilePath = Path + filename + ".json";

        //������ �ִ��� Ȯ��
        if(!File.Exists(saveFilePath))
        {
            Debug.LogError("���� ����");
            return null;
        }
        
        //���Ͽ��� �ؽ�Ʈ ���� �о����
        string saveFile = File.ReadAllText(saveFilePath);

        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
    
}
