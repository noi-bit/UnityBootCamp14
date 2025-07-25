using UnityEngine;

public enum Projection
{
    Perspective,Orthographic
}

public enum FieldofViewAxis
{
    Vertical,Horizontal
}

public class ClippingPlanes
{
    public int Near;
    public int Far;
}

public class sample2 : MonoBehaviour
{   
    public Projection Projection;
    public FieldofViewAxis FieldOfViewAxis;
    public float FieldOfView;
    public float ClippingPlanesNear;
    public float ClippingPlanesFar;
    public bool PhysicalCamera;
}
