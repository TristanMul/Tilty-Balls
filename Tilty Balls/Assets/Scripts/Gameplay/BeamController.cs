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

    bool hasFinished;
    // Start is called before the first frame update
    void Start()
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
                rotateRb.angularVelocity = new Vector3(0f, 0f, -(Input.mousePosition.x - lastMouseX) * Time.deltaTime * sensitivity);

                lastMouseX = Input.mousePosition.x;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                rotateRb.isKinematic = true;
                
            }

            //Clamps the rotation of the block
            rotateBlock.transform.rotation =
                new Quaternion(rotateBlock.transform.rotation.x, rotateBlock.transform.rotation.y,
                Mathf.Clamp(rotateBlock.transform.rotation.z, -.4f, .4f),
                rotateBlock.transform.rotation.w);
            rotateBlock.transform.position = transform.position;

            rb.velocity = new Vector3(0f, moveSpeed, 0f);
            Debug.Log(rotateBlock.transform.rotation);
        }
        if (GameEventManager.instance.finishThreshold.position.y < transform.position.y)
        {
            GameEventManager.instance.ReachFinish();
        }
    }

    IEnumerator RotateTowardsTargetRotation() {
        Quaternion targetRotation = new Quaternion(0.0f, 0.0f, 0.2f, 1.0f);
        while (transform.rotation != targetRotation) {
            //transform.rotate
            yield return null;
        }
    }
}
