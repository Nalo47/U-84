using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkurDead : MonoBehaviour
{
    public Transform respawnPoint;  // Yeniden doðma konumunu Unity editöründe belirleyin.

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;  // Karakterin baþlangýç pozisyonunu saklayýn.
    }

    private void Update()
    {
        // Karakterin hareket mantýðý buraya gelecek.
        // Basitlik için hareket için bir giriþ mekanizmasý olduðunu varsayalým.

        // Örnek olarak yatay ve dikey eksenlere sahip hareket giriþi:
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
        // Karakter kontrolünü devre dýþý býrakýn veya ölümle ilgili baþka eylemler gerçekleþtirin.

        // Karakteri belirtilen respawnPoint pozisyonunda yeniden doðurun.
        transform.position = respawnPoint.position;
    }
}