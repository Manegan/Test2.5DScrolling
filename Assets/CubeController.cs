using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    private Rigidbody rb;

    [Range(0, 1)]
    public float speed;
    public GameObject MovementSpace;
    public GameObject SpaceConnector;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.velocity = Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = Vector3.left * speed;
        }

        if (Input.GetKeyUp(KeyCode.Z) ||
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.Q))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(SpaceConnector.transform.position, SpaceConnector.transform.forward, out hit))
        {
            if (hit.transform.tag.Equals("MovementSpace"))
            {
                if (hit.distance > 11)
                {
                    transform.position += -hit.normal * Time.fixedDeltaTime;
                }
                else if (hit.distance < 9)
                {
                    transform.position += hit.normal * Time.fixedDeltaTime;
                }
            }
        }
    }
}
