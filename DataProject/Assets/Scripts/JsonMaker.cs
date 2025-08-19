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
        //1) 설계한 객체에 대한 초기화 작업
        QuestList list = new QuestList()
        {
            quests = new QuestData[]
            {
                //new 생성자명() { 필드명 = 값, 필드명2 = 값2...} 해당 형태의 값을 가진 클래스 객체가 생성됩니다.
                new QuestData() { quest_name = "시작이 반이다.", reward = "exp + 100", description = "시작부터 해봐."},

                new QuestData() { quest_name = "중간만 해라.", reward = "exp + 150", description = "중간이라도 하는게 어디야."},

                new QuestData() { quest_name = "할거면 끝까지 해라.", reward = "exp + 500", description = "그냥 다 해."}

            }
        };

        #region save 저장기능
        //2) JsonUtility.ToJson(Object, pretty_print); 를 통해 C#의 객체를 JSON으로 변경해줌
        //ㄴ>>JsonUtility.ToJson(Object, pretty_print): 직렬화 기능을 가진 함수
        //ToJson(객체)는 해당 객체를 JSON문자열로 변경해주는코드
        //true를 추가할 경우, 들여쓰기와 줄바꿈이 포함된 형식의 json 파일로 설정해줌
        //false를 쓰거나 생략하는 경우, 전부 한 줄로 압축된 json 파일로 설정됩니다
        string json = JsonUtility.ToJson(list, true);

        //3) 저장 경로에 대한 작성을 진행합니다.
        Debug.Log($"현 저장 폴더 위치 :{Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "quests.json");
        //Path.Combine(string path1, string path2);
        //ㄴ>> 두 경로의 문자열을 하나의 경로로 만들어주는 기능을 가지고 있습니다.
        //저장위치/파일명 으로 자주 사용됩니다.

        //Application.persistentDataPath : 유니티가 각 플랫폼마다 제공하는 영구 저장 가능한 폴더 경로

        //4) 해당 경로에 파일을 작성
        File.WriteAllText(path, json);
        //C# 교과서 723p : System.IO 네임스페이스
        //          725p : Path 클래스를 통해 파일 이름, 확장자, 폴더 정보 얻는 방법
        //          733p : Json 데이터에 대한 설명

        
        Debug.Log("Json 파일 저장 완료");
        #endregion

        #region loadJsonFile
        //=======================파일 로드====================
        //1) 해당 경로에 파일이 존재하는지 판단

        if(File.Exists(path)) //path 경로에 값이 있는지 확인
        {
            //파일 텍스트를 전부 읽어서 문자형 데이터로 변경합니다
            string json2 = File.ReadAllText(path);
            
            QuestList loaded = JsonUtility.FromJson<QuestList>(json2);
            //var jsontext = Resources.Load<TextAsset>("data");

            Debug.Log($"퀘스트 수락 : {loaded.quests[0].quest_name}");//quest의 0(1번째) 배열의 - quest_name에 접근해서 디버그로 뽑는다
            Debug.Log($"퀘스트 보상 : {loaded.quests[0].reward}");
        }
        else
        {
            Debug.LogWarning("해당 경로에 저장된 JSON파일이 없습니다.");
        }
        #endregion
    }
}
