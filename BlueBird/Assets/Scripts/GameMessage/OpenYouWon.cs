using UnityEngine;

public class OpenYouWon : MonoBehaviour {
    [SerializeField] private WinCheck _winCheck;
    [SerializeField] private string _winText;
    [SerializeField] private GameMessage _gameMessage;

    private void OpenWinWindow() => _gameMessage.Open(_winText);

    private void OnEnable() {
        _winCheck.OnWin += OpenWinWindow;
    }

    private void OnDisable() {
        _winCheck.OnWin -= OpenWinWindow;
    }
}
