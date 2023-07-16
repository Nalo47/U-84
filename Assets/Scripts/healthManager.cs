using UnityEngine;
using UnityEngine.SceneManagement;
public class healthManager : MonoBehaviour
{
        public int maxHealth = 100; // Maksimum sağlık değeri
        public int currentHealth; // Mevcut sağlık değeri
    
        
        
        private void Start()
        {
            currentHealth = maxHealth; 
            Scene currentScene = SceneManager.GetActiveScene();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Sword"))
            {
                TakeDamage(1);
            }
        }

        public void TakeDamage(int damageAmount)
        {
            Debug.Log("HASAR ALDI");
            currentHealth -= damageAmount; // Zarar miktarını mevcut sağlık değerinden çıkar
    
            if (currentHealth <= 0)
            {
                Die(); // Sağlık değeri 0 veya daha az ise karakter ölsün
            }
        }
    
        private void Die()
        {
            Debug.Log("Karakter öldü!");
            Destroy(this.gameObject);
            Restart();
        }
        public void Restart()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
}
