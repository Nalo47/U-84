using UnityEngine;

public class Yaz�Kaybolma : MonoBehaviour
{
    public float delay = 3f; 

    private void Start()
    {
        Invoke("DisableText", delay);
    }

    private void DisableText()
    {
        gameObject.SetActive(false);
    }
}
