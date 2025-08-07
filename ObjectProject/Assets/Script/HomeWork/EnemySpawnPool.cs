using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemySpawnPool : MonoBehaviour
{
    public GameObject Enemypool;
    public int Enemynumber = 20;

    private List<GameObject> EnemypoolList;

    private void Start()
    {
        EnemypoolList = new List<GameObject>();

        for (int i = 0; i < Enemynumber; i++)
        {
            var enemy = Instantiate(Enemypool);
            enemy.transform.parent = transform;

            enemy.SetActive(false);

            //enemy.GetComponent<EnemyMoveAI>().EnemyPool(this);
            EnemypoolList.Add(enemy);
        }

    }
}
