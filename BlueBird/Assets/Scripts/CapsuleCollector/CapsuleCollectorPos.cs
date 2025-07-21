using UnityEngine;

public class CapsuleCollectorPos : MonoBehaviour {
    [SerializeField] Transform _capsule;
    private Camera _camera;

    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {
        Vector3 targetPos = _camera.WorldToScreenPoint(_capsule.position);
        transform.position = targetPos;
    }
}
