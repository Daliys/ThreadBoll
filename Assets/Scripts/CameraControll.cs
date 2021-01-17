using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 50f;

    private Vector3 cameraStartDistanceToPlayer;

    private Touch initTouch = new Touch();
    private Vector3 cameraOriginRotation;
    private float rotX = 0f;
    private float dir = -1;

    void Start()
    {
        cameraStartDistanceToPlayer = transform.position - player.transform.position;
        cameraStartDistanceToPlayer.y = transform.position.y;

        cameraOriginRotation = transform.eulerAngles;
        rotX = cameraOriginRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position - player.transform.position != cameraStartDistanceToPlayer)
        {
            Vector3 movementDistance = cameraStartDistanceToPlayer + player.transform.position;
            movementDistance.y = cameraStartDistanceToPlayer.y;
            transform.position = movementDistance;
        }

        transform.LookAt(player.transform);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = -(initTouch.position.x - touch.position.x);
                deltaX /= Screen.width;
                Quaternion camTurnAngle = Quaternion.AngleAxis(deltaX * rotationSpeed, Vector3.up);
                cameraStartDistanceToPlayer = camTurnAngle * cameraStartDistanceToPlayer;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }


        //   Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
        //    cameraStartDistanceToPlayer = camTurnAngle * cameraStartDistanceToPlayer;


    }

    private void FixedUpdate()
    {/*
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = -(initTouch.position.x - touch.position.x);
                deltaX /= Screen.width;
                Quaternion camTurnAngle = Quaternion.AngleAxis(deltaX * rotationSpeed, Vector3.up);
                cameraStartDistanceToPlayer = camTurnAngle * cameraStartDistanceToPlayer;
                //rotX += deltaX * Time.deltaTime * rotationSpeed * dir;
                //cameraStartDistanceToPlayer = rotX * cameraStartDistanceToPlayer;
                //  transform.eulerAngles = new Vector3(0, rotX, 0);
                // print(rotX);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }

        */

   
    }
}
