using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TowerPopupController : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text towerNameText;
    public TMP_Text costText;
    public Button confirmButton;
    public Button cancelButton;

    public void ShowPopup(string name, int cost, System.Action onConfirm, System.Action onCancel, Vector3 mousePos)
    {
        towerNameText.text = name;
        costText.text = "Maliyet: " + cost;
        popupPanel.SetActive(true);

        popupPanel.GetComponent<RectTransform>().position = mousePos;

        // Önce eski listener'ları temizle
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        // Yeni listener ekle
        confirmButton.onClick.AddListener(() => {
            popupPanel.SetActive(false);
            onConfirm?.Invoke();
        });
        cancelButton.onClick.AddListener(() => {
            popupPanel.SetActive(false);
            onCancel?.Invoke();
        });
    }

    private void Start()
    {
        popupPanel.SetActive(false);
    }
}