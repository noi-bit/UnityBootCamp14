using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//���� �� Json�� ���� ���ذ� �Ȱ��� ������ �� �õ��غô�
[Serializable]//����ȭ
public class BestScoreJson : MonoBehaviour
{
    public ScoreManager scoreManager;
    string path;
    public Text besttext;

    [Serializable]//����ȭ
    public class BestScoreData
    {
        public int best;
    }

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "data.json");
        int prevBest = 0;
        if (File.Exists(path))
        {
            string Bestscoreread = File.ReadAllText(path);

            BestScoreData loaded = JsonUtility.FromJson<BestScoreData>(Bestscoreread);
            prevBest = loaded.best;
            Debug.Log("���� ������ ���� �ε�");
            besttext.text = $"Best Score : {prevBest}";
        }
        else
        {
            Debug.LogWarning("����� Json ������ X");
        }
    }

    private void OnDisable()
    {
        BestScoreData data = new BestScoreData();
        data.best = scoreManager.bestcheck;

        string json = JsonUtility.ToJson(data, true);

        Debug.Log($"�� ���� ���� ��ġ :{Application.persistentDataPath}");
        path = Path.Combine(Application.persistentDataPath, "data.json");
    
        File.WriteAllText(path, json);
            Debug.Log("Save �Ϸ�");
        //if(File.Exists(path))
        //{
        //}
    }
}



