using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//��ȭ �ؽ�Ʈ ȣ�� ��ũ��Ʈ

[Serializable]//Ŭ������ �ν����Ϳ��� Ȯ���� �� �ִ�
public class Dialog//��ȭ 1���� ��� ������ Ŭ����
{
    public string character;
    public string content; //��ȭ �ؽ�Ʈ

    //Ŭ���� ���� �� ȣ��Ǵ� �޼ҵ�(������) : ��Ŭ�� - ���� �۾� �� �����丵 - ������ �����
    public Dialog(string character, string content)//Ŭ������ ����?�ϴ� ������(�Լ�) �ٵ� ���ʿ� void�� ������ �ʴ� ����?
    {                                               //�Ű������� �޾ƿ��� ���� �� Ŭ������ ������� ����� ���
        this.character = character;
        this.content = content;
        //this�� Ŭ���� �ڽ��� �ǹ�(�Ű������� �޾ƿ��� �̸��� ��������� �̸��� ���Ƽ� this�� �ٿ���)
        //Ŭ������ ���� ���� �Ű������� �̸��� ���Ƽ� �����ϱ� ���� �뵵
    }
}

public class DialogManager : MonoBehaviour //�Ŵ����� �� �ش� ����� ���� �Ŵ������ �����ִ°� ����?
{
    #region MonoSingleton


    //1) �ڱ� �ڽſ� ���� �ν��Ͻ��� ������(����)
    public static DialogManager Instance { get; private set; } //Ű���� ������Ƽ(�����ü��� ������ ������ ���� ����)
    //��> ??(����)static Istance ���� ���ü� �ִ� DialogManager ������ ������, set �����Ҽ� �ִ� ������ private��(������ �Ұ����� �ڵ�)�� get�Ѵ�??
    // Instance�� ���� ���� �� �ֽ��ϴ�(���� ����)
    // ������ �� �� X

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //�ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�. 
            DontDestroyOnLoad(gameObject); //DDOL : �ش� ��ġ�� �ִ� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ�(�� ��ũ��Ʈ�� �پ��ִ� ������Ʈ)
                                           //       ���� �����Ǵ� ���� ����}
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region field
    public GameObject panel;
    public TMP_Text character_name;
    public TMP_Text message;
    public float typing_speed;
    
    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog current;//������ ��ȭ ���� Ȯ��
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //�̺�Ʈ �ý��ۿ� ���޵� ���� �����ϰ�, �� ���� UI������ ������ ��Ȳ�̶��?
            if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;//�۾�X
            }//��ȭâ�� ���� �����ϰ�, "�� ��ȭâ �ȿ���" �����̽��ٸ� �������� "��ȭ �� ����"�� ��

            //�����̽� ������ ���������� �۾� ���� ���(��ȭ �Ŵ��� �ְ�, "��ȭ ��" ������ ���
            if(isTyping)//Ÿ���� ���̸�
            {
                CompleteLine();//���� �۾��� ���� ������
            }
            else
            {
                NextLine();//���� �������� �̵��մϴ�
            }
        }
    }

    /// <summary>
    /// List<T>�� Queue<T>ó�� ���� ������ �����͸� �� �Ű������� ���� �� �ֽ��ϴ�
    /// </summary>
    /// <param name="lines">��ȭ �����Ϳ� ���� ������ ���� ������</param>
    public void StartLine(IEnumerable<Dialog> lines)//IEnumerable : ������ �����͵��� �������ٶ� ���
    {//��ȭâ�� ���� ���ڿ��� ��ġ�ϰ� ��ȭâ�� Ű�� NextLine�� �ҷ���
        queue.Clear();
        foreach(var line in lines)
        {
            queue.Enqueue(line);
        }
        panel.SetActive(true);
        NextLine();
    }

    //���� �۾��� ���� �Լ�
    private void NextLine()
    {   
        //�۾��� ������ ���̻� ���ٸ�(==0)
        if(queue.Count == 0)
        {
            DialogueExit();//��ȭ�� ����
            return;
        }
        //ť�� ����� ���� �ϳ� ���ɴϴ�
        current = queue.Dequeue();
        character_name.text = current.character;//���� ��ȭ ���� ĳ���� �̸����� ����

        if (typing != null)
            StopCoroutine(typing);//�ڷ�ƾ�� �����ִ� ���¶�� �����ݴϴ�

        typing = StartCoroutine(TypingDialogue(current.content));//���� ��ȭ �������� ������(��ȭ ����)�� �������� ��ȭ Ÿ������ �����մϴ�
    }

    private IEnumerator TypingDialogue(string line)
    {
        isTyping = true;//Ÿ���� ���������� �˸�
        StringBuilder stringBuilder = new StringBuilder(line.Length);//�÷��� �ڵ� StringBuilder
        message.text = "";//���� ����

        foreach(char c in line)//string(���ڿ�)�� ����(char)�� �迭 �ȳ��ϼ���? �� ��+��+��+��+��+? �̷��� �� �ϳ� ���ھ� Ÿ����
        {
            //message.text += c;
            stringBuilder.Append(c);//Append�� ���ڵ�(c)�� ���ڿ��� ����
            message.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typing_speed); //0.1~1 ���� ������ ������ �־��� ��
        }
        isTyping = false;
    }

    //���
    private void CompleteLine()//���
    {
        if(typing != null)
            StopCoroutine(typing);

        message.text = current.content;
        isTyping = false;
    }

    private void DialogueExit()
    {
        panel.SetActive(false); //�г� ����
    }
}
