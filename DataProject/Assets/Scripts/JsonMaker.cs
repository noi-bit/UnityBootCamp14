using System;
using System.IO;
using UnityEngine;

public class JsonMaker : MonoBehaviour
{
    [Serializable]
    public class QuestData
    {
        public string quest_name;
        public string reward;
        public string description;
    }

    [Serializable]
    public class QuestList
    {
        public QuestData[] quests;
    }

    private void Start()
    {
        //1) ������ ��ü�� ���� �ʱ�ȭ �۾�
        QuestList list = new QuestList()
        {
            quests = new QuestData[]
            {
                //new �����ڸ�() { �ʵ�� = ��, �ʵ��2 = ��2...} �ش� ������ ���� ���� Ŭ���� ��ü�� �����˴ϴ�.
                new QuestData() { quest_name = "������ ���̴�.", reward = "exp + 100", description = "���ۺ��� �غ�."},

                new QuestData() { quest_name = "�߰��� �ض�.", reward = "exp + 150", description = "�߰��̶� �ϴ°� ����."},

                new QuestData() { quest_name = "�ҰŸ� ������ �ض�.", reward = "exp + 500", description = "�׳� �� ��."}

            }
        };

        #region save ������
        //2) JsonUtility.ToJson(Object, pretty_print); �� ���� C#�� ��ü�� JSON���� ��������
        //��>>JsonUtility.ToJson(Object, pretty_print): ����ȭ ����� ���� �Լ�
        //ToJson(��ü)�� �ش� ��ü�� JSON���ڿ��� �������ִ��ڵ�
        //true�� �߰��� ���, �鿩����� �ٹٲ��� ���Ե� ������ json ���Ϸ� ��������
        //false�� ���ų� �����ϴ� ���, ���� �� �ٷ� ����� json ���Ϸ� �����˴ϴ�
        string json = JsonUtility.ToJson(list, true);

        //3) ���� ��ο� ���� �ۼ��� �����մϴ�.
        Debug.Log($"�� ���� ���� ��ġ :{Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "quests.json");
        //Path.Combine(string path1, string path2);
        //��>> �� ����� ���ڿ��� �ϳ��� ��η� ������ִ� ����� ������ �ֽ��ϴ�.
        //������ġ/���ϸ� ���� ���� ���˴ϴ�.

        //Application.persistentDataPath : ����Ƽ�� �� �÷������� �����ϴ� ���� ���� ������ ���� ���

        //4) �ش� ��ο� ������ �ۼ�
        File.WriteAllText(path, json);
        //C# ������ 723p : System.IO ���ӽ����̽�
        //          725p : Path Ŭ������ ���� ���� �̸�, Ȯ����, ���� ���� ��� ���
        //          733p : Json �����Ϳ� ���� ����

        
        Debug.Log("Json ���� ���� �Ϸ�");
        #endregion

        #region loadJsonFile
        //=======================���� �ε�====================
        //1) �ش� ��ο� ������ �����ϴ��� �Ǵ�

        if(File.Exists(path)) //path ��ο� ���� �ִ��� Ȯ��
        {
            //���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�
            string json2 = File.ReadAllText(path);
            
            QuestList loaded = JsonUtility.FromJson<QuestList>(json2);
            //var jsontext = Resources.Load<TextAsset>("data");

            Debug.Log($"����Ʈ ���� : {loaded.quests[0].quest_name}");//quest�� 0(1��°) �迭�� - quest_name�� �����ؼ� ����׷� �̴´�
            Debug.Log($"����Ʈ ���� : {loaded.quests[0].reward}");
        }
        else
        {
            Debug.LogWarning("�ش� ��ο� ����� JSON������ �����ϴ�.");
        }
        #endregion
    }
}
