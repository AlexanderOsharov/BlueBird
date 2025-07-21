using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDisable : MonoBehaviour {
    [SerializeField] Inentory _inventory;

    private Animator _image;

    private void Start() {
        _image = GetComponent<Animator>();
    }

    public void Disable() {
        _image.SetTrigger("exit");
    }

    private void Update() {
        if (_inventory.Won) {
            Disable();
        }
    }
}
