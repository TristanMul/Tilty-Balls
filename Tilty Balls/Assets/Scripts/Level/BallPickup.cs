﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    Rigidbody rb;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetPopped();
        }
    }

    private void GetPopped()
    {
        rb.isKinematic = false;
        float speed = Random.Range(5f, 15f);
        rb.velocity = new Vector3(0f, 0f, -speed);

        Color newColor = RandomColor();
        renderer.material.color = newColor;
        renderer.material.SetColor("_EmissionColor", newColor);
        StartCoroutine(RemoveInTime(5f));
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
