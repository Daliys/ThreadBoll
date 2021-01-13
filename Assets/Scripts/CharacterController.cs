using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;
    private Transform camera;
    public float turnSmothTime = 0.1f;
    public float turnSmothVelocity;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left ) + (Input.GetAxis("Vertical") * Vector3.forward );
       // rigidbody.AddForce(movement * Time.deltaTime, ForceMode.Force);

        Vector3 moveDirection = Vector3.zero;
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmothVelocity, turnSmothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //print(movementHorizontal + "   " + moveDirection.x);
            rigidbody.AddForce(moveDirection * Time.deltaTime * speed, ForceMode.Force);
        }

        //Vector3 move = moveDirection * speed;
        //move.y = velocity.y;

       // characterController.Move(move * Time.deltaTime);
       //

    }
}
