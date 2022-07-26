using UnityEngine;
using UnityEngine.UI;

public class MainUIInfo : MonoBehaviour
{
    [Header("Knife Info")]
    [SerializeField] private GameObject _knife;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [Header("Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _bottomBarMiracle;
    [SerializeField] private GameObject _bottomBarKnives;
    [SerializeField] private GameObject _bottomBarBonus;
    [SerializeField] private Transform _settings;

    [Header("Text")]
    [SerializeField] private GameObject _knifeText;
    [SerializeField] private Transform _firstPointKnifeText;
    [SerializeField] private Transform _secondPointKnifeText;
    [SerializeField] private Transform _thirdPointKnifeText;
    [SerializeField] private GameObject _hitText;
    [SerializeField] private Transform _firstPointHitText;
    [SerializeField] private Transform _secondPointHitText;
    [SerializeField] private Transform _thirdPointHitText;

    [Header("Other Objects")]
    [SerializeField] private Image _flyKnife;
    [SerializeField] private Transform _stageAndScoreText;
    [SerializeField] private Transform _bottomBarPoint;
    [SerializeField] private Transform _topBarPoint;
    [SerializeField] private Transform _spawnPlayerKnives;
    [SerializeField] private GameObject _topBar;
    [SerializeField] private GameObject _bottomBar;

    public GameObject MainUIKnife => _knife;
    public GameObject PlayButton => _playButton;
    public GameObject BottomBarMiracle => _bottomBarMiracle;
    public GameObject BottomBarKnives => _bottomBarKnives;
    public GameObject BottomBarBonus => _bottomBarBonus;
    public GameObject KnifeText => _knifeText;
    public GameObject HitText => _hitText;
    public GameObject TopBar => _topBar;
    public GameObject BottomBar => _bottomBar;
    public Transform TopBarPoint => _topBarPoint;
    public Transform BottomBarPoint => _bottomBarPoint;
    public Transform Settings => _settings;
    public Transform FirstPointKnife => _firstPoint;
    public Transform SecondPointKnife => _secondPoint;
    public Transform FirstPointKnifeText => _firstPointKnifeText;
    public Transform SecondPointKnifeText => _secondPointKnifeText;
    public Transform ThirdPointKnifeText => _thirdPointKnifeText;
    public Transform FirstPointHitText => _firstPointHitText;
    public Transform SecondPointHitText => _secondPointHitText;
    public Transform ThirdPointHitText => _thirdPointHitText;
    public Transform StageAndScoreText => _stageAndScoreText;
    public Transform SpawnPlayerKnives => _spawnPlayerKnives;
    public Image FlyKnife => _flyKnife;

}
