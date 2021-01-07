using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int vida;
    [SerializeField] private int dano;


    public virtual void sofrerDano(int vida)
    {
        this.vida -= vida;

        if(this.vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            sofrerDano(collision.GetComponent<Tiro>().dano);
            collision.GetComponent<Tiro>().balaAcertada();
        }
    }
}
