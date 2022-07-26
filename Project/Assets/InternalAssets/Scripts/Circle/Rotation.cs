using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Rotation : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    
    private Sequence sequence;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _loadLevel.LoadLevelData.CircleData.CircleSprite;

        SetSequence();
    }

    private void SetSequence()
    {
        sequence = DOTween.Sequence();

        foreach (CircleRotate circleRotate in _loadLevel.LoadLevelData.CircleData.CircleRotates)
        {
            sequence.Append(
                    transform
                        .DORotate(circleRotate.RotateValue * (Random.Range(-1, 1) == 0 ? 1 : -1), circleRotate.Duration, RotateMode.FastBeyond360)
                        .SetLoops(-1, LoopType.Incremental)
                        .SetEase(circleRotate.Chart)
                    );
            sequence.AppendInterval(circleRotate.StopRotationTime);
        }
        sequence.SetLoops(-1, LoopType.Yoyo);
        sequence.Pause();
    }

    public void StartAnimation()
    {
        sequence.Restart();
    }
}
