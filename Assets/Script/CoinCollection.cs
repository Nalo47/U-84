using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinCollection : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _text;
    private int count=0;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            count++;
            _text.text = count.ToString();
           

        }
    }

   
}
