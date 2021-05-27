using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFinishBehaviour : MonoBehaviour
{
    BeamController beamController;
    Rigidbody rotateRb;
    [SerializeField] Transform pullUpBar;
    [SerializeField] Transform pullUpCollider;
    [SerializeField] GameEvent onTransitionToFinalStage;

    // Start is called before the first frame update
    void Start()
    {
        beamController = GetComponent<BeamController>();
        rotateRb = beamController.rotateRb;
    }

    public void OnFinish()
    {
        pullUpCollider.gameObject.SetActive(false);
        StartCoroutine(RotateTowardsTargetRotation(1f));
    }

    IEnumerator RotateTowardsTargetRotation(float duration)
    {
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
        Vector3 originalBarPosition = pullUpBar.position;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime / duration * 2f;
            pullUpBar.position = Vector3.Lerp(originalBarPosition, originalBarPosition + -pullUpBar.transform.right * 2f, currentTime);
            yield return null;
        }
        onTransitionToFinalStage.Raise();
    }
}
