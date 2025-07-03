using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Towers/TowerData", order = 1)]
public class TowerData : ScriptableObject
{
    public TowerType towerType;
    public int cost;
    public float damage;
    // Diğer özellikler eklenebilir
}