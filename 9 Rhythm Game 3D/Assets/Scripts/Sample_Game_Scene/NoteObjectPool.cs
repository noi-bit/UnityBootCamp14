using System.Collections.Generic;
using UnityEngine;

public class NoteObjectPool : MonoBehaviour
{
    public GameObject note; //�������� �ִ´�
    public int noteCount; //�� ���� note����

    [SerializeField] private List<GameObject> notepool;

    void Awake()
    {
        notepool = new List<GameObject>();

        for (int i = 0;  i < noteCount; ++i)
        {
            var go = Instantiate(note);
            go.transform.parent = transform;
            go.SetActive(false);

            go.GetComponent<NotePrefab>().SetPool(this); //���� ������ ��Ʈ�� Ǯ�� "����"
            notepool.Add(go);
        }
    }
    
    public GameObject GetNote()
    {
        foreach(var go in notepool)
        {
            if (!go.activeInHierarchy)
            {
                go.SetActive(true);
                Debug.Log("GetNote" + go.transform.localScale); 

                return go;
            }
        }
        var Newgo = Instantiate(note);
        Newgo.transform.parent = transform;
        Newgo.GetComponent<NotePrefab>().SetPool(this);
        notepool.Add(Newgo);
        Newgo.SetActive(true);
        return Newgo;
    } 

    public void Return(GameObject note)
    {
        //note.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
        note.SetActive(false);
    }
}
