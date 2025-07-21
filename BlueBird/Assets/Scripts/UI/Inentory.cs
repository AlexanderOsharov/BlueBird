using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inentory : MonoBehaviour {
    [SerializeField] private Color _chosenColor;
    [SerializeField] private GameMessage _message;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<Image> _icons;

    [SerializeField] private Button _blueBirdButton;
    [SerializeField] private Button _capsuleButton;
    [SerializeField] private Image _capsuleImage;
    [SerializeField] private bool _godMode = true;

    private Color _defaultButtonColor;

    public bool Won => (_collectedCount >= _buttons.Count && IsCapsuleCollected) || _godMode;

    public bool IsCapsuleCollected { get; private set; } = false;
    private int _collectedCount = 0;

    private void Start() {
        _defaultButtonColor = _buttons[0].colors.normalColor;

        _blueBirdButton.onClick.AddListener(() => _message.Open(
            _blueBirdButton.GetComponent<OpenBlueBirdInfo>().Info, 
            ResetColor
        ));
        _blueBirdButton.onClick.AddListener(() => ChangeBlueBirdColor());
    }

    public void Collect(SpriteRenderer icon, Vector3 scale, string info) {
        _icons[_collectedCount].sprite = icon.sprite;
        _icons[_collectedCount].color = Color.white;
        if (scale.x > scale.y) {
            scale /= scale.x;
        }
        else {
            scale /= scale.y;
        }
        RectTransform rt = _icons[_collectedCount].GetComponent<RectTransform>();
        rt.sizeDelta = scale * rt.sizeDelta;

        int count = _collectedCount;
        _buttons[_collectedCount].onClick.AddListener(() => _message.Open(info, ResetColor));
        _buttons[_collectedCount].onClick.AddListener(() => ChangeColor(count));

        _collectedCount++;

        //if (Won) {
        //    _message.Open(
        //        "Ты отлично справился! Теперь операция по спасению космонавтов завершена!",
        //        () => SceneManager.LoadScene(0)
        //    );
        //}
    }

    public void ResetColor() {
        ColorBlock colors;
        var newList = _buttons.ToList();
        newList.Add(_blueBirdButton);
        newList.Add(_capsuleButton);
        foreach (Button btn in newList) {
            colors = btn.colors;
            colors.normalColor = _defaultButtonColor;
            colors.selectedColor = _defaultButtonColor;
            btn.colors = colors;
        }
    }

    public void ChangeColor(int ind) {
        ResetColor();
        ColorBlock colors = _buttons[ind].colors;
        colors.normalColor = _chosenColor;
        colors.selectedColor = _chosenColor;
        _buttons[ind].colors = colors;
    }

    public void ChangeCapsuleColor() {
        ResetColor();
        ColorBlock colors = _capsuleButton.colors;
        colors.normalColor = _chosenColor;
        colors.selectedColor = _chosenColor;
        _capsuleButton.colors = colors;
    }

    public void ChangeBlueBirdColor() {
        ResetColor();
        ColorBlock colors = _blueBirdButton.colors;
        colors.normalColor = _chosenColor;
        colors.selectedColor = _chosenColor;
        _blueBirdButton.colors = colors;
    }

    public void CollectCapsule(SpriteRenderer icon, Vector3 scale, string info) {
        _capsuleImage.sprite = icon.sprite;
        //_capsuleButton.onClick.AddListener(() => _message.Open(info));

        scale.z = 0;
        scale.Normalize();
        _capsuleImage.gameObject.GetComponent<RectTransform>().sizeDelta =
            scale *
            _capsuleImage.gameObject.GetComponent<RectTransform>().sizeDelta.magnitude;

        IsCapsuleCollected = true;

        _capsuleButton.onClick.AddListener(() => _message.Open(info, ResetColor));
        _capsuleButton.onClick.AddListener(() => ChangeCapsuleColor());
        //if (Won) {
        //    _message.Open(
        //        "Ты отлично справился! Теперь операция по спасению космонавтов завершена!",
        //        () => SceneManager.LoadScene(0)
        //    );
        //}
    }
}
