using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBall : MonoBehaviour
{
    [SerializeField] ObjectList ballList;
    Rigidbody rb;
    float maxSpeed = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        ballList.ClearList();
        ballList.RegisterObject(this.gameObject);
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
