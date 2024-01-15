using UnityEngine;

public enum EnemyState
{
    PATROL,
    CHASING,
    ATTACKING,
    DEAD,
    DEFAULT
}
/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "New Enemy Base", menuName = "AI/Enemy/Base")]
public class EnemyBase : ScriptableObject
{

    #region Fields
    public string enemyName;
    public Sprite enemyPrefab;
    public int enemyHealth;
    public int enemyDamage;
    public EnemyState enemyState;
    #endregion


    #region Public API
    #endregion

}
