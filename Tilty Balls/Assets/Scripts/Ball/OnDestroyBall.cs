using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyBall : MonoBehaviour
{
    public ParticleSystem destroyParticles;
    Renderer thisRenderer;
    Rigidbody thisRb;
    bool falling;

    private void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        thisRb = GetComponent<Rigidbody>();
    }

    private void SetParticleColor()
    {
        destroyParticles.startColor = thisRenderer.material.GetColor("_EmissionColor");
    }

    private void DestroyObject()
    {
        SetParticleColor();
        ParticleSystem killParticles = Instantiate(destroyParticles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    IEnumerator MoveToHole()
    {
        thisRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        thisRb.constraints = ~RigidbodyConstraints.FreezePositionZ;
        float elapsed = 0f;
        float duration = 0.2f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            thisRb.velocity = new Vector3(thisRb.velocity.x, thisRb.velocity.y, 30);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            DestroyObject();
        }

        if (other.CompareTag("Hole"))
        {
            if (!falling)
            {
                GetComponent<Collider>().enabled = false;
                StartCoroutine(MoveToHole());
            }
        }
    }
}
