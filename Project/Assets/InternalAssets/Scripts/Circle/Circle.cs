using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Circle", menuName = "ScriptableObjects/Circle")]
public class Circle : ScriptableObject
{
    public List<CircleRotate> CircleRotates = new List<CircleRotate>();
    public Sprite CircleSprite;
}


[System.Serializable]
public struct CircleRotate
{
    public Ease Chart;
    public Vector3 RotateValue;
    public float Duration;
    public float StopRotationTime;
}