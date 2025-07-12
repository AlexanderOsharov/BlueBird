using UnityEngine;

public class TreeMotion : MonoBehaviour {
    [SerializeField] private Vector3 _maxOffset;
    [SerializeField] private float _dist;
    [SerializeField] private float _speed;

    private Vector3 _position;

    private void Start() {
        _position = transform.position;
    }

    private void Update() {
        Vector3 delta = _maxOffset.normalized * _dist * Mathf.Sin(Time.time * _speed);
        transform.position = _position + delta;
    }
}
