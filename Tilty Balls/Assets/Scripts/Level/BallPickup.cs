using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [SerializeField] ObjectList ballList;
    public ParticleSystem pickupParticles;
    Rigidbody rb;
    Renderer renderer;
    Collider collider;
    float maxSpeed = 20f;
    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        float randomSize = Random.Range(0.5f, 0.75f) ;
        //float randomSize = 0.75f;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            if (rb.velocity.magnitude > maxSpeed)
                rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
            GetPopped();
            var main = other.GetComponent<Renderer>().material;
            pickupParticles.startColor = main.color;
            Instantiate(pickupParticles, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 6f), other.transform.rotation);
        }
    }

    private void GetPopped()
    {
        isActive = true;
        rb.isKinematic = false;
        collider.isTrigger = false;
        gameObject.tag = "Player";
        gameObject.layer = 0;
        Color newColor = RandomColor();
        renderer.material.color = newColor;
        renderer.material.SetColor("_EmissionColor", newColor/2);
        ballList.RegisterObject(this.gameObject);
    }

    Color RandomColor()
    {
        int colorToPick = Random.Range(0, ColorManagement.instance.colorsToPickFrom.Length);
        if (ColorManagement.instance.colorsToPickFrom.Length != 0)
        {
            return ColorManagement.instance.colorsToPickFrom[colorToPick];
        }
        else return Color.white;
    }

    IEnumerator RemoveInTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
