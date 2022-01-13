using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool IsInputEnabled = true;

    // code from youtube video
    public Rigidbody rb;
    public float moveSpeed = 10;
    public float jumpSpeed;
    private Vector2 moveInput;
    public float playerY = 1.61f;
    public Vector3 rotation = new Vector3(0, 0, 0);
    public GameObject lantern;
    void Start()
    {
        if(PersistentValues.loadCustomLocation) {
            rb.position = PersistentValues.toPosition;
            PersistentValues.loadCustomLocation = false;
        }
    }
       

    void Update()
    {
        // esc to exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        if (PlayerController.IsInputEnabled)
        {
            moveInput.x = Input.GetAxis("Horizontal"); 
            moveInput.y = Input.GetAxis("Vertical");
            moveInput.Normalize();
            rb.velocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
            if (lantern != null)
            {
                if (moveInput.x > 0)
                {
                    lantern.transform.localPosition = new Vector3(.6f, -.03f, -56f);
                }
                else if (moveInput.x < 0)
                {
                    lantern.transform.localPosition = new Vector3(-.6f, -.03f, -56f);
                }
            }
        }
        //transform.position = rb.position;
        rb.angularVelocity = new Vector3(0, 0, 0);
        Quaternion q = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        rb.rotation = q;
        rb.position = new Vector3(rb.position.x, playerY, rb.position.z);
        PersistentValues.currentPosition = rb.position;


    }
}
