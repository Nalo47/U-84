 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZararVerme : MonoBehaviour
{
    Camera kamera;
    public LayerMask düsmanKatman;
    KarakterKontrol hpKontrol;   //KarakterKontrol = dosya ismi
    void Start()
    {
        kamera = Camera.main;
        hpKontrol = this.gameObject.GetComponent<KarakterKontrol>(); //burdada9.satýr gibi
    }

    // Update is called once per frame
    void Update()
    {
        if(hpKontrol.YasiyorMu() == true)
        {
            if (Input.GetMouseButton(0))
            {
                AtesEtme();
            }
        }
        
    }
    private AtesEtme()
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, düsmanKatman))
        {
            hit.collider.gameObject.GetComponent<Düsman>().HasarAl();
        }

    }
}
