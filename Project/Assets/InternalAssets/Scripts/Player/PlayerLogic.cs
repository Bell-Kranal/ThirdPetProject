using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInfo))]
public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private MyIntEvent _changeUISessionCounter = new MyIntEvent();
    [SerializeField] private SpawnPlayerKnives _spawnPlayerKnives;

    private PlayerInfo _playerInfo;

    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }

    public void IncrementSessionCounter()
    {
        if(_spawnPlayerKnives.CanIncrement())
        {
            _playerInfo.SessionCounter++;
            _changeUISessionCounter?.Invoke(_playerInfo.SessionCounter);
        }
    }
}
[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}