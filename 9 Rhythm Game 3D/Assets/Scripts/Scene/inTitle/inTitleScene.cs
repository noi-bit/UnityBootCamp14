using UnityEngine;
using UnityEngine.UI;

public class inTitleScene : BaseScene
{
    public Button Button_select;
    private Canvas selectCanvas;
    private bool isSelectCanvasActive = false;

    protected override void Init()
    {
        base.Init();

        SceneType = EnumData.Scene.inTitle;
        FindSelectCanvas();
        ButtonSetting();
    }
    private void FindSelectCanvas()
    {
        // ��� 1: GameObject.Find ��� (���� ����)
        GameObject selectCanvasGO = GameObject.Find("SelectCanvas");
        if (selectCanvasGO != null)
        {
            selectCanvas = selectCanvasGO.GetComponent<Canvas>();
            // �ʱ� ���� ����
            isSelectCanvasActive = selectCanvasGO.activeSelf;
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
            Button_select.onClick.RemoveAllListeners();
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
        GameManager.MoveScene.LoadScene(EnumData.Scene.inGame);
    }

    public override void Clear()
    {
        Debug.Log($"{SceneType} Clear �Ϸ�");
    }

}
