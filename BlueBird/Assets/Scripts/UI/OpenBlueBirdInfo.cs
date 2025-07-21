using UnityEngine;

public class OpenBlueBirdInfo : MonoBehaviour
{
    [SerializeField] private GameMessage _gameMessage;
    [SerializeField] private string _info;

    public string Info => _info;

    public void OpenInfo() {
        _gameMessage.Open(_info);
    }
}
