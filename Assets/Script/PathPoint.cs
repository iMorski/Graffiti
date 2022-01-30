using System;
using TMPro;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField] private MeshRenderer Mesh;

    [SerializeField] private Color GroupFoundColor;
    [SerializeField] private Color GroupCheckedColor;
    
    [SerializeField] private TextMeshPro DistanceToStartTMP;
    [SerializeField] private TextMeshPro DistanceToFinishTMP;
    [SerializeField] private TextMeshPro DistanceSumTMP;

    [NonSerialized] public float DistanceToStart;
    [NonSerialized] public float DistanceToFinish;
    [NonSerialized] public float DistanceSum;
    
    [NonSerialized] public Transform Previous;

    public void SetGroupFoundColor()
    {
        Mesh.material.color = GroupFoundColor;
    }

    public void SetGroupCheckedColor()
    {
        Mesh.material.color = GroupCheckedColor;
    }

    public void SetDistanceToStart(float Value)
    {
        DistanceToStart = Value;
        DistanceToStartTMP.text = (Mathf.Round(Value * 10.0f) / 10.0f).ToString();
    }
    
    public void SetDistanceToFinish(float Value)
    {
        DistanceToFinish = Value;
        DistanceToFinishTMP.text = (Mathf.Round(Value * 10.0f) / 10.0f).ToString();
    }
    
    public void SetDistanceSum(float Value)
    {
        DistanceSum = Value;
        DistanceSumTMP.text = (Mathf.Round(Value * 10.0f) / 10.0f).ToString();
    }

    public void SetPrevious(Transform Point)
    {
        Previous = Point;
    }
}
