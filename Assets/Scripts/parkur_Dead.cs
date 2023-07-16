using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkur_Dead : MonoBehaviour
{
    public Transform respawnPoint;  // Yeniden doðma konumunu Unity Editöründe belirleyin.
    public LayerMask groundLayer;  // Zeminin layer'ýný ayarlayýn.

    private bool isDead = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;  // Karakterin baþlangýç pozisyonunu saklayýn.
    }

    private void Update()
    {
        if (!isDead)
        {
            // Karakterin hareket mantýðý buraya gelecek.
            // Basitlik için hareket için bir giriþ mekanizmasý olduðunu varsayalým.

            // Örnek olarak yatay ve dikey eksenlere sahip hareket giriþi:
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontalMovement, 0f, verticalMovement) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            Die();
        }
    }

    private void Die()
    {
        // Karakterin ölümüyle ilgili eylemleri gerçekleþtirin.

        isDead = true;
        // Ýsteðe baðlý olarak animasyon oynatabilir, ses efekti çalabilir veya diðer özel eylemler gerçekleþtirebilirsiniz.

        // Karakteri belirtilen respawnPoint pozisyonunda yeniden doðurun.
        transform.position = respawnPoint.position;

        // Ýsteðe baðlý olarak ölüm animasyonu tamamlandýktan sonra karakterin kontrolünü yeniden etkinleþtirebilirsiniz.
        Invoke("EnableControl", 1f);
    }

    private void EnableControl()
    {
        isDead = false;
        // Karakterin kontrolünü yeniden etkinleþtirin.
    }
}