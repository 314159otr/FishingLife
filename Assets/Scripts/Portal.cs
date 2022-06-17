using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject portalDestino;
    [SerializeField] Vector3 desfase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            player.transform.position= portalDestino.transform.position + desfase;
        }
    }
}
