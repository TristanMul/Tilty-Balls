using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierGate : MonoBehaviour
{
    [SerializeField] int amount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(this);
            other.GetComponent<MultiplyBall>().Multiply(amount, this);
        }
    }
}
