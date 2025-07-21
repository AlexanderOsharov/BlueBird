using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressedScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private float _alpha;
    [SerializeField] private float _speed;
    
    private RectTransform _rTransform;
    private Vector3 _targetScale;

    private void Start() {
        _rTransform = GetComponent<RectTransform>();
        _targetScale = _rTransform.sizeDelta; 
    }

    void Update() {
        _rTransform.sizeDelta = Vector3.Lerp(
            _rTransform.sizeDelta,
            _targetScale,
            _speed * Time.unscaledDeltaTime
        );
    }

    public void OnPointerDown(PointerEventData eventData) {
        _targetScale *= _alpha;
    }

    public void OnPointerUp(PointerEventData eventData) {
        _targetScale /= _alpha;
    }
}
