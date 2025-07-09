using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private TMP_Text _textMeshPro;

    private void Start() {
        Debug.Log("adad");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("adadadad");
        if (other.gameObject.TryGetComponent<Cosmonaut>(out var _)) {
            _textMeshPro.text = "YOU WON!";
        }
    }
}