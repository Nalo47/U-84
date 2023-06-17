using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef obje
    public float distance = 2.0f; // Kamera ile hedef aras�ndaki mesafe
    public float height = 1.0f; // Kamera y�ksekli�i
    public float smoothSpeed = 20.0f; // Kamera takip hareketinin yumu�akl���

    private Vector3 offset;

    void Start()
    {
        // Hedef objeden kamera offset'i hesapla
        offset = target.position - transform.position;
    }

    void FixedUpdate()
    {
        // Hedef objenin y�n�ne g�re kamera pozisyonunu hesapla
        float desiredAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        Vector3 desiredPosition = target.position - (rotation * offset);

        // Hedef pozisyonu ve kamera pozisyonunu yumu�ak bir �ekilde ge�i� yaparak g�ncelle
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Kamera hedef objeye do�ru bakacak �ekilde rotasyonunu ayarla
        transform.LookAt(target.position + Vector3.up * height);
    }
}

