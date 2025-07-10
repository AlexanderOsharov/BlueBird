using UnityEngine;

public class TestRotation : MonoBehaviour {
    private Rigidbody2D _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, 90 * Time.deltaTime);

    }
}
