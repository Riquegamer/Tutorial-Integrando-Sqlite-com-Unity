using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    [SerializeField]
    private float fallinTime;
    
    private TargetJoint2D target;

    private BoxCollider2D boxco;


    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>(); // Anexando o componente TargeyJoint2D ao script

        boxco = GetComponent<BoxCollider2D>(); // Anexando o componente BoxCollider2D ao script
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player" )
        {
            Invoke("Falling", fallinTime);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }    
    }

    void Falling() // Ativando queda da plataforma
    {
        target.enabled = false; // Desligando o TargetJoint 2d
        boxco.isTrigger = true; // Ligando a propriedade is Trigger
    }

}
