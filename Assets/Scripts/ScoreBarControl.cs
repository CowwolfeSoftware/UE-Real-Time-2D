using UnityEngine;

public class ScoreBarControl : MonoBehaviour
{
    public AudioClip bumpSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Planet")
            audioSource.PlayOneShot(bumpSound);
    }
}
