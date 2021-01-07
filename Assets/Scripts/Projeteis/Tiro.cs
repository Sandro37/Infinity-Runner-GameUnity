using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Rigidbody2D rig;
    public float forcaTiro;

    public int dano;

    public GameObject efeitoBalaDestruida;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rig.velocity = Vector2.right * forcaTiro;
        
    }

    public void balaAcertada()
    {
        GameObject efeitoBalaDestruidaRetorno = Instantiate(efeitoBalaDestruida, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(efeitoBalaDestruidaRetorno, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            balaAcertada();
        }
    }
}
