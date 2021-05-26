using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    [SerializeField] GameObject rotateBlock;
    [SerializeField] float sensitivity;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxRotationSpeed;
    [HideInInspector] public Rigidbody rotateRb;
    float lastMouseX;
    Rigidbody rb;

    bool hasFinished;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rotateRb = rotateBlock.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFinished)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                lastMouseX = Input.mousePosition.x;
                rotateRb.isKinematic = false;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                float rotationSpeed = -(Input.mousePosition.x - lastMouseX) * Time.deltaTime * sensitivity;
                if (rotationSpeed > maxRotationSpeed) { rotationSpeed = maxRotationSpeed; }//clamps the rotation speed so it's not too high
                if (rotationSpeed < -maxRotationSpeed) { rotationSpeed = -maxRotationSpeed; }
                rotateRb.angularVelocity = new Vector3(0f, 0f, rotationSpeed);

                // to make sure the transform doesn't magically rotate
                rotateRb.transform.rotation = new Quaternion(0f, 0f, rotateRb.transform.rotation.z, rotateRb.transform.rotation.w);

                lastMouseX = Input.mousePosition.x;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                rotateRb.isKinematic = true;

            }

            //Clamps the rotation of the block
            rotateBlock.transform.rotation =
                new Quaternion(rotateBlock.transform.rotation.x, rotateBlock.transform.rotation.y,
                Mathf.Clamp(rotateBlock.transform.rotation.z, -.3f, .3f),
                rotateBlock.transform.rotation.w);
            rotateBlock.transform.position = transform.position;

            rb.velocity = new Vector3(0f, moveSpeed, 0f);
        }


        //Handle wether the player has finished
        if (GameEventManager.instance.finishThreshold.position.y < transform.position.y && !hasFinished)
        {
            hasFinished = true;
            rotateRb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            rotateRb.isKinematic = true;
            GameEventManager.instance.ReachFinish();
        }
    }


}
