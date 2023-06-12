using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;  // player hizi
    public float jumpForce = 5f;  // ziplama kuvveti
    public float dashDistance = 20f;  // dash mesafesi
    public float dashCooldown = 2f;  // dash bekleme süresi

    private Rigidbody rb;
    private bool isJumping = false;
    private bool isDashing = false;
    private float dashTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //caching rigidbody
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  //  yatay
        float moveZ = Input.GetAxis("Vertical");  // dikey

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime; 

        rb.MovePosition(transform.position + movement);

        if (Input.GetButtonDown("Jump") && !isJumping) // ziplama mekanigi
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }

        if (Input.GetButtonDown("Dash") && !isDashing && dashTimer <= 0f) // dash mekanigi
        {
            Vector3 dashDirection = new Vector3(moveX, 0f, moveZ).normalized;
            StartCoroutine(Dash(dashDirection));
        }

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision) // yere degme kontrolu
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private System.Collections.IEnumerator Dash(Vector3 direction) //dash fonksiyonu
    {
        isDashing = true;  
        rb.velocity = direction * dashDistance;
        dashTimer = dashCooldown;

        yield return new WaitForSeconds(0.1f);  // dash suresi

        rb.velocity = Vector3.zero;
        isDashing = false;
    }
}
