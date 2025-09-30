using UnityEngine;
using UnityEngine.UI;

public class inTitleScene : BaseScene
{
    [Header("UI Reference")]
    public Button Button_select;

    private SelectCanvas selectCanvas;
    private bool isSelectCanvasActive = false;

    protected override void Init()
    {
        base.Init();

        SceneType = EnumData.Scene.Title;
        FindSelectCanvas();
        ButtonSetting();
        selectCanvas.goGame += MoveScene;
    }
    private void FindSelectCanvas()
    {
        // 방법 1: GameObject.Find 사용 (가장 간단)
        GameObject selectCanvasGO = GameObject.Find("SelectCanvas");
        if (selectCanvasGO != null)
        {
            selectCanvas = selectCanvasGO.GetComponent<SelectCanvas>();
            // 초기 상태 저장
            //isSelectCanvasActive = selectCanvasGO.activeSelf;
            selectCanvas.gameObject.SetActive(isSelectCanvasActive);
        }
        else
        {
            Debug.LogError("SelectCanvas를 찾을 수 없습니다!");
        }
    }
    
    void ButtonSetting()
    {
        if (Button_select != null)
        {
            Button_select.onClick.RemoveAllListeners(); //한번 지워주고
            Button_select.onClick.AddListener(ToggleSelectCanvas);
            //Button_select.onClick.AddListener(MoveScene);
        }
    }
    private void ToggleSelectCanvas()
    {
        if (selectCanvas != null)
        {
            // 현재 상태의 반대로 설정
            isSelectCanvasActive = !isSelectCanvasActive;
            selectCanvas.gameObject.SetActive(isSelectCanvasActive);

            Debug.Log($"SelectCanvas 상태: {(isSelectCanvasActive ? "활성화" : "비활성화")}");
        }
    }

    void Update()
    {
        //여기에 씬 이동하는 버튼을 등록해야하나?
        //그러면 멤버변수로 버튼을 등록하고, start에서 addlistener한다음 button.onclick.이렇게?
        //GameManager.MoveScene.LoadScene(Define.Scene.Game);
    }
    protected override void MoveScene()
    {
        base.MoveScene();
        GameManager.MoveScene.LoadScene(EnumData.Scene.Game);
    }

    public override void Clear()
    {
        Debug.Log($"{SceneType} Clear 완료");
    }
    private void OnDestroy()
    {
        selectCanvas.goGame -= MoveScene;
    }

}
