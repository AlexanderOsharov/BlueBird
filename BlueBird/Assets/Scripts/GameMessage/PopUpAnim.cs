using UnityEngine;

public class PopUpAnim : MonoBehaviour {
    [SerializeField] float _time;
    [SerializeField] Vector3 _maxScale;
    [SerializeField] Vector3 _minScale;

    bool _enabled = false;
    float _passedTime = 0;

    public void StartAnim() {
        _enabled = true;
        _passedTime = 0;
    }

    void Update() {
        Vector3 delta = _minScale - _maxScale;

        if (_enabled && _passedTime < _time) {
            transform.localScale = _maxScale + delta * Mathf.Sin(_passedTime * Mathf.PI / _time);
            _passedTime += Time.unscaledDeltaTime;
        } else {
            _enabled = false;
            _passedTime = 0;
        }
    }
}
