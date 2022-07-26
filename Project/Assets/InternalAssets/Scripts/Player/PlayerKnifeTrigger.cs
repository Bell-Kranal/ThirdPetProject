using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKnifeController))]
public class PlayerKnifeTrigger : MonoBehaviour
{
    private PlayerKnifeController _playerKnifeController;

    private void Start()
    {
        _playerKnifeController = GetComponent<PlayerKnifeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CircleController circle))
        {
            circle.Hit();

            _playerKnifeController.ToCircle(collision.transform);
            GetComponent<PlayerKnifeTrigger>().enabled = false;
        }
    }
}
