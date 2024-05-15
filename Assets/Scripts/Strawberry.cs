using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    [SerializeField]
    private int _score;

    [SerializeField]
    private GameObject _colectedPrefab;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameControler.totalScore += _score;
            GameControler.instance.UpdateScoreText();
            Instantiate(_colectedPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }    
    }

}
