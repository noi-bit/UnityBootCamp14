using System;
using System.IO;
using UnityEngine;

//���� �� Json�� ���� ���ذ� �Ȱ��� ������ �� �õ��غô�
[Serializable]//����ȭ
public class BestScoreJson : MonoBehaviour
{
    public ScoreManager scoreManager;
    string savestring;

    [Serializable]//����ȭ
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

            Debug.Log("���� ������ ���� �ε�");
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
        string save = Path.Combine(Application.persistentDataPath, "data.json");
    
        File.WriteAllText(save, json);
        if(File.Exists(save))
        {
            Debug.Log("Save �Ϸ�");
        }
        savestring = save;
    }
}



