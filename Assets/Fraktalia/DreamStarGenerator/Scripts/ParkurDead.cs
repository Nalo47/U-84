using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkurDead : MonoBehaviour
{
    public Transform respawnPoint;  // Yeniden do�ma konumunu Unity edit�r�nde belirleyin.

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;  // Karakterin ba�lang�� pozisyonunu saklay�n.
    }

    private void Update()
    {
        // Karakterin hareket mant��� buraya gelecek.
        // Basitlik i�in hareket i�in bir giri� mekanizmas� oldu�unu varsayal�m.

        // �rnek olarak yatay ve dikey eksenlere sahip hareket giri�i:
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalMovement, 0f, verticalMovement) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Karakter kontrol�n� devre d��� b�rak�n veya �l�mle ilgili ba�ka eylemler ger�ekle�tirin.

        // Karakteri belirtilen respawnPoint pozisyonunda yeniden do�urun.
        transform.position = respawnPoint.position;
    }
}