using System.Collections;
using UnityEngine;
//4��° ��ũ��Ʈ

public class CoroutineSample : MonoBehaviour
{
    // ������ Ÿ��
    public GameObject target;

    // ��ȭ �ð�
    float duration = 5f;

    // ��ȭ�� ��
    public Color color;

    void Start()
    {
        // Ÿ���� �����Ǿ��ִٸ�
        if(target != null)
        {
            StartCoroutine(ChangeColor());
            // 1. StartCoroutine(�޼ҵ��()); : IEnumerator ������ �޼ҵ带 �ڷ�ƾ���� ����
            // �ڵ��ۼ� �������� �޼ҵ尡 �����Ǿ� ������
            //  ��> �޼ҵ� ȣ���� ������ �������� Ȯ�εǱ⿡ ã�� �����ϴ� �ð��� ���ڿ����� ���� ���

            // 2. StartCoroutine("ChangeColor"); , StartCoroutine("�޼ҵ��");
            // ���ڿ��� ���� �Ű������� ���� �ڷ�ƾ�� ȣ���� �� �ִ�
            // ���������� �޼ҵ��� �̸��� ���ڿ��� ���� ��, ��Ÿ�ӿ��� ã�Ƽ� �����ϴ� ���(���÷���)
            //  ��> Ÿ�� üũ�� ���� �ʾ� �߸��� �̸��� ���� ��Ÿ�� ���� �߻�
        }
        else
        {
            Debug.Log("���� Ÿ���� ��ϵ��� ���� �����Դϴ�");
        }
    }

    IEnumerator ChangeColor() 
    {
        // Coroutine = StartCoroutine(ChangeColor());
        // StopCoroutine(coroutine);
        // StopCoroutine("ChangeColor"); -- �Ű������� �ִ� �Լ��� ����Ҽ� ���� ���
        // StopAllCoroutines(); -- ��� �ڷ�ƾ�� ���� ����(���� ���ӿ�����Ʈ���� ��������)

        // Ÿ�����κ��� ������ ������Ʈ�� ���� ���� ����
        var targetRenderer = target.GetComponent<Renderer>();

        if (targetRenderer == null)// ������ Ÿ���� �������� ���� ���
        {
            Debug.LogWarning("�������� ������ ���߽��ϴ�.(NULL)");
            yield break;// �۾� �ߴ� 
        } // targetRenderer �� null �� �ƴҰ��..(���� yield break�� Null �� �ߴ��ϱ� ����)

        float time = 0.0f;

        var start = targetRenderer.material.color;// Ÿ���� �������� ���� ��Ƽ������ ���� ���
        var end = color;

        // �ݺ��۾�
        // �ڷ�ƾ ������ �ݺ����� �����ϸ�, yield�� ���� ���������ٰ� �ٽ� ���ƿͼ� �ݺ����� �����ϰ� ��
        while(time< duration)
        {
            time += Time.deltaTime;
            var value = Mathf.PingPong(time, duration) / duration;
            // Mathf.PingPong(a,b)
            // �־��� ���� a�� b���̿��� �ݺ��ϴ� ���� ����(�⺻���� �պ� �)
            // �� 0���� 1������ ��ȭ ���� ���˴ϴ�
            // ����ȭ �۾��� �����ϴ� ���� : color�� 0���� 1������ ���̱� ����

            targetRenderer.material.color = Color.Lerp(start, end, value);// ���� ���� �ε巯�� ����

            yield return null; // null������ yield�� �����ϸ� ���� �����ӱ��� ��� �Ѵٴ� �ǹ�
                               // ���� �����ӿ� �ٽ� while�� �����(time<duration ����)
            //yield return new WaitForSeconds(1f);// - 1�ʸ��� yield�� ȣ���Ŵ
            Debug.Log("�� �������� �������");
        }
    }
    // �ڷ�ƾ : ���� ���
    // StopCoroutine(�ڷ�ƾ ��ü);
}
