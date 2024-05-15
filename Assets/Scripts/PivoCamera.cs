using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivoCamera : MonoBehaviour
{
    [SerializeField]private Transform player;

    private void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
