using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator _anim;

    private void Start()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
    }

    

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _anim.SetTrigger("die");
        Debug.Log("rakip ded oldu");
        
    }
}