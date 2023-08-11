using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Rigidbody door;
    [SerializeField] LayerMask layermask;

    private float speed = 1f;
    private Vector3 direction = new Vector3(0, 1, 0).normalized;

    float raycastDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, raycastDistance, ~layermask))
        {
            if (door.transform.position.y >= 11f)
            {
                door.velocity = Vector3.zero;
                return;
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);

            door.AddForce(direction * speed);
        }
        else
        {
            if (door.transform.position.y <= 4f)
            {
                door.velocity = Vector3.zero;
                return;
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.green);

            door.AddForce(-direction * speed);
        }
    }
}
