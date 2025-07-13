using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
  public static InventoryManager Instance { get; private set; }

  [SerializeField]
  private List<RectTransform> inventorySlots;

  private void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
  }

  public RectTransform GetFreeSlot() {
    foreach (var slot in inventorySlots) {
      if (slot.childCount == 0)
        return slot;
    }
    return null;  // нет свободных слотов
  }
}
