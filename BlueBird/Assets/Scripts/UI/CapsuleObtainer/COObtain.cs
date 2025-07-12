using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class COObtain : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private float _timeToFill = 4;
    [SerializeField] private Slider _slider;
    [SerializeField] private COAppearance _COAppearance;

    private bool _isHeld = false;

    public void OnPointerUp(PointerEventData eventData) {
        _isHeld = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        _isHeld = true;
    }

    private void Update() {
        if (_isHeld) {
            _slider.value += (_slider.maxValue - _slider.minValue) * Time.deltaTime / _timeToFill;
        }
        if (_slider.value >= _slider.maxValue) {
            _COAppearance.Collected = true;
        }
    }
}
