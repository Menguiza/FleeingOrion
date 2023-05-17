using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3AllPuzzleStatuses : MonoBehaviour
{
    [SerializeField] GameObject correctIndicator1;
    [SerializeField] GameObject correctIndicator2;
    [SerializeField] GameObject correctIndicator3;

    [SerializeField] Material neutralMaterial;
    [SerializeField] Material puzzleFinishedMaterial;
    [SerializeField] Material puzzleWrongMaterial;


    public bool IsPuzzle1Completed;
    public bool IsPuzzle2Completed;
    public bool IsPuzzle3Completed;

    public void OnButton1Activate()
    {
        if (IsPuzzle1Completed) 
        {
            IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator1);
        }
        else
        {
            IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator1);
        }
        
    }

    public void OnButton2Activate()
    {
        if (IsPuzzle2Completed)
        {
            IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator2);
        }
        else
        {
            IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator2);
        }

    }

    public void OnButton3Activate()
    {
        if (IsPuzzle3Completed)
        {
            IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator3);
        }
        else
        {
            IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator3);
        }

    }



    IEnumerable IE_FlickerMaterial(Material materialToFlashTo, GameObject correctIndicator)
    {
        for (int i = 0; i < 5; i++)
        {
            correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
            yield return new WaitForSeconds(0.15f);
            correctIndicator.GetComponent<Renderer>().material = materialToFlashTo;
            yield return new WaitForSeconds(0.15f);

        }
        correctIndicator.GetComponent<Renderer>().material = materialToFlashTo;
    }

}
