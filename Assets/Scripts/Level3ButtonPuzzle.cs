using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Level3ButtonPuzzle : MonoBehaviour
{
    public int expectedIndex;

    [SerializeField] GameObject correctIndicator;

    [SerializeField] Material correctMaterial;
    [SerializeField] Material puzzleFinishedMaterial;
    [SerializeField] Material incorrectMaterial;
    [SerializeField] Material neutralMaterial;


    public int CurrentIndex = 0;

    public bool HasChecked = false;
    public bool puzzleCompleted = false;

    public void CheckIndex() //correct sequence is 0, 1, 2, 3
    {
        //will refactor code after testing its full vr functionality
        if (!HasChecked && !puzzleCompleted)
        {
            StartCoroutine(HasCheckedCooldown());
            if (CurrentIndex == expectedIndex)
            {
                print("Correct!");
                StartCoroutine(flashMaterialCorrect());
                expectedIndex++;
                HasChecked = true;

                if (expectedIndex > 3) expectedIndex = 3;

                if (expectedIndex == 3 && CurrentIndex ==3)
                {
                    HasChecked = true;
                    puzzleCompleted = true;
                    StartCoroutine(flashMaterialPuzzleFinished());
                    Debug.Log("Puzzle completed!");
                }

                return;
            }
            else
            {
                print("Incorrect!");

                StartCoroutine(flashMaterialIncorrect());
                expectedIndex = 0;
                HasChecked = true;

            }

           
        }
       
    }
    IEnumerator HasCheckedCooldown()
    {
        yield return new WaitForSeconds(0.75f);
        HasChecked = false;
    }

    IEnumerator flashMaterialPuzzleFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
            yield return new WaitForSeconds(0.25f);
            correctIndicator.GetComponent<Renderer>().material = puzzleFinishedMaterial;
            yield return new WaitForSeconds(0.25f);

        }
        correctIndicator.GetComponent<Renderer>().material = puzzleFinishedMaterial;
    }
    IEnumerator flashMaterialCorrect()
    {
        for (int i = 0; i < 5; i++)
        {
            correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
            yield return new WaitForSeconds(0.15f);
            correctIndicator.GetComponent<Renderer>().material = correctMaterial;
            yield return new WaitForSeconds(0.15f);

        }
        correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
    }

    IEnumerator flashMaterialIncorrect()
    {
        for (int i = 0; i < 5; i++)
        {
            correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
            yield return new WaitForSeconds(0.15f);

            correctIndicator.GetComponent<Renderer>().material = incorrectMaterial;
            yield return new WaitForSeconds(0.15f);

        }
        correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
    }

}
