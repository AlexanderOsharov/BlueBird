using UnityEngine;

public class Fragment : MonoBehaviour {
    [SerializeField] private GameMessage _gameMessage;
    [SerializeField] private string _text;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var player)) {
            player.CollectFragment();
            Destroy(gameObject);
            _gameMessage.Open(_text);
        }
    }
}
