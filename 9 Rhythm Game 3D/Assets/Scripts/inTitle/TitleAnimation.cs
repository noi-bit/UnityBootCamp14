using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public Animation Title;
    public Animation SelectButton;
    //public Animation TitleAnim;
    //public Animation SelectButtonAnim;

    bool Animstart = false;

    void Awake()
    {
        Title.gameObject.SetActive(true);
        SelectButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        if (Animstart == true) return;
        Animstart = true;
        StartCoroutine(TitleCoroutine());
    }

    private IEnumerator TitleCoroutine()
    {
        Debug.Log("Title");
        Title.Play();
        yield return new WaitForSeconds(1.5f);
        //SelectButton.Play("Select Button");
        StartCoroutine(ButtonCoroutine());
        yield return null;
    }
    private IEnumerator ButtonCoroutine()
    {
        Debug.Log("SelectButton");
        SelectButton.Play();
        yield return null;
    }
}
