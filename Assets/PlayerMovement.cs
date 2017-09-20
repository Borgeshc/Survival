using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed;
    public float rotationSpeed;

    public int normalFov;
    public int sprintFov;

    float speed;

    Vector3 movement;
    Vector3 rotation;

    PlayerStates playerStates;
    Rigidbody rb;

    private void Start()
    {
        playerStates = GetComponent<PlayerStates>();
        rb = GetComponent<Rigidbody>();

        speed = baseSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update ()
    {
        Turn();

        if (!playerStates.isSprinting)
            Move();
        else
            Sprint();
	}

    void Move()
    {
        if (Camera.main.fieldOfView != normalFov)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normalFov, 1.5f * Time.deltaTime);

        movement = new Vector3(playerStates.moveHorizontal * speed * Time.deltaTime, 0, playerStates.moveVertical * speed * Time.deltaTime);

        movement = transform.TransformDirection(movement);
        rb.velocity = movement;
    }

    void Sprint()
    {
        if (Camera.main.fieldOfView != sprintFov)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, sprintFov, 1.5f * Time.deltaTime);

        movement = new Vector3(playerStates.moveHorizontal * (speed * 1.5f) * Time.deltaTime, 0, playerStates.moveVertical * (speed * 1.5f) * Time.deltaTime);

        movement = transform.TransformDirection(movement);
        rb.velocity = movement;
    }

    void Turn()
    {
        transform.Rotate(transform.up, playerStates.lookHorizontal * rotationSpeed * Time.deltaTime);
        rotation = new Vector3(-playerStates.lookVertical * rotationSpeed * Time.deltaTime, 0, 0);
        Camera.main.transform.Rotate(rotation);
    }
}
