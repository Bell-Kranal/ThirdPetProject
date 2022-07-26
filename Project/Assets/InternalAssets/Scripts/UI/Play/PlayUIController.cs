using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(PlayUIInfo))]
public class PlayUIController : MonoBehaviour
{
    [SerializeField] private GameObject _circle;

    private PlayUIInfo _playUIInfo;

    private void Start()
    {
        _playUIInfo = GetComponent<PlayUIInfo>();

        gameObject.SetActive(false);
    }
    public void Hit()
    {
        Image sprite = _playUIInfo.BlueKnife;
        if (sprite != null) { 
            sprite.color = _playUIInfo.UsedBlueKnifeColor;
        }
    }

    public void ChangeSessionCounterText(int newSessionCounterValue)
    {
        _playUIInfo.SessionCounterText.text = newSessionCounterValue.ToString();
    }


    public void OpenPlayUI()
    {
        gameObject.SetActive(true);

        SizeIncrease(_playUIInfo.Stages);
        SizeIncrease(_playUIInfo.BlueKnifes);
    }

    private void SizeIncrease(Transform playObject) 
    {
        playObject.localScale = Vector3.zero;
        playObject.DOScale(Vector3.one, .25f);
    }
}