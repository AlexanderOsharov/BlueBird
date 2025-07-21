using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVideoScene : MonoBehaviour {
    private float _passedTime;

    private void Update() {
        if (_passedTime > 9.5f) {
            FindObjectOfType<SceneTransition>().ChangeScene(2);
            _passedTime = -111111111;
        }
        _passedTime += Time.unscaledDeltaTime;
    }
}
