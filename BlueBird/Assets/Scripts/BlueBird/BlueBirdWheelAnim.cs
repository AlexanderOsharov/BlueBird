using UnityEngine;

public class BlueBirdWheelAnim : MonoBehaviour {
    [SerializeField] private float _timeToFlip;
    [SerializeField] private BlueBirdInput _input;

    private float _passedTime = 0;

    private void Update() {
        if (_input.IsActive) {
            _passedTime += Time.deltaTime;
        }

        if (_passedTime > _timeToFlip) {
            transform.localScale = new Vector3(
                -transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z
            );
            _passedTime = 0;
        }
    }
}
