using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsV2 : MonoBehaviour {
    [SerializeField] private Inentory _inventory;
    [SerializeField] private float _speed;
    [SerializeField] private RectTransform _rectTransform;

    private bool _isOpened = false;

    private float TargetScale => _isOpened ? 1 : 0;

    public void Open() {
        _isOpened = true;
        
    }

    public void Close() {
        _isOpened = false;
    }

    private void Start() {
        Close();
        transform.localScale = Vector3.zero;
        transform.position = new Vector3(
            Screen.width / 2,
            Screen.height / 2, 
            0
        );
    }

    void Update() {
        _rectTransform.localScale = Vector3.Lerp(
            _rectTransform.localScale,
            TargetScale * Vector3.one,
            Time.unscaledDeltaTime * _speed
        );
    }
}
