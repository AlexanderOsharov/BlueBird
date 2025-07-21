using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CreditsMenu : MonoBehaviour {
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private GraphicRaycaster _raycaster;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _speed;

    private bool _isOpened = false;

    private float TargetAlpha => _isOpened ? 1f : 0f;


    public void Open() {
        _canvas.enabled = true;
        _raycaster.enabled = true;
        _isOpened = true; 
    }

    public void Close() { 
        _isOpened = false;
        StartCoroutine(DisableCanvas());
    }

    private void Start() {
        Close();    
    }

    private void Update() {
        //_group.alpha = Mathf.Lerp(_group.alpha, TargetAlpha, _speed * Time.unscaledDeltaTime);

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            Vector3.one * TargetAlpha,
            _speed * Time.unscaledDeltaTime
        );
    }

    private IEnumerator DisableCanvas() {
        yield return new WaitForSeconds(1);
        _canvas.enabled = false;
        _raycaster.enabled = false;
    }
}
