using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public string Kutuphanelabirent;

    
    private void OnTriggerEnter(Collider other)
    {
        // Temas eden þey oyuncu ise
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(Kutuphanelabirent);
        }
    }
}
