using UnityEngine;

public class OpenGameInfo : MonoBehaviour {
    [SerializeField] private string _gameInfo;
    [SerializeField] private GameMessage _message;

    private void Start() {
        _message.Open(_gameInfo);
    }
}
