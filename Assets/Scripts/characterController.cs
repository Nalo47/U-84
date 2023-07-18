using System;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [Header("Metrics")] public float damp;
    [Range(1, 20)] public float rotationSpeed;
    [Range(1, 20)] public float strafeTurnSpeed;
    float normalFov;
    public float sprintFov;

    private float inputX;
    private float inputY;
    public Transform model;
    private Animator _anim;
    private Rigidbody _rb;
    private Vector3 stickDirection;
    private Camera mainCam;

    float maxSpeed;
    public KeyCode sprintButton = KeyCode.LeftShift;
    public KeyCode walkButton = KeyCode.C;
    public KeyCode jumpButton = KeyCode.Space;
    public float jumpForce = 12f;
    public enum MovementType
    {
        Directional,
        Strafe
    };

    public MovementType hareketTipi;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;
    }

    void LateUpdate()
    {
        inputMove();
        inputRotation();
        movement();
    }

    void inputMove()
    {
        _anim.SetFloat("speed", Vector3.ClampMagnitude(stickDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10);
    }

    void inputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(stickDirection);
        rotOfset.y = 0;
        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }

    void movement()
    {
        if (hareketTipi == MovementType.Strafe)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            _anim.SetFloat("iX", inputX, damp, Time.deltaTime * 10);
            _anim.SetFloat("iY", inputY, damp, Time.deltaTime * 10);

            var hareketEdiyor = inputX != 0 || inputY != 0;

            if (hareketEdiyor)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0),
                    strafeTurnSpeed * Time.fixedDeltaTime);
                _anim.SetBool("strafeMoving", true);
            }
            else
            {
                _anim.SetBool("strafeMoving", false);
            }
        }


        if (hareketTipi == MovementType.Directional)
        {
            stickDirection = new Vector3(inputX, 0, inputY);
            if (Input.GetKey(sprintButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);
                maxSpeed = 2;
                inputX = 2 * Input.GetAxis("Horizontal");
                inputY = 2 * Input.GetAxis("Vertical");
            }
            else if (Input.GetKey(walkButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 0.2f;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }
            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 1;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }
            if (Input.GetKeyDown(jumpButton))
            {
                _anim.SetTrigger("jump");
                Invoke("Jump", 0.8f);
            }
        }
        
    }
    void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01f) // Karakter zıplama sırasında havadaysa tekrar zıplamaması için kontrol
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}    