using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCounter : MonoBehaviour
{
    [SerializeField] private GameEvent onFinishGame;
    private int amountOfBalls = 0;
    private bool ballsEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        amountOfBalls++;
            ballsEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            amountOfBalls--;
        }
        if(amountOfBalls == 0 && ballsEntered)
        {
            onFinishGame.Raise();
        }
    }
}
