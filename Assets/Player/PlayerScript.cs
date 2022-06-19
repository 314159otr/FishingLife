using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    private string animacionActual="";
    [SerializeField]private float speed ;
    private Vector2 vectorMovimiento;
    public Vector2 ultimoVectorMovimiento;
    Object bobberRef;
    public GameObject bobber;
    private bool pescando;
    public bool picado;
    public bool recogiendo;
    public bool hablando;
    [SerializeField] GameObject fishingGame;
    public int dinero = 0;
    public TextMeshProUGUI dineroText;


    public string ultimaPosicion;
    
    private const string ARRIBA = "Arriba";
    private const string DERECHA = "Derecha";
    private const string ABAJO = "Abajo";
    private const string IZQUIERDA = "Izquierda";

    //ANIMACIONES
    private const string ANDAR_ARRIBA = "Player_Andar_Arriba";
    private const string ANDAR_DERECHA = "Player_Andar_Derecha";
    private const string ANDAR_ABAJO = "Player_Andar_Abajo";
    private const string ANDAR_IZQUIERDA = "Player_Andar_Izquierda";
    private const string RESPIRAR_ARRIBA = "Player_Respirar_Arriba";
    private const string RESPIRAR_DERECHA = "Player_Respirar_Derecha";
    private const string RESPIRAR_ABAJO = "Player_Respirar_Abajo";
    private const string RESPIRAR_IZQUIERDA = "Player_Respirar_Izquierda";

    private const string PESCAR_ARRIBA = "Player_Pescar_Arriba";
    private const string PESCAR_DERECHA = "Player_Pescar_Derecha";
    private const string PESCAR_ABAJO = "Player_Pescar_Abajo";
    private const string PESCAR_IZQUIERDA = "Player_Pescar_Izquierda";
    private const string RECOGERCAÑA_ARRIBA = "Player_RecogerCaña_Arriba";
    private const string RECOGERCAÑA_DERECHA = "Player_RecogerCaña_Derecha";
    private const string RECOGERCAÑA_ABAJO = "Player_RecogerCaña_Abajo";
    private const string RECOGERCAÑA_IZQUIERDA = "Player_RecogerCaña_Izquierda";

    



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bobberRef = Resources.Load("bobber");
        ActualizarDinero();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hablando)
        {
            ultimoVectorMovimiento = vectorMovimiento;
            vectorMovimiento.x = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * speed;
            vectorMovimiento.y = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * speed;
            if (!pescando)
            {
                if (vectorMovimiento.x > 0)
                {
                    CambiarDeAnimacion(ANDAR_DERECHA);
                    ultimaPosicion = DERECHA;
                }
                else if (vectorMovimiento.x < 0)
                {
                    CambiarDeAnimacion(ANDAR_IZQUIERDA);
                    ultimaPosicion = IZQUIERDA;
                }
                else if (vectorMovimiento.y < 0)
                {
                    CambiarDeAnimacion(ANDAR_ABAJO);
                    ultimaPosicion = ABAJO;
                }
                else if (vectorMovimiento.y > 0)
                {
                    CambiarDeAnimacion(ANDAR_ARRIBA);
                    ultimaPosicion = ARRIBA;
                }
                else
                {

                    if (ultimoVectorMovimiento.x > 0)
                    {
                        CambiarDeAnimacion(RESPIRAR_DERECHA);
                        ultimaPosicion = DERECHA;
                    }
                    else if (ultimoVectorMovimiento.x < 0)
                    {
                        CambiarDeAnimacion(RESPIRAR_IZQUIERDA);
                        ultimaPosicion = IZQUIERDA;
                    }
                    else if (ultimoVectorMovimiento.y < 0)
                    {
                        CambiarDeAnimacion(RESPIRAR_ABAJO);
                        ultimaPosicion = ABAJO;
                    }
                    else if (ultimoVectorMovimiento.y > 0)
                    {
                        CambiarDeAnimacion(RESPIRAR_ARRIBA);
                        ultimaPosicion = ARRIBA;
                    }
                    else
                    {

                        if (ultimoVectorMovimiento.x > 0)
                        {
                            CambiarDeAnimacion(ANDAR_ABAJO);
                            ultimaPosicion = ABAJO;
                        }

                    }

                }
            }

            if (Input.GetButtonDown("Fire1") && !pescando && !recogiendo)
            {

                Parar();
                if (ultimaPosicion == "Derecha")
                {
                    CambiarDeAnimacion(PESCAR_DERECHA);
                }
                else if (ultimaPosicion == "Izquierda")
                {
                    CambiarDeAnimacion(PESCAR_IZQUIERDA);
                }
                else if (ultimaPosicion == "Abajo")
                {
                    CambiarDeAnimacion(PESCAR_ABAJO);
                }
                else if (ultimaPosicion == "Arriba")
                {
                    CambiarDeAnimacion(PESCAR_ARRIBA);
                }
                bobber = (GameObject)Instantiate(bobberRef);
                bobber.GetComponent<bobberScript>().Lanzar(transform);

            }

            if (Input.GetButtonDown("Fire1") && pescando && bobber.GetComponent<bobberScript>().enElAgua)
            {
                if (!picado && !recogiendo)
                {

                    fishingGame.SetActive(true);
                    fishingGame.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position - new Vector3(5f, 0f, 0f);

                }
                else
                {
                    bobber.GetComponent<bobberScript>().Volver(gameObject);

                    if (ultimaPosicion == "Derecha")
                    {
                        CambiarDeAnimacion(RECOGERCAÑA_DERECHA);
                    }
                    else if (ultimaPosicion == "Izquierda")
                    {
                        CambiarDeAnimacion(RECOGERCAÑA_IZQUIERDA);
                    }
                    else if (ultimaPosicion == "Abajo")
                    {
                        CambiarDeAnimacion(RECOGERCAÑA_ABAJO);
                    }
                    else if (ultimaPosicion == "Arriba")
                    {
                        CambiarDeAnimacion(RECOGERCAÑA_ARRIBA);
                    }
                }

            }
            pescando = bobber != null;
        }
       
    }
    private void FixedUpdate()
    {
        if (!pescando)
        {
            Mover(vectorMovimiento);
        }
        
    }

    public void Mover(Vector2 vector2)
    {
        rb2d.velocity = vector2;
    }
    public void Parar()
    {
        rb2d.velocity = new Vector2(0,0);
    }
    public void CambiarDeAnimacion(string animacionNueva)
    {
        if (animacionActual == animacionNueva) return; //si la animacion se esta reproduciendo no hace nada para no cortarla y volverla a poner

        animator.Play(animacionNueva);

        animacionActual = animacionNueva;
    }
    public void ActualizarDinero()
    {
        dineroText.text = dinero.ToString() +"$";
    }
   
}
