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
    //저장할 위치 지정
    private static string Path => Application.persistentDataPath + "/saves/";
                                          //지정한 빌드에 따라 다르게

    public static void Save(SaveData data, string playername)
    {
        //지정한 경로가 있는지 확인
        if(!Directory.Exists(Path))
        {
            //없다면 만들어준다
            Directory.CreateDirectory(Path);
        }

        //객체를 Json형태로 만들어준다 -> Json형식을 텍스트로 들고 있기
        string saveJson = JsonUtility.ToJson(data);
        /*
         "SaveData"
         {
            "내용들"
         }
         */

        //      --> c:/user/../{saves}/{playername}.json
        string saveFilePath = Path + playername + ".json"; 

        //들고있는 텍스트를 실제 파일로 만들어주기
        File.WriteAllText(saveFilePath, saveJson);

    }

    public static SaveData Load(string filename)
    {
        string saveFilePath = Path + filename + ".json";

        //파일이 있는지 확인
        if(!File.Exists(saveFilePath))
        {
            Debug.LogError("파일 없음");
            return null;
        }
        
        //파일에서 텍스트 전부 읽어오기
        string saveFile = File.ReadAllText(saveFilePath);

        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
    
}
