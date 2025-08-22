using UnityEngine;

public class ChangeBG : MonoBehaviour
{
    public GameObject[] Bg;
    int cur = 0;

    private void Start()
    {
        for(int i = 0; i < Bg.Length; i++)
        {
            Bg[i].SetActive(false);
        }
    }

    public void BackgroundChanger()
    {
        int next = (cur + 1) %Bg.Length;

        Bg[cur].SetActive(false);
        Bg[next].SetActive(true);

        cur = next;
    }
}
