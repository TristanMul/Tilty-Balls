using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    [SerializeField]public Transform finishThreshold;


    public event Action reachFinish;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Calls the reach finish event
    /// </summary>
    public void ReachFinish()
    {
        reachFinish();
    }
}
