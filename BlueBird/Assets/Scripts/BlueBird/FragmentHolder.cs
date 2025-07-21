using UnityEngine;

public class FragmentHolder : MonoBehaviour {
    [field: SerializeField] public int CollectedFragments { get; private set; } = 0;
    [field: SerializeField] public bool IsCapsuleCollected { get; private set; }

    public void CollectFragment() {
        ++CollectedFragments;
    }
    public void CollectCapsule() => IsCapsuleCollected = true;
}
