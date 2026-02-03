using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource source;

    [SerializeField] private AudioClip musicClip;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = musicClip;
        source.Play();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
