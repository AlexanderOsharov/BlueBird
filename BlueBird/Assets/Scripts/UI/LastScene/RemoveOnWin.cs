using UnityEngine;

public class RemoveOnWin : MonoBehaviour {
    [SerializeField] private Inentory _inventory;
    [SerializeField] private float _speed;

    private Vector3 _selfScale;

    private Vector3 TargetScale => _inventory.Won ? Vector3.zero : _selfScale;

    void Start() {
        _selfScale = transform.localScale;
    }

    void Update() {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            TargetScale,
            _speed * Time.unscaledDeltaTime
        );
    }
}
