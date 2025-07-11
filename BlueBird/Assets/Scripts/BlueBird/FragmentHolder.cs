using UnityEngine;

public class FragmentHolder : MonoBehaviour {
    [field: SerializeField] public int CollectedFragments { get; private set; }

    public void CollectFragment() => ++CollectedFragments;
}
