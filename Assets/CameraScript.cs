using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject MovementSpace;
    public GameObject Follow;
    public float Distance;

    public float smoothSpeed = 0.25f;
    public Vector3 offset;
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag.Equals("MovementSpace"))
            {
                Vector3 rotation = transform.position - (hit.normal * -1);
                transform.rotation = Quaternion.LookRotation(-hit.normal);
            }
        }
        if (Mathf.Abs(transform.position.magnitude - Follow.transform.position.magnitude) > Distance)
        {

        } else if (Mathf.Abs(transform.position.magnitude - Follow.transform.position.magnitude) < Distance)
        {

        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Follow.transform.position + offset, smoothSpeed * Time.deltaTime);
    }
}
