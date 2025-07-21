using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour {
    [SerializeField] float _speed;
    [SerializeField] CapsuleCollector _capsuleCollector;
    [SerializeField] private List<Image> _images;
    [SerializeField] private List<TMP_Text> _texts;
    [SerializeField] private Inentory _inventory;

    bool _disabled = false;

    private IEnumerator DisableCO() {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }

    public float TargetAlpha => _capsuleCollector.IsActive && !_capsuleCollector.IsDone ? 1 : 0;

    private void Start() {
        foreach (var image in _images) {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                0
            );
        }

        foreach (var text in _texts) {
            text.color = new Color(
                text.color.r,
                text.color.g,
                text.color.b,
                0
            );
        }
    }

    public void Update() {
        foreach (var image in _images) {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                Mathf.Lerp(image.color.a, TargetAlpha, _speed * Time.unscaledDeltaTime)
            );
        }

        foreach (var text in _texts) {
            text.color = new Color(
                text.color.r,
                text.color.g,
                text.color.b,
                Mathf.Lerp(text.color.a, TargetAlpha, _speed * Time.unscaledDeltaTime)
            );
        }

        if (_inventory.Won && !_disabled) {
            StartCoroutine(DisableCO());
            _disabled = true;
        }
    }
}
