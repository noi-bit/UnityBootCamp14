using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    public Action<float> SliderValueChange;

    private void Start()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(SliderChange);

        slider.wholeNumbers = true; //현재 슬라이더는 float값으로 되어있는데, 이 문법을 사용해서 정수값만 받아오게 함
        slider.minValue = 3; //미로를 만들 수 있는 최솟값
        slider.maxValue = 51; //최댓값
    }

    void SliderChange(float value)
    {
        if(value % 2 == 0)
           value++; //만약 값이 짝수라면, 홀수로 해준다

        SliderValueChange.Invoke(value); //슬라이더가 바뀔 때마다 SliderValueChange.Invoke(value) 해준다 -> 보드에 있는 함수들을 += 해주는거겠지?
    }
}
