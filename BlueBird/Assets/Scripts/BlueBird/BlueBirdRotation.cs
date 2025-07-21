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

    private void Update() {
        if (_blueBirdInput.IsActive) {
            Vector2 targetDir = _blueBirdInput.TouchPosInGame - transform.position;

            float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            float currentAngle = transform.eulerAngles.z;

            // Плавный поворот к целевому углу
            float newAngle =
                Mathf.MoveTowardsAngle(currentAngle, targetAngle, _angleSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
