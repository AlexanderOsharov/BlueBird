using UnityEngine;

public class CapsuleTrigger : MonoBehaviour {
    [SerializeField] private CapsuleCollector _collector;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<BlueBirdMovement>(out var _)) {
            _collector.IsActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.TryGetComponent<BlueBirdMovement>(out var _)) {
            _collector.IsActive = false;
        }
    }
}
