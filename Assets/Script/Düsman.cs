using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Düsman : MonoBehaviour
{
    public float düsmanHP = 100;
    Animator düsmanAnim;
    bool düsmanOlu;
    public float kovalamaMesafesi;
    public float saldirmaMesafesi;
    float mesafe;
    NavMeshAgent düsmanNavMesh;

    GameObject hedefOyuncu;
    void Start()
    {
        düsmanAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Remy"); //Parantez içine karakter ismi girilcek
        düsmanNavMesh = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (düsmanHP <= 0)
        {
            düsmanOlu = true;
        }
        if (düsmanOlu == true)
        {
            düsmanAnim.SetBool("oldu", true);
            StartCoroutine(YokOl());
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position); //harekert kodu
            if (mesafe < kovalamaMesafesi)
            {
                düsmanNavMesh.isStopped = false;
                düsmanNavMesh.SetDestination(hedefOyuncu.transform.position);
                düsmanAnim.SetBool("yuruyor", true); //yürüme animasyonu
                düsmanAnim.SetBool("saldiriyor", false); //Silebiliriz duruma göre
                this.transform.LookAt(hedefOyuncu.transform.position);

            }
            else
            {
                düsmanNavMesh.isStopped = true;
                düsmanAnim.SetBool("yuruyor", false);
                düsmanAnim.SetBool("saldiriyor", false);

                //durma animasyonu
            }
            if (mesafe < saldirmaMesafesi)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                düsmanNavMesh.isStopped = true;
                düsmanAnim.SetBool("yuruyor", false);
                if (düsmanHP > 20)
                {
                düsmanAnim.SetBool("saldiriyor", true);
                }

                //vurma animasyonu
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hit"))
        {
            Debug.Log("Rakibe vuruldu");
            HasarAl();
        }
    }

    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
    public void HasarAl()
    {
        düsmanHP -= Random.Range(5, 10);
    }
}
