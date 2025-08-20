using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static BestScoreJson;

public class LoadingBestScoreJson : MonoBehaviour
{
    public Text text;
    public BestScoreJson bestScoreJson;

    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.json");
        int prevBest = 0;
        if (File.Exists(path))
        {
            string jsonRead = File.ReadAllText(path);
            BestScoreData loaded = JsonUtility.FromJson<BestScoreData>(jsonRead);
            prevBest = loaded.best;
        }
        //if (File.Exists(path))
        //{
        //    string json2 = File.ReadAllText(path);

        //    bestScoreJson = JsonUtility.FromJson<BestScoreJson>(json2);
        //    text.text = $"{bestScoreJson}";
        //}
        else
        {
            Debug.LogWarning("JSON파일을 찾을 수 없다.");
        }
    }

    
}
