using UnityEngine;  

public class GameMessageMover : MonoBehaviour {
    [SerializeField] private string _winText;
    [SerializeField] private Inentory _inentory;
    [SerializeField] private GameMessage _message;
    [SerializeField] private Transform _messagePos;

    bool _isFirstFrameWon = true;

    private void Update() {
        if (
            _isFirstFrameWon && 
            _inentory.Won
        ) {
            _message.EnableLastScene(_messagePos.position);
            _message.Open(_winText);
            _isFirstFrameWon = false;
        }
    }
}
