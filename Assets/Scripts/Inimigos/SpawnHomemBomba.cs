using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHomemBomba : MonoBehaviour
{

    public GameObject inimigoPrefab;
    private GameObject inimigoAtual;
    public List<Transform> points = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        criarInimigo();
    }

    public void destruirInimigo()
    {
        Destroy(inimigoAtual, 1f);
    }

    public void criarInimigo()
    {
        int index = Random.Range(0, points.Count);
        GameObject e = Instantiate(inimigoPrefab, points[index].position, points[index].rotation);
        inimigoAtual = e;


    }
}
