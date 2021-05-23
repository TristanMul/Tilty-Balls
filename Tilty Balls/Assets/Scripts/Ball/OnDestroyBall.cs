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
        destroyParticles.startColor = thisRenderer.material.GetColor("_Color");
    }

    IEnumerator MoveToHole()
    {
        thisRb.constraints = RigidbodyConstraints.None;
        SetParticleColor();
        ParticleSystem killParticles = Instantiate(destroyParticles, new Vector3(transform.position.x, transform.position.y, 20f), transform.rotation);
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            thisRb.velocity = new Vector3(thisRb.velocity.x, thisRb.velocity.y, 30);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            if (!falling)
            {
                StartCoroutine(MoveToHole());
                falling = true;
            }
        }
    }
}
