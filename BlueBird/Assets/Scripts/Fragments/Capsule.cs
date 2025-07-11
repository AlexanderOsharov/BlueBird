using UnityEngine;

public class Capsule : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var player)) {
            player.CollectCapsule();
            Destroy(gameObject);
        }
    }
}
