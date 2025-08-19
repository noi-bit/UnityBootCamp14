using System;
using System.IO;
using UnityEngine;

//수업 때 Json이 가장 이해가 안가서 연습할 겸 시도해봤다
[Serializable]//직렬화
public class BestScoreJson : MonoBehaviour
{
    public ScoreManager scoreManager;
    string savestring;

    [Serializable]//직렬화
    public class BestScoreData
    {
        public int best;
    }

    private void Start()
    {
        if(File.Exists(savestring))
        {
            string Bestscoreread = File.ReadAllText(savestring);

            BestScoreData loaded = JsonUtility.FromJson<BestScoreData>(Bestscoreread);

            Debug.Log("저장 데이터 무사 로드");
        }
        else
        {
            Debug.LogWarning("저장된 Json 데이터 X");
        }
    }

    private void OnDisable()
    {
        BestScoreData data = new BestScoreData();
        data.best = scoreManager.bestcheck;

        string json = JsonUtility.ToJson(data, true);

        Debug.Log($"현 저장 폴더 위치 :{Application.persistentDataPath}");
        string save = Path.Combine(Application.persistentDataPath, "data.json");
    
        File.WriteAllText(save, json);
        if(File.Exists(save))
        {
            Debug.Log("Save 완료");
        }
        savestring = save;
    }
}



