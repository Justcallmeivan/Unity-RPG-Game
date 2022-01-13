using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera panCamera;
    public Transform target;

    // animation params
    bool isAnimating = false;
    public float animationTime = 1;
    private Vector3 panStart;
    private Vector3 panEnd;
    public float waitTime = 2;

    private void Start()
    {
        // hardcoded pan position for now
        panEnd = new Vector3(target.position.x, target.position.y + 2.5f, target.position.z - 3.5f);
    }

    private void OnTriggerEnter()
    {
        // set panning camera start to current camera position
        panStart = mainCamera.transform.position;

        Debug.Log("entered door");
        StartCoroutine(Pan());
    }

    IEnumerator Pan()
    {
        // disable movement
        PlayerController.IsInputEnabled = false;
        // set cameras
        mainCamera.enabled = false;
        panCamera.enabled = true;

        float interpolationParameter = 0;
        if (isAnimating)
        {
            yield break;
        }

        isAnimating = true;
        while (isAnimating)
        {
            interpolationParameter = interpolationParameter + Time.deltaTime / animationTime;

            if (interpolationParameter >= 1)
            {
                interpolationParameter = 1;
                isAnimating = false;
            }

            panCamera.transform.position = Vector3.Lerp(panStart, panEnd, interpolationParameter);
            yield return null;
        }

        // wait         
        yield return new WaitForSeconds(waitTime);

        // pan back after wait
        isAnimating = true;
        interpolationParameter = 0;

        while (isAnimating)
        {
            interpolationParameter = interpolationParameter + Time.deltaTime / animationTime;

            if (interpolationParameter >= 1)
            {
                interpolationParameter = 1;
                isAnimating = false;
            }

            panCamera.transform.position = Vector3.Lerp(panEnd, panStart, interpolationParameter);
            yield return null;
        }

        // re-enable movement
        PlayerController.IsInputEnabled = true;
        // set cameras
        mainCamera.enabled = true;
        panCamera.enabled = false;
    }
}
