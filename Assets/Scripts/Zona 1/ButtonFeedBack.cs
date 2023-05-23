using UnityEngine;

public class ButtonFeedBack : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private Color color;
    [SerializeField] private float intensity = 100;

    public void SetEmission()
    {
        renderer.material.SetColor("_EmissionColor", color*intensity);
    }
}
