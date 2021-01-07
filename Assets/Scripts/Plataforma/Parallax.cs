using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float comprimento;
    private float posInicial;

    public Transform cam;

    public float velocidadeParallax;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position.x;
        comprimento = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float reposicao = cam.transform.position.x *(1 - velocidadeParallax);
        float distancia = cam.transform.position.x * velocidadeParallax;

        transform.position = new Vector3(posInicial + distancia, transform.position.y, transform.position.z); 

        if(reposicao > posInicial  + comprimento)
        {
            posInicial += comprimento;
        }
    }
}
