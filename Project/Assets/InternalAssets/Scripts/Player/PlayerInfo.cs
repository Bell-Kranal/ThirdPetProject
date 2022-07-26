using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private int _sessionCounter;
    public int SessionCounter
    {
        get { return _sessionCounter; }
        set
        {
            _sessionCounter = value;
        }
    }

    private void Start()
    {
        _sessionCounter = 0;
    }
}
