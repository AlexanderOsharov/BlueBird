using System;
using UnityEngine;

public class WinCheck : MonoBehaviour {
    public bool Won => _fragmentHolder.CollectedFragments == _fragmentsCount && _fragmentHolder.IsCapsuleCollected;

    public event Action OnWin;

    private int _fragmentsCount;
    private FragmentHolder _fragmentHolder;
    private bool _prevFrameWon = false;

    private void Start() {
        _fragmentsCount = FindObjectsOfType<Fragment>().Length;
        _fragmentHolder = GetComponent<FragmentHolder>();
    }

    private void Update() {
        if (Won && !_prevFrameWon) {
            OnWin?.Invoke();
            FindObjectOfType<BlueBirdInput>().Enabled = false;
        }
        _prevFrameWon = Won;
    }
}
