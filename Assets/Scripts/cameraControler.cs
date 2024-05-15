using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraControler : MonoBehaviour
{
    public Transform target; // transform do personagem principal
    public Vector3 offset = new Vector3(10f, 0f, -10f); // distância da câmera em relação ao personagem
    public float smoothTime = 0.3f; // tempo para suavizar o movimento da câmera

    private Vector3 velocity = Vector3.zero; // velocidade da câmera

    private void LateUpdate()
    {
        // calcula a nova posição da câmera
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}