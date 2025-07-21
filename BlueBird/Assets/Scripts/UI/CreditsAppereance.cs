using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsAppereance : MonoBehaviour {
    [SerializeField] float _speed;
    [SerializeField] List<Image> _images;
    [SerializeField] List<TMP_Text> _texts;
    [SerializeField] Inentory _inventory;

    private bool _isOpened = false;

    private float TargetAlpha => _isOpened ? 1f : 0f;

    public void Open() {
        _isOpened = true;
    }

    public void Close() {
        _isOpened = false;
    }

    private void UpdateText() {
        foreach (var text in _texts) {
            text.color = new Color(
                text.color.r,
                text.color.g,
                text.color.b,
                Mathf.Lerp(text.color.a, TargetAlpha, _speed * Time.unscaledDeltaTime)
            );
        }
    }

    private void UpdateIamges() {
        foreach (var image in _images) {

            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                Mathf.Lerp(image.color.a, TargetAlpha, _speed * Time.unscaledDeltaTime)
            );
        }
    }

    private void Start() {
        GetComponent<RectTransform>().localScale = Vector3.zero;
        Close();
        transform.position = new Vector3(
            Screen.width / 2,
            Screen.height / 2,
            0
        );
        foreach (var text in _texts) {
            text.color = new Color(
                text.color.r,
                text.color.g,
                text.color.b,
                0
            );
        }
        foreach (var image in _images) {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                0
            );
        }
    }

    void UpdateScale() {
        if (_isOpened) {
            transform.localScale = Vector3.one;
        }
        else if (_texts[0].color.a < 0.01) {
            transform.localScale = Vector3.zero;
        }
    }

    void Update() {
        transform.position = new Vector3(
            Screen.width / 2,
            Screen.height / 2,
            0
        );
        UpdateText();
        UpdateIamges();
        UpdateScale();
    }
}
