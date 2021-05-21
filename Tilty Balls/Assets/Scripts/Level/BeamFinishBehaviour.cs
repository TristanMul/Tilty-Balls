using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFinishBehaviour : MonoBehaviour
{
    BeamController beamController;
    Rigidbody rotateRb;
    [SerializeField] Transform pullUpBar;


    // Start is called before the first frame update
    void Start()
    {
        beamController = GetComponent<BeamController>();
        rotateRb = beamController.rotateRb;
        GameEventManager.instance.reachFinish += OnFinish;
    }

    void OnFinish()
    {
        StartCoroutine(RotateTowardsTargetRotation(1f));
    }
    IEnumerator RotateTowardsTargetRotation(float duration)
    {
        Debug.Log("Tilt");

        float currentTime = 0f;
        Quaternion targetRotation = new Quaternion(0.0f, 0.0f, -0.2f, 1.0f);
        while (currentTime < 1f)
        {
            //Rotate the part
            currentTime += Time.deltaTime / duration * 2f;
            rotateRb.transform.rotation = Quaternion.Lerp(rotateRb.transform.rotation, targetRotation, currentTime);


            yield return null;
        }
        currentTime = 0f;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime / duration * 2f;
            pullUpBar.position = Vector3.Lerp(pullUpBar.position, pullUpBar.position + transform.up * .1f, currentTime);
            yield return null;
        }
    }
}
