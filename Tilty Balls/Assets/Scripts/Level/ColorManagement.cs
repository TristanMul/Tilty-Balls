using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagement : MonoBehaviour
{
    public static ColorManagement instance;
    [SerializeField] public Color[] colorsToPickFrom;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
