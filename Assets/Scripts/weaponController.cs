using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject trails;
    
    private bool canAttack = true;
    private bool isStrafe = false;
    private Animator _anim;

    public GameObject handSword;
    public GameObject backSword;
    void Start()
    {
        _anim = GetComponent<Animator>();
        trailClose();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("iS", isStrafe);
        if (Input.GetKeyDown(KeyCode.F) && _anim.GetBool("isAttack")==false)
        {
            isStrafe = !isStrafe;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isStrafe == true && canAttack == true)
        {
            _anim.SetTrigger("Saldır");
        }
        
        if (isStrafe == true)
        {
            GetComponent<characterController>().hareketTipi = characterController.MovementType.Strafe;
            GetComponent<IKLook>().azal();
        }
        if (isStrafe == false)
        {
            GetComponent<characterController>().hareketTipi = characterController.MovementType.Directional;
            GetComponent<IKLook>().art();
        }
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

    public void trailOpen()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = true;
        }
    }

    public void trailClose()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
    }
}
