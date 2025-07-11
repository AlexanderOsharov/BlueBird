using UnityEngine;

public class Fragment : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var player)) {
            player.CollectFragment();
            Destroy(gameObject);
            Debug.Log("12344");
        }
    }
}
