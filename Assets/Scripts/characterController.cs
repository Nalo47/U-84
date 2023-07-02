using UnityEngine;

public class characterController : MonoBehaviour
{
    [Header("Metrics")]
    public float damp;
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
   // public KeyCode jumpButton = KeyCode.Space;

   // bool canJump = true; 
   // public float jumpCooldown = 1.2f;

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
        if (hareketTipi==MovementType.Strafe)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");   
            
            _anim.SetFloat("iX",inputX,damp,Time.deltaTime*10);
            _anim.SetFloat("iY",inputY,damp,Time.deltaTime*10);

            var hareketEdiyor = inputX != 0 || inputY != 0;

            if (hareketEdiyor)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,yawCamera,0),strafeTurnSpeed*Time.fixedDeltaTime );
                _anim.SetBool("strafeMoving",true);
            }
            else
            {
                _anim.SetBool("strafeMoving",false);
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

            /* Zıplama kontrolü
            if (canJump && Input.GetKeyDown(jumpButton))
            {
                Jump();
            }
            */
        }
        
        
        
        
        
        
        
        
        
        
    }

   /* void Jump()
    {
      //  _anim.SetTrigger("Jump");  Zıplama animasyonu trigger
        _rb.AddForce(Vector3.up * 5, ForceMode.Impulse); 
        canJump = false; 
        Invoke(nameof(ResetJump), jumpCooldown); //resetjump icin bekleme suresi
    }

    void ResetJump()
    {
        canJump = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; 
        }
    }
    */
}
 