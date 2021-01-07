using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoNave : Inimigo
{

    private Rigidbody2D rig;
    public float velocidadeNave;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    }

    private void FixedUpdate()
    {
        rig.velocity = Vector2.left * velocidadeNave;
    }
}
