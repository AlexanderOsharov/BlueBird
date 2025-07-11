using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField] private Transform _player;
    [Range(0f, 1f)]
    [SerializeField] private float _speed;

    private void Start() {
        _player = FindObjectOfType<BlueBirdMovement>().transform;
    }

    private void Update() {
        Vector3 targetPosition = _player.position;
        targetPosition.z = -10f;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _speed * Time.deltaTime
        );
    }
}
