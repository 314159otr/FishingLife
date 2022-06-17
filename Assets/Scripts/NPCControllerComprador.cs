using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerComprador : MonoBehaviour
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
        if (dentro && Input.GetKeyDown(KeyCode.X) && DialogManager.Instance.currentLine==1)
        {
            for (int i = 0; i < InventarioImagenes.transform.childCount; i++)
            {
                if (InventarioImagenes.transform.GetChild(i).childCount!=0)
                {
                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().dinero+= inventory.contenidos[i].GetComponent<PezScript>().precio;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().ActualizarDinero();
                }
                inventory.isFull[i] = false;
                
                
            }
            inventory.contenidos.Clear();
            foreach (Transform item in InventarioImagenes.transform)
            {
                if (item.childCount!=0)
                {
                    
                    
                    Destroy(item.GetChild(0).gameObject);
                }
                
            }
            Interact();
        }
        if (dentro && Input.GetKeyDown(KeyCode.Z))
        {
            InventarioImagenes.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hablando = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Parar();
            Interact();
            
        }
    }

}
