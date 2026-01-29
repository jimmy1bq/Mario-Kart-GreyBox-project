using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    Rigidbody carRigidbody;
    WheelCollider rightFrontWheel, leftFrontWheel, rightBackWheel, leftBackWheel;
    [SerializeField] float steerSpeed, driveSpeed;
    float horizontalInput, verticalInput;
    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
        rightFrontWheel = transform.Find("RIghtFrontWheel").GetComponent<WheelCollider>();
        rightBackWheel = transform.Find("RightBackWheel").GetComponent<WheelCollider>();
        leftFrontWheel = transform.Find("LeftFrontWheel").GetComponent<WheelCollider>();
        leftBackWheel = transform.Find("LeftBackWheel").GetComponent<WheelCollider>();

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
    }
    private void FixedUpdate()
    {
       float motor = Input.GetAxis("Vertical") * driveSpeed;
        rightFrontWheel.motorTorque= motor;
        leftFrontWheel.motorTorque= motor;
        rightBackWheel.motorTorque= motor;
        leftBackWheel.motorTorque= motor;
        rightFrontWheel.steerAngle = horizontalInput * steerSpeed;
        leftFrontWheel.steerAngle = horizontalInput * steerSpeed;
    }
}
