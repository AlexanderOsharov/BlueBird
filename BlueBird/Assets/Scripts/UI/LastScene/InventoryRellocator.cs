using System.Collections.Generic;
using UnityEngine;

public class InventoryRellocator : MonoBehaviour {
    [SerializeField] float _speed;
    [SerializeField] float _time;

    [SerializeField] List<Transform> _buttons;
    [SerializeField] List<Transform> _targetPositions;
    [SerializeField] List<float> _targetScales;
    [SerializeField] Inentory _inventory;

    float _passedTime;
    List<Transform> _buttonsToReloc = new();

    void CheckList() {
        if (_buttonsToReloc.Count == _buttons.Count) { return; }

        _passedTime += Time.unscaledDeltaTime;
        if (_passedTime > _time) {
            _buttonsToReloc.Add(_buttons[_buttonsToReloc.Count]);
            _passedTime = 0;
        }
    }

    void UpdateList() {
        for (int i = 0; i < _buttonsToReloc.Count; ++i) {
            _buttonsToReloc[i].position = Vector3.Lerp(
                _buttonsToReloc[i].position,
                _targetPositions[i].position,
                _speed * Time.unscaledDeltaTime
            );

            _buttonsToReloc[i].localScale = Vector3.Lerp(
                _buttonsToReloc[i].localScale,
                Vector3.one * _targetScales[i],
                _speed * Time.unscaledDeltaTime
            );
        }
    }

    void Update() {
        if (
            _inventory.Won
        ) {
            CheckList();
            UpdateList();
        }
    }
}
