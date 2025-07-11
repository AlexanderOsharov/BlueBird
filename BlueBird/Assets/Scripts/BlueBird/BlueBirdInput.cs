using UnityEngine;

public class BlueBirdInput : MonoBehaviour {
    [SerializeField] private KeyCode _key = KeyCode.Space;
    [SerializeField] private float _minValidDirectionLength;

    public bool Enabled { get; set; } = true;
    private Camera _camera;

    private void Start() {
        _camera = FindObjectOfType<Camera>();
    }

    public bool IsTouched => Input.touchCount > 0 || Input.GetKey(_key);

    public bool IsActive => IsTouched &&
                            Enabled &&
                            (TouchPosInGame - transform.position).magnitude >= _minValidDirectionLength ;

    public Vector3 TouchPosInGame {
        get {
            if (!IsTouched) { return Vector3.zero; }

            Vector3 posOnScreen = (Input.touchCount > 0) ? 
                                      Input.GetTouch(0).position : 
                                      Input.mousePosition;

            Vector2 res = _camera.ScreenToWorldPoint(posOnScreen);
            return new Vector3(res.x, res.y, 0);
        }
    }

    public Vector3 Direction => (TouchPosInGame - transform.position).normalized;
}
