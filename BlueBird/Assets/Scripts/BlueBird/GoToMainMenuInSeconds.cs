using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenuInSeconds : MonoBehaviour
{
    [SerializeField] private float _time = 90;

    private float _passedTime = 0;

    void Update()
    {
        _passedTime += Time.unscaledDeltaTime;
        if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space)) {
            _passedTime = 0;
        }

        if (_passedTime > _time) {
            FindObjectOfType<SceneTransition>().ChangeScene(0);
        }
    }
}
