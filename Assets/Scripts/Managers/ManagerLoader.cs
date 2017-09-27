﻿using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private List<GameObject> destroyOnLoad = null;

    //loads our GameManager into the scene,
    //      By doing this instead of having our GameManger already in the scene, we
    //      prevent attached scripts from calling Awake() more than once.
    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        if (null != destroyOnLoad)
            foreach (GameObject go in destroyOnLoad)
                Destroy(go);
    }
}