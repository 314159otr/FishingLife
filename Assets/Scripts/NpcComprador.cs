using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcComprador : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject menuCompras;
    private bool dentro;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            dentro = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            dentro = false;
        }
    }
    private void Update()
    {
        if (dentro && Input.GetKeyDown(KeyCode.Z))
        {
            player.GetComponent<PlayerScript>().hablando = true;
            menuCompras.SetActive(true);
        }
    }
}
