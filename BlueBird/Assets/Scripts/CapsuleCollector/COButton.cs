using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class COButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private float _timeToFill = 4;
    [SerializeField] private Image _loader;
    [SerializeField] private CapsuleCollector _capsuleCollector;
    [SerializeField] private AudioSource _audioSource;

    private bool _isHeld = false;
    private BlueBirdInput _birdInput;

    private void Start() {
        _birdInput = FindObjectOfType<BlueBirdInput>();
    }

    public void OnPointerUp(PointerEventData eventData) {
        _isHeld = false;
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        _isHeld = true;
        _audioSource.Play();
    }

    private void Update() {
        if (_isHeld && _capsuleCollector.IsActive) {
            _loader.fillAmount += Time.unscaledDeltaTime / _timeToFill;
            _birdInput.Enabled = false;
        } else {
            _audioSource.Pause();
            _birdInput.Enabled = true;
        }
    }
}
