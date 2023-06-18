using UnityEngine;

public class characterController : MonoBehaviour
{
    [Header("Metrics")]
    public float damp;
    [Range(1, 20)] public float rotationSpeed;
    float normalFov;
    public float sprintFov;

    private float inputX;
    private float inputY;
    public Transform model;
    private Animator _anim;
    private Vector3 stickDirection;
    private Camera mainCam;
    
    float maxSpeed;
    public KeyCode sprintButton = KeyCode.LeftShift;
    public KeyCode walkButton = KeyCode.C;
    void Start()
    {
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
        _anim.SetFloat("speed", Vector3.ClampMagnitude(stickDirection, maxSpeed).magnitude,damp,Time.deltaTime*10);
    }

    void inputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(stickDirection);
        rotOfset.y = 0;
        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
    void movement() 
    {
        stickDirection = new Vector3(inputX, 0, inputY);
        if (Input.GetKey(sprintButton)) 
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov,Time.deltaTime*2);
            maxSpeed = 2;
            inputX = 2 *Input.GetAxis("Horizontal");
            inputY = 2 *Input.GetAxis("Vertical");
        }
        else if(Input.GetKey(walkButton))
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
    }
}
