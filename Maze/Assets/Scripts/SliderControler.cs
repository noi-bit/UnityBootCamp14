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

        slider.wholeNumbers = true; //���� �����̴��� float������ �Ǿ��ִµ�, �� ������ ����ؼ� �������� �޾ƿ��� ��
        slider.minValue = 3; //�̷θ� ���� �� �ִ� �ּڰ�
        slider.maxValue = 51; //�ִ�
    }

    void SliderChange(float value)
    {
        if(value % 2 == 0)
           value++; //���� ���� ¦�����, Ȧ���� ���ش�

        SliderValueChange.Invoke(value); //�����̴��� �ٲ� ������ SliderValueChange.Invoke(value) ���ش� -> ���忡 �ִ� �Լ����� += ���ִ°Ű���?
    }
}
