using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobberScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    private bool parado;
    public bool enElAgua;
    string direccion;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sortingOrder = -2;
    }

    
    
    public void Lanzar(Transform transform)
    {
        
        StartCoroutine(ejecutarLance(transform));
    }
    IEnumerator ejecutarLance(Transform jugador)
    {
        direccion = jugador.GetComponent<PlayerScript>().ultimaPosicion;
        yield return new WaitForSeconds(0.3f);
        //lo pongo en una capa visible
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        transform.position = new Vector2(jugador.position.x + .4f, jugador.position.y + 1f);
        if (direccion == "Derecha")
        {
            rb2d.velocity = new Vector2(5, -4);
        }
        else if (direccion == "Izquierda")
        {
            transform.position = new Vector2(jugador.position.x + -.4f, jugador.position.y + 1f);
            rb2d.velocity = new Vector2(-5, -4);
        }
        else if (direccion == "Abajo")
        {
            rb2d.velocity = new Vector2(0, -8);
            transform.position = new Vector2(jugador.position.x + .1f, jugador.position.y + 1f);
        }
        else if (direccion == "Arriba")
        {
            rb2d.velocity = new Vector2(0, 4);
        }
        
        yield return new WaitForSeconds(0.5f);
        rb2d.velocity = new Vector2(0, 0);
        parado = true;
        yield return new WaitForSeconds(0.1f);
        if (!enElAgua)
        {
            Destroy(gameObject);
            
            if (direccion =="Derecha")
            {
                jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Derecha");
            }
            else if (direccion == "Izquierda")
            {
                jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Izquierda");
            }
            else if (direccion == "Abajo")
            {
                jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Abajo");
            }
            else if (direccion == "Arriba")
            {
                jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Arriba");
            }
        }
        
        
    }
    
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (parado && collision.name=="Agua")
        {
            enElAgua = true;
            
        }
        
    }
    public void Volver(GameObject jugador)
    {
        
        StartCoroutine(vuelta(jugador));
    }
    IEnumerator vuelta(GameObject jugador)
    {
        
        jugador.GetComponent<PlayerScript>().recogiendo = true;
        if (direccion == "Derecha")
        {
            rb2d.velocity = new Vector2(-5, 4);
        }
        else if (direccion == "Izquierda")
        {
            rb2d.velocity = new Vector2(5, 4);
        }
        else if (direccion == "Abajo")
        {
            rb2d.velocity = new Vector2(0, 8);
        }
        else if (direccion == "Arriba")
        {
            rb2d.velocity = new Vector2(0, -4);
        }
        yield return new WaitForSeconds(0.5f);
        if (direccion == "Derecha")
        {
            jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Derecha");
        }
        else if (direccion == "Izquierda")
        {
            jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Izquierda");
        }
        else if (direccion == "Abajo")
        {
            jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Abajo");
        }
        else if (direccion == "Arriba")
        {
            jugador.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_Respirar_Arriba");
        }
        
        jugador.GetComponent<PlayerScript>().recogiendo = false;
        jugador.GetComponent<PlayerScript>().picado = false;
        Destroy(gameObject);
    }

}
