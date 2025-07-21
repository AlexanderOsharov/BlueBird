using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkyAnimV2 : MonoBehaviour {
    [SerializeField] private GameObject _skyPrefab;
    [SerializeField] private float _speed = 1;
    [SerializeField] private int _count = 3;

    List<RectTransform> _sky = new();

    void Start() {
        GameObject sky1 = Instantiate(_skyPrefab, transform);
        sky1.transform.position = new Vector3(
            Screen.width / 2,
            Screen.height / 2,
            0  
        );
        _sky.Add(sky1.GetComponent<RectTransform>());
        for (int i = 0; i < _count; ++i) {
            GameObject nextSky = Instantiate(_skyPrefab, transform);
            nextSky.transform.position = new Vector3(
                Screen.width / 2,
                Screen.height / 2 + Screen.height * i,
                0
            );
            _sky.Add(nextSky.GetComponent<RectTransform>());
        }
    }

    private void MoveDown() {
        foreach (RectTransform sky in _sky) {
            sky.position += Vector3.down * _speed;
        }
    }

    private void CheckRelloc() {
        while (_sky[0].position.y <= _sky[0].sizeDelta.y / 2) {
            _sky.Add(_sky[0]);
            _sky.RemoveAt(0);
        }
    }
    
    private void Update() {
        MoveDown();
    }
}
