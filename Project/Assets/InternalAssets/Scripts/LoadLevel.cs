using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private LoadLevelData _loadLevelData;
    [SerializeField] private GameObject _playerKnivesPrefab;
    [SerializeField] private GameObject _spawnPointPrefab;
    [SerializeField] private Transform _spawnLittleKnives;
    [SerializeField] private Transform _spawnPlayerKnives;
    [SerializeField] private Transform _circle;
    [SerializeField] private Transform _middleCircle;
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private UnityEvent _canHitAndStartRotation;


    private Transform[] _knives = new Transform[3];
    private Transform[] _spawnPointsKnives = new Transform[3];

    public LoadLevelData LoadLevelData { 
        get
        {
            return _loadLevelData;
        }
        private set {
            _loadLevelData = value;
        }
    }
    private void Awake()
    {
        SpawnLittleKnives();
        SpawnEnemyKnives();
        SpawnPlayerKnives();
    }

    #region [Spawn Some Objects]
    private void SpawnLittleKnives()
    {
        for(int i = 0; i < _loadLevelData.QuantityLittleBlueKnives; i++)
        {
            Instantiate(_loadLevelData.LittleKnife, Vector3.zero, Quaternion.identity, _spawnLittleKnives);
        }
    }

    private void SpawnEnemyKnives()
    {
        Vector3 spawnKnifePosition = Vector3.zero;
        spawnKnifePosition.y = _circle.position.y - _circle.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        _hitParticle.gameObject.transform.position = spawnKnifePosition;
        _hitParticle.startColor = _loadLevelData.ColorHitParticleSystem;

        float rightRange = 360f / _loadLevelData.QuantityEnemyKnives;

        for (int i = 0; i < _loadLevelData.QuantityEnemyKnives; i++)
        {
            _knives[i] = Instantiate(_loadLevelData.EnemyKnife, spawnKnifePosition, Quaternion.identity, _middleCircle).transform;
            _spawnPointsKnives[i] = Instantiate(_spawnPointPrefab, spawnKnifePosition, Quaternion.identity, _middleCircle).transform;

            _knives[i].position = new Vector3(0, -20f, 0);

            _middleCircle.rotation = Quaternion.Euler(0f, 0f, _middleCircle.rotation.eulerAngles.z + Random.Range(20f, rightRange));
        }

        Instantiate(_spawnPointPrefab, spawnKnifePosition, Quaternion.identity, _middleCircle);
    }

    private void SpawnPlayerKnives()
    {
        Instantiate(_playerKnivesPrefab, _spawnPlayerKnives).GetComponent<Animator>().enabled = false;

        for(int i = 1; i < _loadLevelData.QuantityLittleBlueKnives; i++)
        {
            Instantiate(_playerKnivesPrefab, _spawnPlayerKnives).SetActive(false);
        }
    }
    #endregion

    public void GoToCircle()
    {
        int size = _loadLevelData.QuantityEnemyKnives;
        for (int i = 0; i < size; i++)
        {
            _knives[i].DOMove(_spawnPointsKnives[i].position, .5f);
            _knives[i].parent = _circle;
            _spawnPointsKnives[i].parent = _circle;
        }


        _knives[size - 1]
            .DOMove(_spawnPointsKnives[size - 1].position, .5f)
            .OnComplete(() => {
                _canHitAndStartRotation?.Invoke();
            });
        _knives[size - 1].parent = _circle;
        _spawnPointsKnives[size - 1].parent = _circle;
    }
}
