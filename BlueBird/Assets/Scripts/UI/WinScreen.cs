using UnityEngine;

public class WinScreen : MonoBehaviour {
    private WinCheck _winCheck;

    private void Start() {
        transform.localScale = Vector3.zero;
        _winCheck = FindObjectOfType<WinCheck>();
    }

    private void Update() {
        if (_winCheck.Won) {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                Vector3.one,
                Time.deltaTime * 10
            );
        }
    }
}
