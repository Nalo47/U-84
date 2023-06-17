using UnityEngine;

public class characterController : MonoBehaviour
{
    private float inputX;
    private float inputY;
    public Transform model;
    private Animator _anim;
    private Vector3 stickDirection;
    private Camera mainCam;
    public float damp;
    [Range(1,20)] public float rotationSpeed;
    void Start()
    {
        _anim = GetComponent<Animator>();
        Debug.Log("animator cachlendi");
        mainCam = Camera.main;
    }
    void LateUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        stickDirection = new Vector3(inputX, 0, inputY);
        inputMove();
        inputRotation();
    }

    void inputMove()
    {
        _anim.SetFloat("speed", Vector3.ClampMagnitude(stickDirection, 1).magnitude,damp,Time.deltaTime*10);
    }

    void inputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(stickDirection);
        rotOfset.y = 0;
        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
}
