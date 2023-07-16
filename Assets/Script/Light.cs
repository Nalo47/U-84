using UnityEngine;

public class Light : MonoBehaviour
{
    internal int intensity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinText.coinAmount += 1;
            Destroy(gameObject);
        }
    }
}
