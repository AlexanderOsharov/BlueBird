using UnityEngine;
using UnityEngine.UI;

public class CapsuleCollector : MonoBehaviour {
    [SerializeField] private Image _loadingImage;
    
    public bool IsActive { get; set; }

    public bool IsDone => _loadingImage.fillAmount >= 1;
}
