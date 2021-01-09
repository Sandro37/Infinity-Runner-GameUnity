using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int vida;

    public float velocity;
    public float jumpForce;
    private bool isJump;

    private  Rigidbody2D rig;
    public Animator anim;

    public GameObject tiroPrefab;
    public Transform pontoTiro;

    public Text vidaText;

    public SpriteRenderer sprite;

    public Text playerPontoCorrido;
    private float tempoCorrido;
    // Start is called before the first frame update
    void Start()
    {
        playerPontoCorrido.text = " " + tempoCorrido; 
        vidaText.text = "" +  vida; 
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        atirar();
        pontoContador();
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomba"))
        {
            sofrerDano();
        }else if (collision.gameObject.CompareTag("Inimigo"))
        {
            sofrerDano();
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
            SomEfeitos.audio.TocarSom(SomEfeitos.audio.somPulo);
            anim.SetBool("isJump", true);
            isJump = true;
        }
    }

    private void atirar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SomEfeitos.audio.TocarSom(SomEfeitos.audio.somTiro);
            Instantiate(tiroPrefab, pontoTiro.position,pontoTiro.rotation);
        }
        
    }

    public void sofrerDano()
    {
        vida--;
        vidaText.text = "" + vida;
        SomEfeitos.audio.TocarSom(SomEfeitos.audio.DanoPlayer);
        sprite.color = Color.red;
        if (vida <= 0)
        {
            ControllerGame.controller.fimDeJogo();
        }
        StartCoroutine("esperar");
        
    }

    //MOBILE
    public void jumpMobile()
    {
        if(!isJump)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            SomEfeitos.audio.TocarSom(SomEfeitos.audio.somPulo);
            anim.SetBool("isJump", true);
            isJump = true;
        }
    }

    public void tiroMobile()
    {
        SomEfeitos.audio.TocarSom(SomEfeitos.audio.somTiro);
        Instantiate(tiroPrefab, pontoTiro.position, pontoTiro.rotation);
    }

    public void pontoContador()
    {
        tempoCorrido += Time.deltaTime * velocity;
        playerPontoCorrido.text = "" + (int)tempoCorrido;
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }

}




