using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]

public class writerEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip typeSound;
    [Multiline]
    public string text;
    private AudioSource audioSource;
    private TMP_Text tmpText;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tmpText = GetComponent<TMP_Text>();

        StartCoroutine(TypeWrite());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator TypeWrite()
    {
        foreach (char c in text)
        {
            tmpText.text += c.ToString();

            audioSource.pitch = Random.Range(0.6f, 1.1f);
            audioSource.PlayOneShot(typeSound);

            if (c.ToString() == ".")
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}