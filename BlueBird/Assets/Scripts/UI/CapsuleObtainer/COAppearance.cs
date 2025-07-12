using UnityEngine;

public class COAppearance : MonoBehaviour {
    [SerializeField] private float _appearanceSpeed;
    [SerializeField] private RectTransform _obtainer;
    [SerializeField] private Transform _closedPosition;
    [SerializeField] private Transform _openedPosition;

    private bool _shouldAppear = false;

    public bool Collected {  get; set; } = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var _)) {
            _shouldAppear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<FragmentHolder>(out var _)) {
            _shouldAppear = false;
        }
    }

    private void Start() {
        _obtainer.transform.position = _closedPosition.position;
    }

    private void Update() {
        Vector3 target = _shouldAppear &&!Collected ? _openedPosition.position : _closedPosition.position;
        _obtainer.anchoredPosition = Vector3.Lerp(
            _obtainer.anchoredPosition,
            target,
            _appearanceSpeed * Time.deltaTime
        );
    }
}
