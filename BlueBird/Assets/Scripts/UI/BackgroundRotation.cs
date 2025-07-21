using UnityEngine;

public class BackgroundRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 30f;

    private void Start () {
        Time.timeScale = 1;
    }

    void Update() {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
