using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(LossInfo))]
public class LossController : MonoBehaviour
{
    private LossInfo _lossInfo;

    private void Awake()
    {
        _lossInfo = GetComponent<LossInfo>();
    }

    private void OnEnable()
    {
        BaseSettings();
        BeginAnimation();
    }

    private void BaseSettings()
    {
        _lossInfo.Stage.transform.position = _lossInfo.FirstPointStage.position;
        _lossInfo.RestartButton.transform.position = _lossInfo.FirstPointRestart.position;
        _lossInfo.HomeButton.transform.localScale = Vector3.zero;
    }

    private void BeginAnimation()
    {
        Sequence sequence = DOTween.Sequence();


        sequence.Append(_lossInfo.Stage.transform.DOMove(_lossInfo.SecondPointStage.position, .25f));
        sequence.Insert(0, _lossInfo.HomeButton.transform.DOScale(Vector3.one, .25f));
        sequence.Insert(0, _lossInfo.RestartButton.transform.DOMove(_lossInfo.SecondPointRestart.position, .25f));
    }
}
