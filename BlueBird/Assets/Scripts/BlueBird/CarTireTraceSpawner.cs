using System.Collections.Generic;
using UnityEngine;

public class DynamicTireTrace : MonoBehaviour {
  [Header("Настройки следов")]
  public GameObject car;
  public GameObject traceLeftPrefab;
  public GameObject traceRightPrefab;
  public int maxTraceCount = 20;
  public float traceSpacing = 0.25f;
  public Vector2 traceOffset = new Vector2(0.3f, -0.2f);
  public float minSpeedToLeaveTraces = 0.05f;

  private Vector3 lastTracePosition;

  private Queue<GameObject> leftTraces = new();
  private Queue<GameObject> rightTraces = new();

  void Start() {
    lastTracePosition = car.transform.position;
  }

  void Update() {
    Vector3 carPos = car.transform.position;
    float distanceMoved = Vector3.Distance(carPos, lastTracePosition);
    float speed = distanceMoved / Time.deltaTime;

    if (distanceMoved >= traceSpacing && speed > minSpeedToLeaveTraces) {
      AddTrace();
      lastTracePosition = carPos;
    }

    UpdateTraceTransparency();
  }

  void AddTrace() {
    Vector3 leftPos = car.transform.position - car.transform.right * traceOffset.x +
                      car.transform.up * traceOffset.y;
    Vector3 rightPos = car.transform.position + car.transform.right * traceOffset.x +
                       car.transform.up * traceOffset.y;
    Quaternion rot = car.transform.rotation;

    GameObject left = Instantiate(traceLeftPrefab, leftPos, rot);
    GameObject right = Instantiate(traceRightPrefab, rightPos, rot);

    leftTraces.Enqueue(left);
    rightTraces.Enqueue(right);

    if (leftTraces.Count > maxTraceCount) {
      Destroy(leftTraces.Dequeue());
      Destroy(rightTraces.Dequeue());
    }
  }

  void UpdateTraceTransparency() {
    int count = leftTraces.Count;
    int i = 0;

    foreach (var trace in leftTraces) {
      float alpha = (float)i / Mathf.Max(1, count - 1);
      SetAlpha(trace, alpha);
      i++;
    }

    i = 0;
    foreach (var trace in rightTraces) {
      float alpha = (float)i / Mathf.Max(1, count - 1);
      SetAlpha(trace, alpha);
      i++;
    }
  }

  void SetAlpha(GameObject go, float alpha) {
    if (go.TryGetComponent<SpriteRenderer>(out var sr)) {
      Color c = sr.color;
      sr.color = new Color(c.r, c.g, c.b, alpha);
    }
  }
}
