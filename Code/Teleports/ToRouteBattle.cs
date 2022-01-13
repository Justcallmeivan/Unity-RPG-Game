using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRouteBattle : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 pos;

    public void Start()
    {
        if (PersistentValues.loadCustomLocation)
        {
            rb.position = PersistentValues.toPosition;
        }
        pos = rb.position;
    }
    public void Update()
    {
        if (Vector3.Distance(pos, rb.position) > 4)
        {
            //this is where you would add code for what enemies are created
            float r = Random.value;
            if (r * 100 <= 10)
            {
                PersistentValues.fromPosition = PersistentValues.currentPosition;
                PersistentValues.loadCustomLocation = false;
                SceneManager.LoadScene("Route Battlefield");
            }
                pos = rb.position;
        }
    }
}


