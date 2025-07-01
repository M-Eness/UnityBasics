using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

         
            if (Physics.Raycast(ray, out hit))
            {
                // İstenilen pozisyona kule instantiate et
                Vector3 placePosition = hit.point;
                placePosition.y += towerPrefab.transform.localScale.y / 2f;

                Instantiate(towerPrefab, placePosition, Quaternion.identity);
            }
        }
    }
}
