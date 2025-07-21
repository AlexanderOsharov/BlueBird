using UnityEngine;

public class CameraShake : MonoBehaviour {
    [SerializeField] Animator _animator;

    void Start() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        _animator.SetTrigger("shake");
        Debug.Log(transform.position);
    }
}
