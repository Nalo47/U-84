using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    private bool isStrafe = false;
    private Animator _anim;

    public GameObject handSword;
    public GameObject backSword;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("iS", isStrafe);
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

        if (isStrafe == true)
        {
            GetComponent<characterController>().hareketTipi = characterController.MovementType.Strafe;
        }
        if (isStrafe == false)
        {
            GetComponent<characterController>().hareketTipi = characterController.MovementType.Directional;
        }

        void equip()
        {
            backSword.SetActive(false);
            handSword.SetActive(true);
        }

        void unequip()
        {
            backSword.SetActive(true);
            handSword.SetActive(false);
        }
        
        
    }
}
