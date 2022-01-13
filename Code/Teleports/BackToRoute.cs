using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToRoute : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            PersistentValues.toPosition = PersistentValues.fromPosition;
            PersistentValues.loadCustomLocation = true;
            SceneManager.LoadScene("Route");
        }
    }
}

