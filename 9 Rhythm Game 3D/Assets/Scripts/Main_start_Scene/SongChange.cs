using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class SongChange : MonoBehaviour
{
    //»ç¿ëXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    int cur = 0;
    public GameObject[] list;
    void Start()
    {
        for (int i = 1; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[cur].SetActive(true);
    }

    public void SelectChangenext()
    {
        int next = (cur + 1) % list.Length;
        list[cur].SetActive(false);
        list[next].SetActive(true);

        cur = next;
    }
    public void SelectChangebefore()
    {
        int next = (cur - 1 + list.Length) % list.Length;
        list[cur].SetActive(false);
        list[next].SetActive(true);

        cur = next;
    }
}
