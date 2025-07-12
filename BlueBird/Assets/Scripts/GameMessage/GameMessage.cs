using TMPro;
using UnityEngine;

public class GameMessage : MonoBehaviour {
    [SerializeField] private float _speed;
    [SerializeField] private TMP_Text _tmpText;

    public bool IsOpened { get; private set; }

    private float TargetScale => IsOpened ? 1 : 0;

    public void Open() {
        Time.timeScale = 0;
        IsOpened = true; 
    }

    public void Open(string text) {
        _tmpText.text = text;
        Open();
    }

    public void Close() {
        Time.timeScale = 1;
        IsOpened = false;
    }

    private void Start() {
        transform.localScale = Vector3.zero;
    }

    private void Update() {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            Vector3.one * TargetScale,
            _speed * Time.unscaledDeltaTime
        );
    }
}
