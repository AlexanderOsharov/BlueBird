using UnityEngine;

public class BlueBirdMovement : MonoBehaviour {
    [SerializeField] private float _maxVelocity;

    private Rigidbody2D _rigidbody;
    private BlueBirdInput _blueBirdInput;
    private BlueBirdRotation _blueBirdRotation;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _blueBirdInput = GetComponent<BlueBirdInput>();
        _blueBirdRotation = GetComponent<BlueBirdRotation>();
    }

    private void Update() {
        if (_blueBirdInput.IsActive) {
            _rigidbody.velocity = _blueBirdRotation.RotationAsVector * _maxVelocity;
        }
        else {
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, Vector3.zero, 0.03f);
        }
    }
}
