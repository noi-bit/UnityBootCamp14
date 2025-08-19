using System.Collections; //�ڷ�ƾ ���� �ʿ���
using UnityEngine;

//����Ƽ -Life Cycle �� ���� ���� ���� Ȯ�� �ڵ�
//Update�� Ȱ���� ������ �� ȣ���� ������� Ȯ���غ���!


public class LifeCycleTester : MonoBehaviour
{
    private float count_per_frame = 0; //������ ���� ȣ�� ī��Ʈ
    
    private void Awake()
    {
        Debug.Log("[Awake] ������Ʈ�� \"����\" �� �� �ѹ��� ����˴ϴ�");
    }

    private void OnEnable()
    {
        Debug.Log("[OnEnable] ������Ʈ�� \"Ȱ��ȭ\" �� ȣ��Ǵ� ����");
    }

    void Start()
    {
        Debug.Log("[Start] ù ������ \"���� ��\" �� ȣ��Ǵ� ����");
        StartCoroutine(CustomCoroutine()); //�ڷ�ƾ ����
    }

    private void FixedUpdate()
    {
        Debug.Log($"Frame : {count_per_frame} [FixedUpdate] ������ ���� ������Ʈ�� ����Ǵ� ����");

    }

    void Update()
    {
        count_per_frame ++;


        Debug.Log($"Frame : {count_per_frame} [Update] ���� ������ ���� ȣ���� (\"������ ����\")����Ǵ� ����");

        if(count_per_frame ==3)
        {
            Debug.Log($"Frame : {count_per_frame} Test 1 - ������Ʈ�� ��Ȱ��ȭ �۾��� �����մϴ�");
            gameObject.SetActive(false);
        }
        if(count_per_frame == 6)
        {
            Debug.Log($"Frame : {count_per_frame} Test 2 - ������Ʈ�� Ȱ��ȭ �۾��� �����մϴ�");
            gameObject.SetActive(true);
        }
        if(count_per_frame == 9)
        {
            Debug.Log($"Frame : {count_per_frame} Test 3 - ������Ʈ�� �ı� �۾��� �����մϴ�");
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        Debug.Log($"Frame : {count_per_frame} [LateUpdate] ���� ����, ���� ������ ��ó��");
    }

    //�ڷ�ƾ ���� using System.Collections;
    //yield�� ���� ��� �� ����Ŭ�� ���ƿ��� ������ �����ϸ�, ���� Update(fixed, late����)�� ƴ���� ������ �����
    IEnumerator CustomCoroutine()
    {
        Debug.Log("[Coroutine] �ڷ�ƾ�� ���� ���� : StartCoroutine");
        yield return null;//�� ������ ���
        Debug.Log("[Coroutine] [yield return null] 1 ������ �� �ٽ� ����˴ϴ�");

        yield return new WaitForSeconds(3.0f); //3�ʿ� ���� ���
        Debug.Log("[Coroutine] [WaitForSeconds] 3 �� �� �ٽ� ����˴ϴ�");

        yield return new WaitForFixedUpdate();
        Debug.Log("[Coroutine] [WaitForFixedUpdate] FixedUpdate�� ������ �ٽ� ����˴ϴ�");
        
        yield return new WaitForEndOfFrame();
        Debug.Log("[Coroutine] [WaitForEndOfFrame] �������� ���� ������ �ٽ� ����˴ϴ�");
    }

    private void OnDisable()
    {
        Debug.Log("[OnDisable] ������Ʈ�� ��Ȱ��ȭ �� ��� ȣ��Ǵ� ����");
    }

    private void OnDestroy()
    {
        Debug.Log("[OnDestroy] ������Ʈ�� �ı��Ǿ��� ��� ȣ��Ǵ� ����");
        //�� ��ġ������ �ı� ������ ����Ǳ� ������, ������ ���� �۾� �Ұ���, �ǹ�X
        //��>> gameObject.SetActive(true / false) - ������ �ǵ� ���������� �ǹ�X(���� ���濡 ���� ó���� �ı� �� �ܰ迡�� ó��)
        //�ڱ� �ڽſ� ���� ���� �۾� �Ұ���, ��� �ı���
        //���ο� ���� ������Ʈ�� �����ϴ� �۾��� ����
    }
}
