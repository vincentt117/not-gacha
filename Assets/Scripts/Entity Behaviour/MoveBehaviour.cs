using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    public Transform target;
    private Vector3 _input;
    public bool isEnabled = false;

    private void Update()
    {
        if (!isEnabled)
        {
            return;
        }

        Turn();
    }

    private void FixedUpdate()
    {
        if (!isEnabled)
        {
            return;
        }

        Move();
    }

    private void Turn()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = _turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * 1 * _speed * Time.deltaTime);
    }
}