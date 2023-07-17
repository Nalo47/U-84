using UnityEngine;

public class YazýKaybolma : MonoBehaviour
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
