using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPuzzlesCompletedScriptedEvent : MonoBehaviour
{
   [SerializeField] GameObject particleSystem1, particleSystem2;
   public void StartEndOfGame()
    {
        StartCoroutine(IE_EndOfGame());
    }

    IEnumerator IE_EndOfGame()
    {
        yield return new WaitForSeconds(3f);
        particleSystem1.SetActive(true);
        yield return new WaitForSeconds(4f);
        particleSystem2.SetActive(true);

        //add load next level logic


    }
}
