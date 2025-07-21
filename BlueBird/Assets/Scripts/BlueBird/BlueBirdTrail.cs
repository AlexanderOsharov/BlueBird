using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlueBirdTrail : MonoBehaviour {
    [SerializeField] private GameObject _tier;
    [SerializeField] private int _tierCount;
    [SerializeField] private float _distToRespawn;

    private List<GameObject> _spawnList = new List<GameObject>();

    private void Start() {
        for (int i = 0; i < _tierCount; ++i) {
            GameObject obj = Instantiate(_tier);
            obj.transform.position = Vector3.zero;
            _spawnList.Add(obj);
        }
    }

    private float GetDistFromFirstTier => Vector3.Distance(
        transform.position,
        _spawnList[0].transform.position
    );

    private bool ShouldRespawn => GetDistFromFirstTier > _distToRespawn;

    private void UpdateColor() {
        for (int i = 0; i < _tierCount; ++i) {
            float targetAlpha = (1 - (float)i / _tierCount);

            SpriteRenderer sp = _spawnList[i].GetComponentInChildren<SpriteRenderer>();
            sp.color = new Color(
                sp.color.r,
                sp.color.g,
                sp.color.b,
                targetAlpha
            );
        }
    }

    private void Respawn() {
        GameObject tier = _spawnList.Last();
        _spawnList.RemoveAt(_spawnList.Count - 1);
        tier.transform.position = transform.position;
        tier.transform.rotation = transform.rotation;
        _spawnList.Insert(0, tier);
    }

    private void Update() {
        if (ShouldRespawn) {
            Respawn();
        }
        UpdateColor();
    }
}
