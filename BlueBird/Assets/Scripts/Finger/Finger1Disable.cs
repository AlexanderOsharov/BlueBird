using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger1Disable : MonoBehaviour {
    [SerializeField] private Animator _animator;

    bool _isFirstTouch = true;

    void Update() {
        bool check = Input.touchCount > 0 || Input.GetKey(KeyCode.Space);
        if (Time.timeScale > 0 && !check) {
            _isFirstTouch = false;
            Debug.Log("-----------------");
        }

        if (!_isFirstTouch && Time.timeScale > 0 && check) {
            _animator?.SetTrigger("exit");
        }
    }
}
