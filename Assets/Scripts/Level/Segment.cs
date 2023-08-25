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

[RequireComponent(typeof(MeshRenderer))]
public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;
    public SegmentType Type => type;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material trapMaterial;
    [SerializeField] private Material finishMaterial;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }

    public void SetTrap()
    {
        meshRenderer.enabled = true;
        meshRenderer.material = trapMaterial;

        type = SegmentType.Trap;
    }

    public void SetEmpty()
    {
        meshRenderer.enabled = false;

        type = SegmentType.Empty;
    }

    public void SetFinish()
    {
        meshRenderer.enabled = true;
        meshRenderer.material = finishMaterial;

        type = SegmentType.Finish;
    }


}
