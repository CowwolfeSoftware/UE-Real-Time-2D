
using UnityEngine;

public class PegControls : MonoBehaviour
{
    public AudioClip bumpSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(bumpSound);
    }
}
