using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float angleOpened = 110;
    public float angleClosed = 0;
    public float openTime = 1;

    // sound stuff
    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    public AudioSource openDoorAudioSource;
    public AudioSource closeDoorAudioSource;

    // privates
    Quaternion rotOpened;
    Quaternion rotClosed;
    bool isOpening = false;
    bool isClosed = true;
    float changeSign;

    void Start()
    {
        rotOpened = Quaternion.Euler(0, angleOpened, 0);
        rotClosed = Quaternion.Euler(0, angleClosed, 0);
    }

    private void OnMouseDown()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        // reverse direction if already running
        if (isOpening)
        {
            changeSign = -1 * changeSign;
            isClosed = !isClosed;

            if (isClosed)
            {
                openDoorAudioSource.PlayOneShot(openDoorSound);
            }
            else
            {
                openDoorAudioSource.PlayOneShot(closeDoorSound);
            }
            yield break;
        }

        isOpening = true;
        float interpolationParameter;

        // set lerp parameter and sign to match animation
        if (isClosed)
        {
            interpolationParameter = 0;
            changeSign = 1;
            openDoorAudioSource.PlayOneShot(openDoorSound);
        }
        else
        {
            interpolationParameter = 1;
            changeSign = -1;
            openDoorAudioSource.PlayOneShot(closeDoorSound);
        }

        while (isOpening)
        {
            interpolationParameter = interpolationParameter + changeSign * Time.deltaTime / openTime;

            if (interpolationParameter >= 1 || interpolationParameter <= 0)
            {
                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);
                isOpening = false;
            }

            // set rotation
            transform.localRotation = Quaternion.Lerp(rotClosed, rotOpened, interpolationParameter);

            yield return null;
        }

        isClosed = !isClosed;
    }
}