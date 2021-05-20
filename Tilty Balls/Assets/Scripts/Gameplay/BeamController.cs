using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    [SerializeField] GameObject rotateBlock;
    [SerializeField] float sensitivity;
    [SerializeField] float moveSpeed;
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
            rotateRb.angularVelocity = new Vector3(0f, 0f, -(Input.mousePosition.x - lastMouseX) * Time.deltaTime * sensitivity);

            lastMouseX = Input.mousePosition.x;
        }

        //Clamps the rotation of the block
        rotateBlock.transform.rotation =
            new Quaternion(rotateBlock.transform.rotation.x, rotateBlock.transform.rotation.y, 
            Mathf.Clamp( rotateBlock.transform.rotation.z, -.4f, .4f), 
            rotateBlock.transform.rotation.w);
        rotateBlock.transform.position = transform.position;

        rb.velocity = new Vector3(0f, moveSpeed, 0f);
    }
}
