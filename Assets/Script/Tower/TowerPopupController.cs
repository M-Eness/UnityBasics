using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TowerPopupController : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text towerNameText;
    public TMP_Text costText;
    public Button archerButton;
    public Button gunnerButton;

    public void ShowPopup(string name, int cost, System.Action onConfirm, System.Action onCancel, Vector3 mousePos)
    {
        towerNameText.text = name;
        costText.text = "Maliyet: " + cost;
        popupPanel.SetActive(true);
        Debug.Log("Panel Açıldı");

        popupPanel.GetComponent<RectTransform>().position = mousePos;

        // Önce eski listener'ları temizle
        archerButton.onClick.RemoveAllListeners();
        gunnerButton.onClick.RemoveAllListeners();
        Debug.Log("Eski listenerlar temizlendi");

        // Yeni listener ekle

        archerButton.onClick.AddListener(() =>
        {
            Debug.Log("Butona Basıldı");
            popupPanel.SetActive(false);
            onConfirm?.Invoke();
        });
        gunnerButton.onClick.AddListener(() =>
        {
            Debug.Log("Diğer Butona Basıldı");
            popupPanel.SetActive(false);
            onCancel?.Invoke();
        });
        Debug.Log("İşlem bitti");
    }

    private void Start()
    {
        popupPanel.SetActive(false);
    }
}