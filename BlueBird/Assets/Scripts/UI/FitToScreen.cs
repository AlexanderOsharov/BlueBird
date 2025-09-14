using UnityEngine;

public class FitToScreen : MonoBehaviour {
    [SerializeField] private Transform _canvas;

    private void Awake() {
        //RectTransform rect = GetComponent<RectTransform>();
        //rect.sizeDelta = new Vector2(
        //    Screen.width / _canvas.localScale.x,
        //    Screen.height / _canvas.localScale.y
        //) * 2;
    }
}