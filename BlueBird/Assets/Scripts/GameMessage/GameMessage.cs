using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMessage : MonoBehaviour {
    [SerializeField] private float _speed;
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Button _button;
    //[SerializeField] private AudioSource _audioSource;

    public event Action OnClose;

    public bool IsOpened { get; private set; } = false;

    private float TargetScale => IsOpened ? 1 : 0;

    public void Open() {
        if (IsOpened) { GetComponent<PopUpAnim>().StartAnim(); }
        //_audioSource.Play()
        Time.timeScale = 0;
        IsOpened = true;
    }

    public void Open(string text) {
        _tmpText.text = text.Replace("\\n", Environment.NewLine);
        Open();
    }

    public void Open(string text, Action act) {
        OnClose += act;
        Open(text);
    }

    public void Close() {
        OnClose?.Invoke();
        OnClose = null;
        Time.timeScale = 1;
        IsOpened = false;
    }

    public void EnableLastScene(Vector3 pos) {
        transform.position = pos;
        _button.gameObject.SetActive(false);
        _tmpText.transform.localPosition = Vector3.zero;
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
