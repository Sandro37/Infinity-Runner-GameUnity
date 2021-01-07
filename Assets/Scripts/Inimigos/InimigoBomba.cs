using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBomba : Inimigo
{
    public GameObject bomba;
    public Transform ponto_bomba;
    public float tempo_de_arremesso;
    private float contagem_de_arremesso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contagem_de_arremesso += Time.deltaTime;

        if(contagem_de_arremesso >= tempo_de_arremesso)
        {
            Instantiate(bomba,ponto_bomba.position, ponto_bomba.rotation);
            contagem_de_arremesso = 0;
        }
    }
}
