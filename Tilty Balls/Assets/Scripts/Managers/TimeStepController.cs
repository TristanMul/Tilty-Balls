using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStepController : MonoBehaviour
{
    private void Awake() {
        RaiseTimeStep();
    }

    public void RaiseTimeStep(){
        Time.fixedDeltaTime = 0.02f;
    }

    public void LowerTimeStep(){
        Time.fixedDeltaTime = 0.002f;
    }
}
