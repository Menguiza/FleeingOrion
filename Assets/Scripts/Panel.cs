using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Panel : MonoBehaviour
{
    public Color redEmission, greenEmission;
    public Material wrongMat, correctMat;
    public List<MeshRenderer> buttons = new List<MeshRenderer>(4);
    public UnityEvent Passed, Failed;

    //Utility
    private List<string> codeAttempt = new List<string>(4);
    private string[] correct = { "AZUL", "ROJO", "VERDE", "AMARILLO" };
    private List<Material> materials = new List<Material>(4);

    private void Start()
    {
        foreach (MeshRenderer element in buttons)
        {
            materials.Add(element.material);
        }
    }

    public void ButtonPressed(string color)
    {
        codeAttempt.Add(color.ToUpper());

        if (codeAttempt.Count == 4)
        {
            if (CheckCode())
            {
                SetMaterial(correctMat, greenEmission, 10);
                Passed.Invoke();
            }
            else
            {
                SetMaterial(wrongMat, redEmission, 100);
                Invoke("FailedDelay", 1f);
            }
        }
    }

    public void ClearAttempt()
    {
        codeAttempt.Clear();
    }

    private bool CheckCode()
    {
        for (int i = 0; i < 4; i++)
        {
            if (codeAttempt.ElementAt(i) != correct[i])
            {
                return false;
            }
        }

        return true;
    }

    private void SetMaterial(Material mat, Color color, float intensity)
    {
        StartCoroutine(SetMat(mat, color, intensity));
    }

    private void ResetMaterial()
    {
        StartCoroutine(SetMat(Color.black, 0));
    }
    
    private void SetEmission(MeshRenderer rend, Color color, float intensity)
    {
        rend.material.SetColor("_EmissionColor", color*intensity);
    }
    
    private void FailedDelay()
    {
        Failed.Invoke();
        
        ResetMaterial();
    }

    private IEnumerator SetMat(Material mat, Color color, float intensity)
    {
        foreach (MeshRenderer element in buttons)
        {
            Material temp = element.material;
            
            element.material = mat;

            yield return new WaitUntil(()=> element.material != temp);
        
            SetEmission(element, color, intensity);
        }
    }
    
    private IEnumerator SetMat(Color color, float intensity)
    {
        int count = 0;
        
        foreach (MeshRenderer element in buttons)
        {
            Material temp = element.material;
            
            element.material = materials.ElementAt(count);

            yield return new WaitUntil(()=> element.material != temp);
        
            SetEmission(element, color, intensity);

            count++;
        }
    }
}
