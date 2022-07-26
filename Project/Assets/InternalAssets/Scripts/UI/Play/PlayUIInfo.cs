using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUIInfo : MonoBehaviour
{
    [SerializeField] private RectTransform _spawnBlueKnives;
    [SerializeField] private RectTransform _stages;
    [SerializeField] private Color _usedBlueKnifeColor;
    [SerializeField] private TextMeshProUGUI _sessionCounterText;


    private Queue<Image> _blueKnives = new Queue<Image>();

    public RectTransform BlueKnifes => _spawnBlueKnives;
    public RectTransform Stages => _stages;
    public Color UsedBlueKnifeColor => _usedBlueKnifeColor;
    public TextMeshProUGUI SessionCounterText => _sessionCounterText;


    public Image BlueKnife
    {
        private set { }
        get
        {
            if (_blueKnives.Count != 0)
            {
                return _blueKnives.Dequeue();
            }

            return null;
        }
    }

    private void Start()
    {
        for(int i = 0; i < _spawnBlueKnives.childCount; i++)
        {
            _blueKnives.Enqueue(_spawnBlueKnives.GetChild(i).GetComponent<Image>());
        }
    }
}
