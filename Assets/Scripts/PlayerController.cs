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
    public UI uiObject;
   // public Cinemachine.CinemachineFreeLook cmFreelook;

    private Rigidbody rigidbody;
    private Transform camera;
    private bool isGrounded;
    private Vector3 moveDirection;
    private float velociryY;

    public float size;
    public bool isReachFinish;
    public Transform moveToFinishPosition;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
     
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
        if (!isReachFinish)
        {
            moveDirection = Quaternion.Euler(0f, camera.eulerAngles.y, 0f) * Vector3.forward * speed;
            moveDirection.y = velociryY;
            rigidbody.velocity = moveDirection;
            moveDirection = Vector3.zero;
        }
        else
        {
            UnwindingBall();
            if (transform.localScale == Vector3.zero) return;
            //moveDirection = -(transform.position - moveToFinishPosition.position).normalized * speed * 50 * Time.deltaTime;
            //print(-(transform.position - moveToFinishPosition.position).normalized);
            moveDirection = moveToFinishPosition.position;
            moveDirection.y = velociryY;
            moveDirection *= speed * 2f * 2f * Time.deltaTime;// * (  3 / size) * transform.localScale.x ;
            rigidbody.velocity = (moveDirection);//= moveDirection;
        }

    }
    private void UnwindingBall()
    {
        if (transform.localScale.x >= 0.4f) transform.localScale -= Vector3.one * (0.045f);//(3 / size / 2) * transform.localScale.x;// * (3 / size) * transform.localScale.x;
        else
        {
            transform.localScale = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void SetReachFinish()
    {
        isReachFinish = true;
        moveToFinishPosition.position = -(transform.position - moveToFinishPosition.position);
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {

            uiObject.ShowLosePanel();
        }
        if (other.tag == "Yarn")
        {
            YarnInformation info = other.GetComponent<YarnInformation>();
            if (info.isClear)
            {
                other.gameObject.GetComponent<MeshRenderer>().material = coloringMaterial;
                size += info.AddedSize;
                transform.localScale += Vector3.one * (info.AddedSize/5);
                info.isClear = false;
                uiObject.RefreshSizeUIText(size);
                Destroy(other.gameObject, 0.02f);
            }
        }

      //  print(other.name);
    }
}
