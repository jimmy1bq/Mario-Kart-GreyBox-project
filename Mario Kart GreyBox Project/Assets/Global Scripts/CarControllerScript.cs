using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    Rigidbody carRigidbody;
    [SerializeField] WheelCollider rightFrontWheel, leftFrontWheel, rightBackWheel, leftBackWheel;
    [SerializeField] GameObject rightFrontWheelMesh, leftFrontWheelMesh;
    [SerializeField] Camera firstPerCam, thirdPerCam;
    [SerializeField] float steerSpeed, driveSpeed;
    float horizontalInput, verticalInput;
    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
        thirdPerCam.enabled = false;
        //rightFrontWheel = transform.Find("RIghtFrontWheel").GetComponent<WheelCollider>();
        //rightBackWheel = transform.Find("RightBackWheel").GetComponent<WheelCollider>();
        //leftFrontWheel = transform.Find("LeftFrontWheel").GetComponent<WheelCollider>();
        //leftBackWheel = transform.Find("LeftBackWheel").GetComponent<WheelCollider>();

    }
    void Start()
    {
        //carRigidbody.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rightFrontWheelMesh.transform.localEulerAngles = new Vector3(transform.eulerAngles.x, rightFrontWheel.steerAngle - transform.eulerAngles.y, transform.eulerAngles.z);
        leftFrontWheelMesh.transform.localEulerAngles = new Vector3(transform.eulerAngles.x, rightFrontWheel.steerAngle - transform.eulerAngles.y, transform.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (thirdPerCam.enabled == false) { thirdPerCam.enabled = true; firstPerCam.enabled = false; }
            else { thirdPerCam.enabled = false; firstPerCam.enabled = true; }
        }
        
    }

    private void FixedUpdate()
    {
       float motor = Input.GetAxis("Vertical") * driveSpeed;
        Debug.Log(motor);
        rightFrontWheel.motorTorque= motor;
        leftFrontWheel.motorTorque= motor;
        rightBackWheel.motorTorque= motor;
        leftBackWheel.motorTorque= motor;
        rightFrontWheel.steerAngle = horizontalInput * steerSpeed;
        leftFrontWheel.steerAngle = horizontalInput * steerSpeed;
        WheelHit hit;
        bool isGrounded = leftFrontWheel.GetGroundHit(out hit);
        Debug.Log("Left front grounded: " + isGrounded + " | Force: " + hit.force);
    }
}
