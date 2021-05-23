﻿using System.Collections;
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
       
        float elapsed = 0f;
        float duration = 1f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            thisRb.velocity = new Vector3(thisRb.velocity.x, thisRb.velocity.y, 30);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, elapsed / duration);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator ParticleWait()
    {
        yield return new WaitForSeconds(0.25f);
        SetParticleColor();
        Instantiate(destroyParticles, new Vector3(transform.position.x, transform.position.y, 30f), transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            if (!falling)
            {
                StartCoroutine(MoveToHole());
                StartCoroutine(ParticleWait());
                falling = true;
            }
        }
    }
}
