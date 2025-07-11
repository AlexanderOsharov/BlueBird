using UnityEngine;

[RequireComponent(typeof(BlueBirdInput))]
public class BlueBirdRotation : MonoBehaviour {
    [SerializeField] private float _angleSpeed;

    private BlueBirdInput _blueBirdInput;

    public float RotationAngleRad => transform.eulerAngles.z * Mathf.Deg2Rad;

    public Vector2 RotationAsVector => new Vector2(
        Mathf.Cos(RotationAngleRad),
        Mathf.Sin(RotationAngleRad)
    );

    private void Start() {
        _blueBirdInput = GetComponent<BlueBirdInput>();
    }

    private void FixedUpdate() {
        if (_blueBirdInput.IsActive) {
            Vector2 targetDir = _blueBirdInput.TouchPosInGame - transform.position;

            float angle = Vector2.SignedAngle(RotationAsVector, targetDir);
            float speed = Mathf.Sign(angle) * _angleSpeed * Time.deltaTime;

            if (Mathf.Abs(angle) > speed) {
                transform.Rotate(0, 0, speed);
            }
            // Debug.Log("Start");
        }
        // Debug.Log("End");
    }
}
