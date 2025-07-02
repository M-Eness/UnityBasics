using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject[] towerPrefab;
    public TowerPopupController popupController;
    public TowerData[] towerData;
    private int selectedTowerIndex = 0; 

    private Vector3 pendingBuildPosition;
    private bool isPopupActive = false;

     public void SelectTower(int index)
    {
        if (index >= 0 && index < towerPrefab.Length)
        {
            selectedTowerIndex = index;
            Debug.Log("Seçilen kule: " + towerData[selectedTowerIndex].towerType);
        }
    }

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
                pendingBuildPosition.y += towerPrefab[selectedTowerIndex].transform.localScale.y / 2f;
                isPopupActive = true;

                Vector3 mouseScreenPos = Input.mousePosition;
                popupController.ShowPopup(
                    towerData[selectedTowerIndex].towerType.ToString(), 
                    towerData[selectedTowerIndex].cost,
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
        TowerData data = towerData[selectedTowerIndex];
        if (BloodManager.KanSayacı.currentBlood >= data.cost)
        {
            GameObject tower = Instantiate(towerPrefab[selectedTowerIndex], pendingBuildPosition, Quaternion.identity);
            // TowerController'a data'yı ata
            TowerController controller = tower.GetComponent<TowerController>();
            if (controller != null)
                controller.towerData = data;

            BloodManager.KanSayacı.spendBlood(data.cost);
        }
        isPopupActive = false;
    }

    // Vazgeç fonksiyonu
    void OnCancelBuild()
    {
        TowerData data = towerData[selectedTowerIndex];
        if (BloodManager.KanSayacı.currentBlood >= data.cost)
        {
            GameObject tower = Instantiate(towerPrefab[selectedTowerIndex], pendingBuildPosition, Quaternion.identity);
            // TowerController'a data'yı ata
            TowerController controller = tower.GetComponent<TowerController>();
            if (controller != null)
                controller.towerData = data;

            BloodManager.KanSayacı.spendBlood(data.cost);
        }
        isPopupActive = false;
    }
}