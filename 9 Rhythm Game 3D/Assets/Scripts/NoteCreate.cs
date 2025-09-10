using UnityEngine;

public class NoteCreate : MonoBehaviour
{
    public GameObject cube;
    public GameObject[] cubeposition;

    private GameObject lastCube;
    public Metronome metronome;

    void Start()
    {
        metronome.create += CreateCube;
    }

    void Update()
    {
        //buttoninPut();
    }


    void CreateCube()
    {
        CreateCube(cubeposition[Random.Range(0, 9)].transform.position);
    }
    void CreateCube(Vector3 position)
    {
        lastCube = Instantiate(cube, position, Quaternion.identity);
    }

    //void buttoninPut()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if(lastCube!= null)
    //        lastCube.SetActive(false);
    //    }
    //}
}
