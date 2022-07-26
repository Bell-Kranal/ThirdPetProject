using UnityEngine;

public class LossInfo : MonoBehaviour
{
    [SerializeField] private GameObject _stage;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _homeButton;
    [SerializeField] private Transform _firstPointStage;
    [SerializeField] private Transform _secondPointStage;
    [SerializeField] private Transform _firstPointRestart;
    [SerializeField] private Transform _secondPointRestart;

    public GameObject Stage => _stage;
    public GameObject RestartButton => _restartButton;
    public GameObject HomeButton => _homeButton;
    public Transform FirstPointStage => _firstPointStage;
    public Transform SecondPointStage => _secondPointStage;
    public Transform FirstPointRestart => _firstPointRestart;
    public Transform SecondPointRestart => _secondPointRestart;
}
