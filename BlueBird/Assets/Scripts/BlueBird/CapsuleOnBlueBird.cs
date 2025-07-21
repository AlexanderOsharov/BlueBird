using UnityEngine;

public class CapsulePickUp : MonoBehaviour {
    [SerializeField] private float _speed = 10;

    private Inentory _inventory;
    private Vector3 _selfScale;

    private void Start() {
        _selfScale = transform.localScale;
        transform.localScale = Vector3.zero;
        _inventory = FindObjectOfType<Inentory>();
    }

    private void Update() {
        Vector3 targetScale = _inventory.IsCapsuleCollected ? _selfScale : Vector3.zero;
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            _speed * Time.unscaledDeltaTime
        );
    }
}
