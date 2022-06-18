using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCompras : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] string textoAnzuelo;
    [SerializeField] string textoCebo;
    [SerializeField] Image CeboVenta;
    [SerializeField] Image AnzueloVenta;
    [SerializeField] Image Cebo;
    [SerializeField] Image Anzuelo;
    [SerializeField] TextMeshProUGUI Descripcion;
    [SerializeField] GameObject CeboBoton;
    [SerializeField] GameObject AnzueloBoton;
    bool ceboEnVenta = true;
    int precioCebo = 150;
    int precioAnzuelo = 100;
    public void PulsarCebo()
    {
        Descripcion.text = textoCebo;
        if (ceboEnVenta)
        {
            CeboBoton.SetActive(true);
        }
        
        AnzueloBoton.SetActive(false);
    }

    public void PulsarAnzuelo()
    {
        Descripcion.text = textoAnzuelo;
        AnzueloBoton.SetActive(true);
        CeboBoton.SetActive(false);
    }
    public void ComprarCebo()
    {
        if (player.GetComponent<PlayerScript>().dinero>=precioCebo)
        {
            player.GetComponent<PlayerScript>().dinero -= precioCebo;
            player.GetComponent<PlayerScript>().ActualizarDinero();
            Cebo.sprite = CeboVenta.sprite;
            Cebo.GetComponent<Bait>().hookPower = 0.6f;
            Cebo.GetComponent<Bait>().progressBarDecay = 0.1f;
            CeboBoton.SetActive(false);
            ceboEnVenta = false;
        }
        
    }
    public void ComprarAnzuelo()
    {
        if (player.GetComponent<PlayerScript>().dinero >= precioAnzuelo)
        {
            player.GetComponent<PlayerScript>().dinero -= precioAnzuelo;
            player.GetComponent<PlayerScript>().ActualizarDinero();
            Cebo.sprite = CeboVenta.sprite;
            Cebo.GetComponent<Bait>().hookPower = 0.6f;
            Cebo.GetComponent<Bait>().progressBarDecay = 0.1f;
            CeboBoton.SetActive(false);
            ceboEnVenta = false;
        }

    }
}
