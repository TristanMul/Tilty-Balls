using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    [SerializeField] GameObject rotateBlock;
    Rigidbody rotateRb;
    float lastMouseX;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotateRb = rotateBlock.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMouseX = Input.mousePosition.x;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rotateBlock.transform.Rotate(new Vector3(0f, 0f, -(Input.mousePosition.x - lastMouseX)));

            lastMouseX = Input.mousePosition.x;
        }
    }
}
