using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fragment : MonoBehaviour {
  [SerializeField]
  private Transform inventoryParent;  // �������� ���� ������ � Canvas
  [SerializeField]
  private float moveDuration = 0.5f;

  private Image fragmentIconUI;

  private void OnTriggerStay2D(Collider2D other) {
    if (other.gameObject.TryGetComponent<FragmentHolder>(out var player)) {
      player.CollectFragment();
      CreateAndMoveToInventory();
      Destroy(gameObject);
    }
  }

  private void CreateAndMoveToInventory() {
    // ������ UI-������ ������ Canvas
    GameObject iconGO = new GameObject("FragmentIconUI", typeof(RectTransform),
                                       typeof(CanvasRenderer), typeof(Image));
    iconGO.transform.SetParent(inventoryParent, false);
    iconGO.transform.SetAsLastSibling();  // ����� ���� ������ ������

    fragmentIconUI = iconGO.GetComponent<Image>();

    // �������� ������ � �������
    SpriteRenderer sr = GetComponent<SpriteRenderer>();
    if (sr != null) {
      fragmentIconUI.sprite = sr.sprite;
    } else {
      Debug.LogWarning("No SpriteRenderer found on Fragment!");
    }

    // ������ �� �������� ������� ���������
    RectTransform rt = iconGO.GetComponent<RectTransform>();
    Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
    rt.position = screenPos;
    rt.sizeDelta = new Vector2(64, 64);  // ��� ������ ��� � �����
    rt.localScale = Vector3.one * 1.5f;

    // ���� ������ ��������� ����
    Transform freeSlot = null;
    Image targetIcon = null;

    foreach (Transform slot in inventoryParent) {
      Transform iconChild = slot.Find("IconHolder");
      if (iconChild != null) {
        Image iconImage = iconChild.GetComponent<Image>();
        if (iconImage != null && iconImage.sprite == null) {
          freeSlot = slot;
          targetIcon = iconImage;
          break;
        }
      }
    }

    if (freeSlot == null || targetIcon == null) {
      Debug.LogWarning("��� ��������� ������!");
      Destroy(iconGO);
      return;
    }

    // �������� � ������� �����
    Vector3 targetPos = freeSlot.position;
    Vector3 targetScale = Vector3.one;

    Sequence seq = DOTween.Sequence();
    seq.Append(rt.DOMove(targetPos, moveDuration));
    seq.Join(rt.DOScale(targetScale, moveDuration));
    seq.OnComplete(() => {
      // �������� ������ � ������ ����� (��������� Image)
      targetIcon.sprite = fragmentIconUI.sprite;
      targetIcon.preserveAspect = true;

      Destroy(iconGO);
    });
  }
}
