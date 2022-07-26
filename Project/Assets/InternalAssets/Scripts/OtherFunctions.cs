using UnityEngine;
using UnityEngine.Events;

public class OtherFunctions : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPlayerKnives;
    [SerializeField] private GameObject _circle;
    [SerializeField] private UnityEvent _hit;

    private bool _canHit;

    private void Start()
    {
        _canHit = false;
    }

    public void AсtiveSpawnPlayerKnivesAndCircle()
    {
        _spawnPlayerKnives.SetActive(true);

        _circle.SetActive(true);
    }

    public void SetTrueCanHit()
    {
        _canHit = true;
    }

    public void TryHit()
    {
        if(_canHit)
        {
            _hit?.Invoke();
        }
    }
}
