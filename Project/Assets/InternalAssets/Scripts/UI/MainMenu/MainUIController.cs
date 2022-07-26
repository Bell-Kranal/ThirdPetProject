using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(MainUIInfo))]
public class MainUIController : MonoBehaviour
{
    [SerializeField] private UnityEvent _playUIController;
    [SerializeField] private UnityEvent _activePlayerKnives;

    private MainUIInfo _mainUIInfo;
    private Tween[] tweens = new Tween[4];

    private void Start()
    {
        _mainUIInfo = GetComponent<MainUIInfo>();

        CallAnimation(false);
    }

    private void CallAnimation(bool goHome)
    {
        SetBasicPositionsAndScales(goHome);
        StartAnimation(goHome);
    }

    #region [Setting Basic Values]
    private void SetBasicPositionsAndScales(bool goHome)
    {
        if(!goHome)
        {
            _mainUIInfo.KnifeText.transform.position = _mainUIInfo.FirstPointKnifeText.position;
            _mainUIInfo.HitText.transform.position = _mainUIInfo.FirstPointHitText.position;
            _mainUIInfo.FlyKnife.color = new Color(255f, 255f, 255f, 0f);
        }
        else
        {
            _mainUIInfo.FlyKnife.color = new Color(255f, 255f, 255f, 255f);
            _mainUIInfo.KnifeText.transform.position = _mainUIInfo.SecondPointKnifeText.position;
            _mainUIInfo.HitText.transform.position = _mainUIInfo.SecondPointHitText.position;
            _mainUIInfo.TopBar.transform.localScale = Vector3.zero;
        }

        _mainUIInfo.StageAndScoreText.gameObject.SetActive(true);
        _mainUIInfo.MainUIKnife.transform.position = _mainUIInfo.FirstPointKnife.position;
        _mainUIInfo.PlayButton.transform.localScale = Vector3.zero;
        _mainUIInfo.StageAndScoreText.transform.localScale = Vector3.zero;
    }
    #endregion
    #region [Main UI Animation]
    private void StartAnimation(bool goHome)
    {
        Sequence uiAmiation = DOTween.Sequence();

        MainUIAnimationAppends(uiAmiation);
        MainUIAnimationInserts(uiAmiation);


        if (!goHome)
        {
            SetAnimation(_mainUIInfo.KnifeText, _mainUIInfo.SecondPointKnifeText, _mainUIInfo.ThirdPointKnifeText, 0);
            SetAnimation(_mainUIInfo.HitText, _mainUIInfo.SecondPointHitText, _mainUIInfo.ThirdPointHitText, 2);
        }
        else
        {
            _mainUIInfo.TopBar.transform.DOScale(Vector3.one, .25f);
        }

        _mainUIInfo.FlyKnife
            .DOFade(1, 1.25f)
            .SetDelay(1.5f)
            .OnComplete(() => {
                _mainUIInfo.FlyKnife
                    .DOFade(0.75f, 1.25f)
                    .SetLoops(-1, LoopType.Yoyo);
            });
    }

    private void MainUIAnimationAppends(Sequence sequence)
    {
        sequence.Append(_mainUIInfo.MainUIKnife.transform.DOMoveY(_mainUIInfo.SecondPointKnife.position.y, 0.75f));

        AddAppendScaleInMainUIAnimation(sequence, _mainUIInfo.PlayButton.transform);
        AddAppendScaleInMainUIAnimation(sequence, _mainUIInfo.BottomBarMiracle.transform);
        AddAppendScaleInMainUIAnimation(sequence, _mainUIInfo.BottomBarKnives.transform);
        AddAppendScaleInMainUIAnimation(sequence, _mainUIInfo.BottomBarBonus.transform);
    }

    private void MainUIAnimationInserts(Sequence sequence)
    {
        sequence.Insert(2, _mainUIInfo.StageAndScoreText.transform.DOScale(Vector3.one, .25f));
        sequence.Insert(2, _mainUIInfo.Settings.DOScale(Vector3.one / 2, .25f));
    }

    private void AddAppendScaleInMainUIAnimation(Sequence sequence, Transform gameObject)
    {
        sequence.Append(gameObject.DOScale(Vector3.one, 0.15f));
    }

    private void SetAnimation(GameObject gameObject, Transform firstPoint, Transform secondPoint, int tweenIndex)
    {
        gameObject.transform
            .DOMoveX(firstPoint.position.x, 0.75f)
            .SetDelay(1.2f)
            .OnComplete(() => {

                tweens[tweenIndex] = gameObject.transform
                    .DOMove(secondPoint.position, 2.25f)
                    .SetEase(Ease.Flash)
                    .SetLoops(-1, LoopType.Yoyo);

                tweens[tweenIndex + 1] = gameObject.transform
                    .DORotateQuaternion(secondPoint.rotation, 2.25f)
                    .SetEase(Ease.Flash)
                    .SetLoops(-1, LoopType.Yoyo);
            });
    }
    #endregion
    #region [Go To Play]

    public void GoToPlay()
    {
        _playUIController?.Invoke();

        foreach(Tween tween in tweens)
        {
            tween.Kill();
        }

        DOMoveY(_mainUIInfo.TopBar.transform, _mainUIInfo.TopBarPoint.transform, .55f);
        DOMoveY(_mainUIInfo.BottomBar.transform, _mainUIInfo.BottomBarPoint.transform, .25f);
        DOMoveY(_mainUIInfo.PlayButton.transform, _mainUIInfo.BottomBarPoint.transform, .25f);

        _mainUIInfo.Settings.DOScale(Vector3.zero, 0.15f);
        _mainUIInfo.StageAndScoreText.gameObject.SetActive(false);

        _mainUIInfo.MainUIKnife.transform
            .DOMoveY(_mainUIInfo.SpawnPlayerKnives.transform.position.y, .25f)
            .OnComplete(() => {
                _activePlayerKnives?.Invoke();
                _mainUIInfo.MainUIKnife.SetActive(false);
            });
    }

    private void DOMoveY(Transform transformObjectAnimation, Transform position, float duration)
    {
        transformObjectAnimation
            .DOMoveY(position.position.y, duration)
            .OnComplete(() => {
                transformObjectAnimation.gameObject.SetActive(false);
            });
    }

    #endregion
}
