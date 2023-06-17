using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLook : MonoBehaviour
{
    private Animator _anim;
    private Camera mainCam;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        mainCam=Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _anim.SetLookAtWeight(1f,.5f,1.2f,.5f,.5f);
        Ray lookAtRay = new Ray(transform.position, mainCam.transform.forward);
        _anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }
}
