using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnifeInfo : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        private set
        {
            _speed = value;
        }
    }
}
