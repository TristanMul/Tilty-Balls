using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyBall : MonoBehaviour
{

    List<MultiplierGate> sourcesUsed = new List<MultiplierGate>();
    bool canMultiply;
    private void Start()
    {
        StartCoroutine(WaitAndEnableMultiply(.3f));
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
                    Instantiate(gameObject);
                }
            }
            sourcesUsed.Add(source);
        }
    }
}
