using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneAlphaAndPos : MonoBehaviour {
    [SerializeField] float _speed;
    [SerializeField] List<Image> _images;
    [SerializeField] List<TMP_Text> _texts;
    [SerializeField] Inentory _inventory;

    private float TargetAlpha => _inventory.Won ? 1 : 0;

    private void UpdateText() { 
        foreach (var text in  _texts) {
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

    void Update() {
        transform.position = new Vector3(
            Screen.width / 2,
            Screen.height / 2,
            0
        );
        UpdateText();
        UpdateIamges();
    }
}
