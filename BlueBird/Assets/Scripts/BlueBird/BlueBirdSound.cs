using UnityEngine;

public class MusicController : MonoBehaviour {
    [SerializeField] private BlueBirdInput blueBirdInput;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float speed;
    [SerializeField] private float maxVolume;

    private AudioSource audioSource;
    private float TargetVolume => blueBirdInput.IsActive ? maxVolume : 0.0f;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    private void Update() {
        audioSource.volume = Mathf.Lerp(audioSource.volume, TargetVolume, Time.deltaTime * speed);
    }
}