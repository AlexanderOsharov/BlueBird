using UnityEngine;

public class ButtonAnimation : MonoBehaviour {
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private float _deltaRotation;

    private Quaternion _rotation;
    private float _passedTime;
    private float _timeToRotate;

    private void ResetTimeToRotate() {
        _timeToRotate = Random.Range(_minTime, _maxTime);
    }

    private void RandomRotate() {
        float deltaAngle = Random.Range(-_deltaRotation, _deltaRotation);
        Quaternion rotation = Quaternion.Euler(deltaAngle, 0, deltaAngle);
        transform.rotation = rotation;
    }

    private void Start() {
        _rotation = transform.rotation;
        ResetTimeToRotate();
    }

    private void Update() {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _timeToRotate) {
            RandomRotate();
            _passedTime = 0;
            ResetTimeToRotate();
        }
    }
}
