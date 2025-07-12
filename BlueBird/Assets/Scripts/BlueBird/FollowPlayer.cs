using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _topRightCorner;
    [SerializeField] private Transform _bottomLeftCorner;

    private Camera _camera;

    private float CameraHalfHeight => _camera.orthographicSize;

    private float CameraHalfWidth => CameraHalfHeight * _camera.aspect;

    private void Start() {
        _player = FindObjectOfType<BlueBirdMovement>().transform;
        _camera = Camera.main;
    }

    private void Update() {
        Vector3 targetPosition = _player.position;
        targetPosition.z = -10f;

        targetPosition.x = Mathf.Clamp(
            targetPosition.x,
            _bottomLeftCorner.position.x + CameraHalfWidth,
            _topRightCorner.position.x - CameraHalfWidth
        );

        Debug.Log(CameraHalfWidth);

        targetPosition.y = Mathf.Clamp(
            targetPosition.y,
            _bottomLeftCorner.position.y + CameraHalfHeight,
            _topRightCorner.position.y - CameraHalfHeight
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _speed * Time.unscaledDeltaTime
        );
    }
}
