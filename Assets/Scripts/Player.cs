using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float _speed = 5f; // velocidade de movimento

    [SerializeField]
    private float _jump; // Força do pulo

    private Rigidbody2D rig; // Componente Rigdbody2D

    private bool isJumping;

    private bool doublejump;

    private Animator anim; // Componente Animator

    private float auxJump;

    private float auxMove;

    [SerializeField]private int id;

    [SerializeField] private SelecaoSkin skin;
   
    [SerializeField]private Sprite sprite;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); // Importando o componente Rigidbody 2d para o script

        anim = GetComponent<Animator>(); // Importando o componente Animator para o script

        changeSkin();
    }
  
    

    private void Update()
    {
        move(); // Movimento
        jump(); // Pulo


        if (transform.position.y <= -36)
        {

            transform.position = new Vector2(-17.56f, -22.0f);

        }


    }

    // movimento do personágem
    void move()
    {
     
        if (auxMove != 0)
        {
            Mobilemove();
        }
        else
        {
            rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, rig.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") > 0 || auxMove > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("walk", true);


        } else if (Input.GetAxisRaw("Horizontal") < 0 || auxMove < 0)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("walk", true);

        } else if (Input.GetAxisRaw("Horizontal") == 0 || auxMove == 0)
        {
            anim.SetBool("walk", false);
        }

    }

    // Pulo do personagem
    void jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                isJumping = true;
                //auxJump--;
                anim.SetBool("jump", true);
                rig.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse);
                doublejump = true;

            } else if (doublejump)
            {
                // auxJump--;

                doublejump = false;

                rig.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse);


            }

        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            GameControler.instance.GameOver();
            Destroy(this.gameObject);
        }

        if (other.gameObject.layer == 3)
        {
            isJumping = false;
            anim.SetBool("jump", false);

        }
    }

    private void OnitCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 3) // se o objeto colidido estiver na camada 3(chao)
        {
            isJumping = true; // Definindo isJumping como verdadeiro
        }
    }
    private void Mobilemove() // Realizando o movimento de player no touch
    {
        rig.velocity = new Vector2(auxMove * _speed, rig.velocity.y);
    }

    public void jumpTouch()// função responsavel pelo pulo via touch screen
    {
        if (Input.GetAxisRaw("Jump") == 0 )
        {
            
            if (!isJumping) // Realizando o pulo
            {
                isJumping = true; 

                auxJump--; // Decrementando o aux jump;

                anim.SetBool("jump", true); // Ativando a animação de pulo

                rig.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse); 
                
                doublejump = true; // Ativando o double jump

            }
            else if (doublejump) // Realizando double jump
            {
                auxJump--; // Decrementando o aux jump;

                doublejump = false; // Desativando o double jump

                rig.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse);


            }

        }
    }


    public void moveTouch(float aux) // Recebendo a entrada touch de movimento
    {
        auxMove= aux;
    }

    public void changeSkin() // Sistema de troca de skin
    {
        if (GameControler.playerSkin != null)
        {
            skin = GameControler.playerSkin;
        }

        anim.runtimeAnimatorController = skin.animControler;

        sprite = skin.sprite;
    }
}