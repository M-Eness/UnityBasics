using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public TowerPopupController popupController;
    public TowerData towerData;
    public int GetCost() => towerData.cost;
    public float GetDamage() => towerData.damage;
    public TowerType GetTowerType() => towerData.towerType;

    private Vector3 pendingBuildPosition;
    private bool isPopupActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isPopupActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Kuleyi doğrudan yerleştirmek yerine pozisyonu kaydet ve popup aç
                pendingBuildPosition = hit.point;
                pendingBuildPosition.y += towerPrefab.transform.localScale.y / 2f;
                isPopupActive = true;

                Vector3 mouseScreenPos = Input.mousePosition;
                popupController.ShowPopup(
                    towerData.towerType.ToString(), 
                    towerData.cost,
                    OnConfirmBuild,
                    OnCancelBuild,
                    mouseScreenPos
                );
            }
        }
    }

    // Onay fonksiyonu
    void OnConfirmBuild()
    {
        if (BloodManager.KanSayacı.currentBlood >= towerData.cost)
        {
            Instantiate(towerPrefab, pendingBuildPosition, Quaternion.identity);
            BloodManager.KanSayacı.spendBlood(towerData.cost);
        }
        isPopupActive = false;
    }

    // Vazgeç fonksiyonu
    void OnCancelBuild()
    {
        isPopupActive = false;
    }
}