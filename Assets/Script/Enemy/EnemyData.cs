using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public GameObject enemyPrefab;
    public int maxHealth = 100;
    public float speed = 3.0f;
    public float attackPower = 10.0f;
    public float range = 15.0f;
}