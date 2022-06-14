using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    int randomNumber;
    [SerializeField] List<GameObject> peces;
    [SerializeField] GameObject player;
    [Header("Fishing Area")]
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottomBounds;

    [Header("Fish Settings")]
    [SerializeField] SpriteRenderer fishSprite;
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion=3f;
    [SerializeField] float fishTimeRandomizer=3f;
    float fishPosition;
    float fishSpeed=1f;
    float fishTimer;
    float fishTargetPosition=1f;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .15f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;
    float hookPosition;
    float hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower=0.5f;
    [SerializeField] float progressBarDecay=0.1f;
    float catchProgress;

    private void Start()
    {
        catchProgress = 0.3f;
        setFish();
    }
    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
        
    }

    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;

        float min = hookPosition - hookSize ;
        float max = hookPosition + hookSize ;

        if (min<fishPosition && fishPosition<max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if (catchProgress>=1)
            {
                
                
                gameObject.SetActive(false);
                if (player.GetComponent<PlayerScript>().ultimaPosicion == "Derecha")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Derecha");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Izquierda")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Izquierda");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Abajo")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Abajo");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Arriba")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Arriba");
                }
                player.GetComponent<PlayerScript>().bobber.GetComponent<bobberScript>().Volver(player);
                catchProgress = 0.3f;
                peces[randomNumber].GetComponent<Pickup>().add();
                setFish();
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if (catchProgress<=0)
            {
                gameObject.SetActive(false);
                if (player.GetComponent<PlayerScript>().ultimaPosicion == "Derecha")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Derecha");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Izquierda")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Izquierda");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Abajo")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Abajo");
                }
                else if (player.GetComponent<PlayerScript>().ultimaPosicion == "Arriba")
                {
                    player.GetComponent<PlayerScript>().CambiarDeAnimacion("Player_RecogerCaña_Arriba");
                }
                player.GetComponent<PlayerScript>().bobber.GetComponent<bobberScript>().Volver(player);
                catchProgress = 0.3f;
                setFish();
            }
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;
        hookPosition += hookPullVelocity;

        if (hookPosition-hookSize/2 <= 0 && hookPullVelocity<0)
        {
            hookPullVelocity = 0;
        }
        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1-hookSize/2); //mantiene el hook entre los bounds
        hook.position = Vector3.Lerp(bottomBounds.position, topBounds.position, hookPosition);
    }

    private void MoveFish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomBounds.position, topBounds.position, fishPosition);
    }

    public void setFish()
    {
        randomNumber = Random.Range(0, peces.Count());
        fishSprite.sprite = peces[randomNumber].GetComponent<PezScript>().fishSprite.sprite;
        smoothMotion = peces[randomNumber].GetComponent<PezScript>().smoothMotion;
        fishTimeRandomizer = peces[randomNumber].GetComponent<PezScript>().fishTimeRandomizer;

    }
}


