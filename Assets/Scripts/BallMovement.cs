using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallController))]
public class BallMovement : MonoBehaviour
{
    [Header("Fall")]
    [SerializeField] private float fallSpeedDefault;
    [SerializeField] private float fallSpeedMax;
    [SerializeField] private float fallSpeedAcceleration;
    [SerializeField] private float fallHeight;


    private float fallSpeed;


    private Animator animator;
    private float floorY;

    private void Start()
    {
        enabled = false;    // turns off Update
        animator= GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.position.y > floorY) // setting up floorY
        {
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0); // identical line, movement in local coordinates
            /*transform.position += Vector3.down * fallSpeed * Time.deltaTime; // identical line, movement in global coordinates, Vector3.down = (0, -1, 0)*/
            
            if(fallSpeed < fallSpeedMax)
            {
                fallSpeed += fallSpeedAcceleration * Time.deltaTime; 
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            enabled = false;
        }

    }

    public void Jump()
    {
        animator.speed = 1;
        fallSpeed = fallSpeedDefault;
        Debug.Log("Jump!");
    }

    public void Fall(float startFloorY) // startFloorY = transform.position.Y
    {
        animator.speed = 0; // stop Animator component
        enabled= true;
        floorY = startFloorY - fallHeight;

        Debug.Log("Fall!");
    }

    public void Stop()
    {
        animator.speed = 0;
        Debug.Log("Stop!");
        enabled = false;
    }
}
