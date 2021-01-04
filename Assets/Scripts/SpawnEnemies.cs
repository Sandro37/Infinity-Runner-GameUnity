using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public List<GameObject> enemiesList = new List<GameObject>();
    private float tempoContagem;
    public float spawnTempo;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        tempoContagem += Time.deltaTime;

        if (tempoContagem >= spawnTempo)
        {
            spawnEnemies();
            tempoContagem = 0;
        }
    }

    void spawnEnemies()
    {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)],transform.position + new Vector3(0,Random.Range(-1,2),0),transform.rotation);
    }
}
