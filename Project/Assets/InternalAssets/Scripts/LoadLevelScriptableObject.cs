using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LoadLevel")]
public class LoadLevelData : ScriptableObject
{
    public Circle CircleData;
    public Color ColorHitParticleSystem;
    public GameObject LittleKnife;
    public GameObject EnemyKnife;
    public int QuantityLittleBlueKnives;
    public int QuantityEnemyKnives;

    private void OnValidate()
    {
        if(QuantityEnemyKnives < 0 || QuantityEnemyKnives > 3)
        {
            QuantityEnemyKnives = 0;
        }
    }
}
