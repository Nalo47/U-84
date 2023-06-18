using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    private bool isStrafe;
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetBool("iS",isStrafe);
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

        if (isStrafe == true)
        {
            GetComponent<characterController>().hareketTipi = characterController.movementType.Strafe;
        }
        if (isStrafe == false)
        {
            GetComponent<characterController>().hareketTipi = characterController.movementType.Directional;
        }
    }
}
