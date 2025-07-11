using TMPro;
using UnityEngine;

public class CollectedFragmentsCount : MonoBehaviour {
    private TMP_Text _text;
    private FragmentHolder _holder;
    private int _totalFragmentsCount;

    private void Start() {
        _text = GetComponent<TMP_Text>();
        _holder = FindObjectOfType<FragmentHolder>();

        _totalFragmentsCount = FindObjectsOfType<Fragment>().Length;
    }

    private void Update() {
        _text.text = _holder.CollectedFragments + "/" + _totalFragmentsCount;
    }
}
