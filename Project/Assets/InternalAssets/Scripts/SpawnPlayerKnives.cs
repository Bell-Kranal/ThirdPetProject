using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerKnives : MonoBehaviour
{
    private List<PlayerKnifeController> _playerKnives = new List<PlayerKnifeController>();
    private int _currentIndex;
    
    void Start()
    {
        _currentIndex = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            _playerKnives.Add(transform.GetChild(i).GetComponent<PlayerKnifeController>());
        }
    }

    public void Fly()
    {
        if(_currentIndex < _playerKnives.Count)
        {
            _playerKnives[_currentIndex++].Fly();
            if(_currentIndex < _playerKnives.Count)
            {
                _playerKnives[_currentIndex].gameObject.SetActive(true);
            }
        }
    }

    public bool CanIncrement()
    {
        bool answer = false;
        if (_currentIndex < _playerKnives.Count)
        {
            answer = true;
        }
        else if(_currentIndex == _playerKnives.Count) {
            _currentIndex++;
            answer = true;
        }
        return answer;
    }
}
