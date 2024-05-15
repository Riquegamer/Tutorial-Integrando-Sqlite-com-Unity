using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField]
    private float _speed; // Variavel responsavel pela velocidade da serra

    private bool _dirRight; // variavel que controla quando a serra vai para a direita ou não

    private float _timer; // Variavel responsavel por controlar o tempo de movimento da serra

    [SerializeField]
    private float _moveTime; // Variavel responsavel por controlar o quanto de tempo é necessario para o _timer atingir o maximo

    void Start()
    {
        
    }

    
    void Update()
    {
        if(_dirRight) 
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime); // se dirRight for verdadeiro mova para esquerda
        }
        else
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime); // se dirRight for falsa mova para direita
        }

        _timer += Time.deltaTime;

        if (_timer >= _moveTime) 
        {
            _dirRight = !_dirRight;

            _timer = 0f;
        }
    }

   
}
