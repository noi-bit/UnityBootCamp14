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
        // ��� 1: GameObject.Find ��� (���� ����)
        GameObject selectCanvasGO = GameObject.Find("SelectCanvas");
        if (selectCanvasGO != null)
        {
            selectCanvas = selectCanvasGO.GetComponent<SelectCanvas>();
            // �ʱ� ���� ����
            //isSelectCanvasActive = selectCanvasGO.activeSelf;
            selectCanvas.gameObject.SetActive(isSelectCanvasActive);
        }
        else
        {
            Debug.LogError("SelectCanvas�� ã�� �� �����ϴ�!");
        }
    }
    
    void ButtonSetting()
    {
        if (Button_select != null)
        {
            Button_select.onClick.RemoveAllListeners(); //�ѹ� �����ְ�
            Button_select.onClick.AddListener(ToggleSelectCanvas);
            //Button_select.onClick.AddListener(MoveScene);
        }
    }
    private void ToggleSelectCanvas()
    {
        if (selectCanvas != null)
        {
            // ���� ������ �ݴ�� ����
            isSelectCanvasActive = !isSelectCanvasActive;
            selectCanvas.gameObject.SetActive(isSelectCanvasActive);

            Debug.Log($"SelectCanvas ����: {(isSelectCanvasActive ? "Ȱ��ȭ" : "��Ȱ��ȭ")}");
        }
    }

    void Update()
    {
        //���⿡ �� �̵��ϴ� ��ư�� ����ؾ��ϳ�?
        //�׷��� ��������� ��ư�� ����ϰ�, start���� addlistener�Ѵ��� button.onclick.�̷���?
        //GameManager.MoveScene.LoadScene(Define.Scene.Game);
    }
    protected override void MoveScene()
    {
        base.MoveScene();
        GameManager.MoveScene.LoadScene(EnumData.Scene.Game);
    }

    public override void Clear()
    {
        Debug.Log($"{SceneType} Clear �Ϸ�");
    }
    private void OnDestroy()
    {
        selectCanvas.goGame -= MoveScene;
    }

}
