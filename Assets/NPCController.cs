using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    private bool dentro;
    private void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dentro = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dentro = false;
    }

    private void Update()
    {
        if (dentro && Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Parar();
        }
    }

}
