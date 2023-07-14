using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ýnsan")
        {
            CoinText.coinAmount += 1;
            Destroy(gameObject);
        }
    }
}
