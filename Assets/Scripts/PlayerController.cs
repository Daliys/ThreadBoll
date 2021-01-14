using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public GameObject groundChecker;
    public LayerMask layerMask;
    public float groundDistance;
    public Material coloringMaterial;

    private Rigidbody rigidbody;
    private Transform camera;
    private bool isGrounded;
    private Vector3 moveDirection;
    private float velociryY;


    Vector3 startPosition;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
        startPosition = transform.position;
    }



    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.transform.position, groundDistance, layerMask);
        if (isGrounded && velociryY < 0)
        {
            velociryY = -2f;
        }
     
        velociryY += gravity * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        moveDirection = Quaternion.Euler(0f, camera.eulerAngles.y, 0f) * Vector3.forward * speed;
        moveDirection.y = velociryY;
        rigidbody.velocity = moveDirection;

        moveDirection = Vector3.zero;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death") transform.position = startPosition;
        if (other.tag == "Yarn") other.gameObject.GetComponent<MeshRenderer>().material = coloringMaterial;

        print(other.name);
    }
}
