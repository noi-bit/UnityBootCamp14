using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text gameTitle;
    public Vector3 Titlelastposition;
    public float speed = 1000f;

    RectTransform titleRT;
    RectTransform songRT;

    public Button SongSelect;
    public Vector3 Selectlastposition;
    //public Button GameStart;

    void Start()
    {
        titleRT = (RectTransform)gameTitle.rectTransform;
        songRT = (RectTransform)SongSelect.transform;
    }

    void Update()
    {
        UIMove(UIis.gameTitle);
        if (titleRT.anchoredPosition.y <= (Selectlastposition.y*0.7))
        { UIMove(UIis.SongSelect); }
    }

    public enum UIis
    {
        gameTitle,
        SongSelect
    }

    void UIMove(UIis ui)
    {
        switch (ui)
        {
            case UIis.gameTitle:
                titleRT.anchoredPosition = Vector3.MoveTowards(titleRT.anchoredPosition, Titlelastposition, speed * Time.deltaTime);
                break;
            case UIis.SongSelect:
                songRT.anchoredPosition = Vector3.MoveTowards(songRT.anchoredPosition, Selectlastposition, speed * Time.deltaTime);
                break;
        }
    }
}
