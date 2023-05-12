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
    [SerializeField] Material incorrectMaterial;
    [SerializeField] Material neutralMaterial;


    public int CurrentIndex = 0;

    public bool HasChecked = false;

    public void CheckIndex() //correct sequence is 0, 1, 2, 3
    {
        if (!HasChecked)
        {
            StartCoroutine(HasCheckedCooldown());
            if (CurrentIndex == expectedIndex)
            {
                print("Correct!");
                //StartCoroutine(flashMaterialCorrect());
                expectedIndex++;
                HasChecked = true;
                return;
            }
            else
            {
                print("Incorrect!");

                //StartCoroutine(flashMaterialIncorrect());
                expectedIndex = 0;
                HasChecked = true;

            }

            if (CurrentIndex == expectedIndex && expectedIndex == 3)
            {
                correctIndicator.GetComponent<Renderer>().material = correctMaterial;
                Debug.Log("Puzzle completed!");
                HasChecked = true;

            }
        }
       
    }
    IEnumerator HasCheckedCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        HasChecked = false;
    }

    //IEnumerator flashMaterialCorrect()
    //{
    //    for(int i = 0; i < 5; i++) 
    //    {
    //        correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
    //        yield return new WaitForSeconds(0.25f);
    //        correctIndicator.GetComponent<Renderer>().material = correctMaterial;
    //    }
    //}

    //IEnumerator flashMaterialIncorrect()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        correctIndicator.GetComponent<Renderer>().material = neutralMaterial;
    //        yield return new WaitForSeconds(0.25f);
    //        correctIndicator.GetComponent<Renderer>().material = incorrectMaterial;
    //    }
    //}

}
