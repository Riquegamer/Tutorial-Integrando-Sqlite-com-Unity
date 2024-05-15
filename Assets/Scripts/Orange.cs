using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
       {
            GameControler.totalScore += 20;
            GameControler.instance.UpdateScoreText();
            Player player = other.GetComponent<Player>();
            player._speed = 8.0f;
            Destroy(this.gameObject);
       }
    }
}
