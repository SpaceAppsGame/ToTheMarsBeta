using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OnKeySaver:MonoBehaviour
{
    public int level = 0;
    float realTime, timeElapsed;
    Dictionary<string, double> catastrophe = new Dictionary<string, double>();
    void Awake()
    {
        realTime = PlayerPrefs.GetFloat("realTime");
        timeElapsed = PlayerPrefs.GetFloat("gameHours");
    }

    void Start()
    {
        catastrophe.Add("Solar Flare", 0.1);
        catastrophe.Add("Comms Failure", 0.2);
        catastrophe.Add("Nothing", 0.7);
        if(level > 2)
        {
            randomScheduler(); 
        }
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            PlayerPrefs.SetFloat("realTime", Time.realtimeSinceStartup);
            timeElapsed = realTime / 40; //in hours
            PlayerPrefs.SetFloat("gameHours", timeElapsed);
        }
    }
     
    void randomScheduler()
    {
        var r = new System.Random();
        double picker = r.NextDouble();
        //int counter = 0; 
        double total = 0;
        foreach (string key in catastrophe.Keys)
        {
                total += catastrophe[key];
                if (picker <= total)
                {
                    if(key == "Solar Flare")
                    {

                    }
                    else if(key == "Comms Failure" )
                    {

                    }
                    else
                    {
                        break; 
                    }
                } 
        }
    }

}
