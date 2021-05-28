using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyBall : MonoBehaviour
{
    Rigidbody rb;
    List<MultiplierGate> sourcesUsed = new List<MultiplierGate>();
    bool canMultiply;
    private void Start()
    {
        StartCoroutine(WaitAndEnableMultiply(0f));
        rb = GetComponent<Rigidbody>();
    }


    IEnumerator WaitAndEnableMultiply(float duration)
    {
        yield return new WaitForSeconds(duration);
        canMultiply = true;
    }


    /// <summary>
    /// Multiplies the object. Don't put this in start.
    /// </summary>
    /// <param name="amount">The amount of new objects made</param>
    /// <param name="source">The identifying int used from the source so the same won't be used twice </param>
    public void Multiply(int amount, MultiplierGate source)
    {

        bool willMultiply = true;
        foreach (MultiplierGate i in sourcesUsed)
        {
            if (source == i)
            {
                willMultiply = false;
            }
        }
        if (willMultiply)
        {
            for (int i = 0; i < amount; i++)
            {
                if (canMultiply)
                {
                    GameObject newBall = Instantiate(gameObject, transform.position + new Vector3(transform.localScale.x * (float)(i + 1), 0f, 0f), transform.rotation);
                    newBall.GetComponent<Rigidbody>().velocity = rb.velocity;
                    newBall.GetComponent<MultiplyBall>().SetUsedGates(sourcesUsed);
                }
            }
            sourcesUsed.Add(source);
        }
    }

    public void SetUsedGates(List<MultiplierGate> value)
    {
        foreach(MultiplierGate gate in value)
        {
            sourcesUsed.Add(gate);
        }
    }
}
