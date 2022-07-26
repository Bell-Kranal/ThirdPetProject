using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerKnifeInfo))]
[RequireComponent(typeof(Animator))]
public class PlayerKnifeController : MonoBehaviour
{
    private PlayerKnifeInfo _playerKnifeInfo;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _playerKnifeInfo = GetComponent<PlayerKnifeInfo>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("Appearance");
    }

    public void Fly()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(Vector2.up * _playerKnifeInfo.Speed, ForceMode2D.Impulse);
    }

    public void ToCircle(Transform circle)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;

        transform.parent = circle;
        transform.position = circle.parent.GetChild(1).position;
    }
}
