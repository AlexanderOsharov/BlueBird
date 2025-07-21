using UnityEngine;

public class Fragment : MonoBehaviour {
    [SerializeField] private GameMessage _gameMessage;
    [SerializeField] private string _text;
    [SerializeField] private AudioSource _audioSource;

    private SpriteRenderer _renderer;

    private void Start() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var player)) {
            player.CollectFragment();
            _audioSource.Play();

            FindObjectOfType<Inentory>().Collect(
                _renderer, 
                new Vector3(_renderer.sprite.rect.width, _renderer.sprite.rect.height, 0), 
                _text
            );

            Destroy(gameObject);
            //_gameMessage.Open(_text);
        }
    }
}
