using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class CircleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticleSystem;
    [SerializeField] private UnityEvent _knivesToCircle;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.enabled = true;
    }

    private void OnEnable()
    {
        _animator.SetTrigger("Enable");
    }

    public void Hit()
    {
        _animator.SetTrigger("Flash");
        _hitParticleSystem.Play();
    }

    public void KnivesToCircle()
    {
        _knivesToCircle?.Invoke();
    }
}
