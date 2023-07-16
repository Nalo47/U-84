using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkur_Dead : MonoBehaviour
{
    public Transform respawnPoint;  // Yeniden do�ma konumunu Unity Edit�r�nde belirleyin.
    public LayerMask groundLayer;  // Zeminin layer'�n� ayarlay�n.

    private bool isDead = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;  // Karakterin ba�lang�� pozisyonunu saklay�n.
    }

    private void Update()
    {
        if (!isDead)
        {
            // Karakterin hareket mant��� buraya gelecek.
            // Basitlik i�in hareket i�in bir giri� mekanizmas� oldu�unu varsayal�m.

            // �rnek olarak yatay ve dikey eksenlere sahip hareket giri�i:
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
        // Karakterin �l�m�yle ilgili eylemleri ger�ekle�tirin.

        isDead = true;
        // �ste�e ba�l� olarak animasyon oynatabilir, ses efekti �alabilir veya di�er �zel eylemler ger�ekle�tirebilirsiniz.

        // Karakteri belirtilen respawnPoint pozisyonunda yeniden do�urun.
        transform.position = respawnPoint.position;

        // �ste�e ba�l� olarak �l�m animasyonu tamamland�ktan sonra karakterin kontrol�n� yeniden etkinle�tirebilirsiniz.
        Invoke("EnableControl", 1f);
    }

    private void EnableControl()
    {
        isDead = false;
        // Karakterin kontrol�n� yeniden etkinle�tirin.
    }
}