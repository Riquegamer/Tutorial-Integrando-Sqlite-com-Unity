using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private string lvl;
    void Update()
    {
        if(Input.GetAxis("Jump") == 1) 
        {
            GameControler.instance.RestartGame(lvl);
        }
    }
}
