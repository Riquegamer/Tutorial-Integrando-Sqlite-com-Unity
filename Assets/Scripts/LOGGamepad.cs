using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGGamepad : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton14)) {
            Debug.Log("Apertou Botão 14");}
        if (Input.GetKeyDown(KeyCode.JoystickButton15) )//|| //Input.GetMouseButtonDown(0))
        {
            Debug.Log("Apertou Botão 15"); 
        }
        
    }
}
