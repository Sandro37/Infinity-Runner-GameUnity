using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity;
    public float jumpForce;
    private bool isJump;

    private  Rigidbody2D rig;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump(); 
    }
    private void FixedUpdate()
    {
        move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

    private void move()
    {
        rig.velocity = new Vector2(velocity, rig.velocity.y);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            isJump = true;
        }
    }
}
