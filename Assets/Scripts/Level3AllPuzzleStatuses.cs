using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    bool allPuzzlesCompleted;
    [SerializeField] UnityEvent allPuzzlesCompletedEvent;

    bool levelShouldEnd;
    //this is boilder plate code, but they requested us to finish the whole game in less than a week while not even the basic mechanics were done
    //hence why the not-very-elegant code

    private void Update()
    {
        if (IsPuzzle1Completed && IsPuzzle2Completed && IsPuzzle3Completed && !levelShouldEnd)
        {
            print("all puzzles have been completed!");
            allPuzzlesCompletedEvent.Invoke();
            levelShouldEnd = true;
        }
    }

    public void OnButton1Activate()
    {
        print("Hub checking puzzle 1");

        if (IsPuzzle1Completed)
        {
            StartCoroutine(IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator1));
        }
        else
        {
            StartCoroutine(IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator1));
        }
        
    }

    public void OnButton2Activate()
    {
        print("Hub checking puzzle 2");

        if (IsPuzzle2Completed)
        {
            StartCoroutine(IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator2));
        }
        else
        {
            StartCoroutine(IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator2));
        }

    }

    public void OnButton3Activate()
    {
        print("Hub checking puzzle 3");

        if (IsPuzzle3Completed)
        {
            StartCoroutine(IE_FlickerMaterial(puzzleFinishedMaterial, correctIndicator3));
            
        }
        else
        {
            StartCoroutine(IE_FlickerMaterial(puzzleWrongMaterial, correctIndicator3));
        }

    }

    public void TurnIsPuzzle3CompletedOn()
    {
        IsPuzzle3Completed = true;
    }



    IEnumerator IE_FlickerMaterial(Material materialToFlashTo, GameObject correctIndicator)
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
