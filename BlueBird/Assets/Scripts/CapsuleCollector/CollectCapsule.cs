using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCapsule : MonoBehaviour {
    [SerializeField] private CapsuleCollector _capsuleCollector;
    [SerializeField] private string _info;

    bool _done = false;

    private void Update() {
        if (_capsuleCollector.IsDone && !_done) {
            FindObjectOfType<Inentory>().CollectCapsule(
                GetComponent<SpriteRenderer>(),
                Vector3.one,
                _info
            );
            Debug.Log("dadad");
            gameObject.SetActive(false);
            _done = true;
        }
    }
}
