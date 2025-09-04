using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    public Action<float> SliderValueChange;

    private void Start()
    {
        Slider slider = gameObject.GetComponent<Slider>();

        slider.minValue = 3;
        slider.maxValue = 51;

        slider.wholeNumbers = true;
        slider.onValueChanged.AddListener(SliderChange);
        
    }

    void SliderChange(float value)
    {
        if(value % 2 == 0)
           value++; //만약 값이 짝수라면, 홀수로 해준다

        SliderValueChange.Invoke(value); //슬라이더가 바뀔 때마다 SliderValueChange.Invoke(value) 해준다 -> 보드에 있는 함수들을 += 해주는거겠지?
    }
}
