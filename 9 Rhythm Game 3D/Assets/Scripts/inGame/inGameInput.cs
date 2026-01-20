using System;
using System.Collections.Generic;
using UnityEngine;

public class inGameInput : MonoBehaviour
{
    public List<PAD> padList = new List<PAD>();
    public Action buttonAction;

    private void Start()
    {
        InitializePads();
        //-> 뭐 이런식으로 액션받음? buttonAction.Invoke(padInfos[0]);
    }

    private void Update()
    {
        if (GameManager._isGameStart == false) return;
        foreach (var pad in padList)
        {
            PADpushUpdate(pad);
        }
        
    }
    void InitializePads()
    {
        padList.Clear();

        for(int i = 0; i < 9; i++)
        {
            var go = GameObject.Find((i+1).ToString());
            if (go == null) continue;

            PAD pad = go.GetComponent<PAD>();
            padList.Add(pad);
        }
    }
    //void InitializePads()
    //{
    //    foreach (PAD pad in padList)
    //    {
    //        if (pad.NoteButton != null)
    //        {
    //            pad.rb = pad.NoteButton.GetComponent<Rigidbody>();
    //            if (pad.rb != null)
    //            {
    //                Debug.Log($"{pad.NoteButton.name} is null");
    //            }
    //            pad.originposition = pad.NoteButton.transform.position;
    //        }
    //    }
    //}
    //void noi()
    //{
    //    foreach(PAD pad in padList)
    //    {
    //        if (pad.NoteButton == null) Debug.Log($"{pad.NoteButton.name} is null");
    //        return;
    //    }
       
    //}

    void PADpushUpdate(PAD pad)
    {
        if (Input.GetKeyDown(pad.ButtonKey))
        {
            pad._pressed = true;
            pad.Push(pad._pressed);
        }
        if (Input.GetKeyUp(pad.ButtonKey))
        {
            pad._pressed = false;
            pad.Push(pad._pressed);
        }
    }

    //void PADpush()
    //{
    //    foreach (PAD padInfo in padList)
    //    {
    //        //padInfo.pushValue = 0.1f;
    //        var target = padInfo._pressed ?
    //            padInfo.originposition + new Vector3(0, -padInfo.pushValue, 0) : padInfo.originposition;
    //        padInfo.rb.MovePosition(target);
    //    }
    //}

    public void OnUpdate()
    {
        if(buttonAction != null)
        {
            buttonAction.Invoke();
        }
    }
    public void Clear()
    {
    }
}
