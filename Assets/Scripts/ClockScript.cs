using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.Rendering;
public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay; 
    public Volume ppv; 

    public float tick; 
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;

    public bool activateLights; 
    public GameObject[] lights;
    void Start()
    {
        hours = 21;
        ppv = gameObject.GetComponent<Volume>();
    }
    void FixedUpdate() 
    {
        CalcTime();
        DisplayTime();

    }

    public void CalcTime() 
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60) 
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60) 
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) 
        {
            hours = 0;
            days += 1;
        }
        ControlPPV(); 
    }

    public void ControlPPV() 
    {

        if (hours >= 21 && hours < 22) 
        {
            ppv.weight = (float)mins / 60;


            if (activateLights == false)
            {
                if (mins > 45) 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); 
                    }
                    activateLights = true;
                }
            }
        }


        if (hours >= 6 && hours < 7) 
        {
            ppv.weight = 1 - (float)mins / 60; 
            if (activateLights == true) 
            {
                if (mins > 30) 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false);
                    }
                    activateLights = false;
                }
            }
        }
    }

    public void DisplayTime() 
    {

        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, (mins/10)*10); 
        dayDisplay.text = "Day: " + days; 
    }
}