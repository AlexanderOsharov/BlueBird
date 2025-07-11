using UnityEngine;

public class BackgroundRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 30f;

    void Update() {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
