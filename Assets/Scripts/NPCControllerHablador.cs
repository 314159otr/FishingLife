using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerHablador : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    private bool dentro;
    [SerializeField] GameObject InventarioImagenes;
    [SerializeField] Inventory inventory;
    private void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
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
            InventarioImagenes.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hablando = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Parar();
            Interact();

        }
    }

}
