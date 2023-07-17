using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class bookCollection : MonoBehaviour
    
{
    public AudioClip typeSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            audioSource.PlayOneShot(typeSound);
            Destroy(gameObject);
        }
    }
}
