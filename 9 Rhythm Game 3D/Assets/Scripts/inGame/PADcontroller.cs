using UnityEngine;
using System.Collections;

//패드의 움직임 코드
public class PADcontroller : MonoBehaviour
{
   
    public UIManager _uimanager;

    public void NoteHitTiming(EnumData.NotePressMode pressmode)
    {
        switch (pressmode)
        {
            case EnumData.NotePressMode.Miss:
                _uimanager.SliderScore(-10);
                _uimanager.JudgeText.color = Color.red;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Good:
                _uimanager.SliderScore(3);
                _uimanager.JudgeText.color = Color.orange;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Great:
                _uimanager.SliderScore(5);
                _uimanager.JudgeText.color = Color.yellow;
                _uimanager.SeterrorMsText(pressmode);
                break;

            case EnumData.NotePressMode.Perfect:
                _uimanager.SliderScore(10);
                _uimanager.JudgeText.color = Color.green;
                _uimanager.SeterrorMsText(pressmode);
                break;
        }
    }
    
}
