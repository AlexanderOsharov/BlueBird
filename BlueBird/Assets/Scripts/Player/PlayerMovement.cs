using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _speedUinitsPerSecond;
    [SerializeField] private TMP_Text _textMeshPro;

    private Rigidbody2D _rigidbody;

    public bool IsPressed => Input.touchCount > 0;

    public Vector2 Position2D => new Vector2(
        transform.position.x,
        transform.position.y
    );

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    Vector3 GetTouchWorldPosition() {
        Touch touch = Input.GetTouch(0);
        return Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
    }

    Vector3 GetMouseWorldPosition() {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.nearClipPlane + 1;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    Vector2 ConvertToVector2(Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }

    private void Update() {
        if (IsPressed) {
            Vector3 targetPosition = GetTouchWorldPosition();
            Vector3 direction = targetPosition - transform.position;
            _rigidbody.velocity = direction.normalized * _speedUinitsPerSecond;
        }

        else if (Input.GetKey(KeyCode.Space)) {
            Vector3 targetPosition = GetMouseWorldPosition();
            Vector3 direction = targetPosition - transform.position;
            //transform.position += direction.normalized * _speedUinitsPerSecond * Time.unscaledDeltaTime;
            _rigidbody.velocity = direction.normalized * _speedUinitsPerSecond;

            //Debug.Log(direction.normalized.magnitude + "   ---");
        }

        else {
            _rigidbody.velocity = Vector3.zero;
        }

        //_textMeshPro.text = transform.position.ToString();
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            0
        );
    }
}
