using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject item;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i]==false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(item.GetComponent<PezScript>().canvas, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    public void add()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(item.GetComponent<PezScript>().canvas, inventory.slots[i].transform, false);
                inventory.contenidos.Add(item);
                break;
            }
        }
    }
}
