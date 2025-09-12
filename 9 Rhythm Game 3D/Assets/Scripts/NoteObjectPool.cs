using System.Collections.Generic;
using UnityEngine;

public class NoteObjectPool : MonoBehaviour
{
    public GameObject note; //프리팹을 넣는다
    public int noteCount; //총 만들 note갯수

    [SerializeField] private List<GameObject> notepool;

    void Awake()
    {
        notepool = new List<GameObject>();

        for (int i = 0;  i < noteCount; ++i)
        {
            var go = Instantiate(note);
            go.transform.parent = transform;
            go.SetActive(false);
            go.GetComponent<NotePrefab>().SetPool(this); //새로 생성될 노트의 풀은 "여기"
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
                /*go의 위치 랜덤화 - 랜덤화하려면 여기서 위치정보를 가져오는게 빠르려나?*/
                return go;
            }
        }
        var Newgo = Instantiate(note);
        Newgo.transform.parent = transform;
        Newgo.GetComponent<NotePrefab>().SetPool(this);
        notepool.Add(Newgo);
        Newgo.SetActive(false);
        return Newgo;
    } 

    public void Return(GameObject note)
    {
        note.SetActive(false);
    }
}
