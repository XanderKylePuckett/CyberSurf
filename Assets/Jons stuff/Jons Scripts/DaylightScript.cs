﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaylightScript : TimeOfDayOptions
{

    GameObject sun = null;
    Material nono;
    Material ogSkybox;
    ParticleSystem stars;
     int currentScene;

    private new void Start()
    {
        sun = GameObject.FindGameObjectWithTag("sun");
        nono = RenderSettings.skybox;
        ogSkybox = RenderSettings.skybox;
        stars = GameObject.FindGameObjectWithTag("stars").GetComponent<ParticleSystem>();

    }



    private void lookForTime()
    {
        if (currentScene > 1)
        {

            switch ((int)getTime())
            {
                //noon
                case 0:
                    {
                        sun.SetActive(true);
                        Vector3 highNoon = new Vector3(73f, 0, 0);
                        sun.transform.localRotation = Quaternion.Euler(highNoon);
                        stars.maxParticles = 1;
                     //sets ambient light to cheese
                        RenderSettings.ambientLight = new Color(0.33f, 0.33f, 0.33f); 
                      //can change skybox
                          RenderSettings.skybox = ogSkybox;

                    }
                    break;
                    //afternoon
                case 1:
                    {
                        sun.SetActive(true);
                        Vector3 afterNoon = new Vector3(120f, 0, 0);
                        stars.maxParticles = 1;

                        RenderSettings.ambientLight = new Color(0.33f, 0.33f, 0.33f);
                        sun.transform.localRotation = Quaternion.Euler(afterNoon);

                       RenderSettings.skybox = ogSkybox;

                    }
                    break;
                    //evening
                case 2:
                    {
                        sun.SetActive(true);
                        //180.6
                        Vector3 evening = new Vector3(176.24f, 0, 0);
                        stars.maxParticles = 1;

                        //ambient 0.257
                        RenderSettings.ambientLight = new Color(0.33f, 0.33f, 0.33f);
                        sun.transform.localRotation = Quaternion.Euler(evening);

                          RenderSettings.skybox = ogSkybox;

                    }
                    break;
                    //night
                case 3:
                    {
                        sun.SetActive(false);
                        RenderSettings.ambientLight = new Color(0.33f, 0.33f, 0.33f);
                        stars.maxParticles = 2000;

                        RenderSettings.skybox = null;
                    }
                    break;
                    //morning
                case 4:
                    {
                        sun.SetActive(true);
                        Vector3 morning = new Vector3(16f, 0, 0);
                        stars.maxParticles = 1;
                        RenderSettings.ambientLight = new Color(1f, 0.0f, 1f);
                        RenderSettings.skybox = ogSkybox;
                        sun.transform.localRotation = Quaternion.Euler(morning);


                    }
                    break;
                default:
                    {
                        Debug.Log("bad");
                    }
                    break;
            }
        }

    }

    // Update is called once per frame
    new

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        lookForTime();
       


    }
}
