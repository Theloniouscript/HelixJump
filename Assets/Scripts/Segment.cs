using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SegmentType
{
    Default,
    Trap,
    Empty,
    Finish
}

public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;
    public SegmentType Type => type;
}
