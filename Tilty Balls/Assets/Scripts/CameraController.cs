using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform finalStageCameraPosition;
    [SerializeField] float transitionDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionToFinalStage(){
        transform.parent = null;
        StartCoroutine(MoveToFinalStageCameraPosition());
    }

    IEnumerator MoveToFinalStageCameraPosition(){
        float currentTime = 0f;
        Vector3 startPosition = transform.position;
        while(currentTime < 1f){
            currentTime = currentTime += Time.deltaTime / transitionDuration * 2f;
            transform.position = Vector3.Lerp(startPosition, finalStageCameraPosition.position, currentTime);
            yield return null;
        }
    }
}
