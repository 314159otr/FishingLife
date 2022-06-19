using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCompras : MonoBehaviour
{
    [SerializeField] GameObject fishingGame;
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
    [SerializeField] public GameObject fondoCompra;
    bool ceboEnVenta = true;
    bool anzueloEnVenta = true;
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
        if (anzueloEnVenta)
        {
            AnzueloBoton.SetActive(true);
        }
        
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
            fishingGame.GetComponent<FishingMiniGame>().setBait();
        }
        
    }
    public void ComprarAnzuelo()
    {
        if (player.GetComponent<PlayerScript>().dinero >= precioAnzuelo)
        {
            player.GetComponent<PlayerScript>().dinero -= precioAnzuelo;
            player.GetComponent<PlayerScript>().ActualizarDinero();
            Anzuelo.sprite = AnzueloVenta.sprite;
            Anzuelo.GetComponent<Hook>().hookSpeed = 0.15f;
            Anzuelo.GetComponent<Hook>().hookGravity = 0.06f;
            AnzueloBoton.SetActive(false);
            anzueloEnVenta = false;
            fishingGame.GetComponent<FishingMiniGame>().setHook();
        }

    }
}
