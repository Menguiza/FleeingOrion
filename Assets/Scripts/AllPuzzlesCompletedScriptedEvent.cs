using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPuzzlesCompletedScriptedEvent : MonoBehaviour
{
   [SerializeField] GameObject particleSystem1, particleSystem2;
   public void StartEndOfGame()
    {
        print("game will end soon");
        StartCoroutine(IE_EndOfGame());
    }

    IEnumerator IE_EndOfGame()
    {
        yield return new WaitForSeconds(3f);
        particleSystem1.SetActive(true);
        yield return new WaitForSeconds(3f);
        particleSystem2.SetActive(true);
        yield return new WaitForSeconds(3f);

        //add load next level logic


    }
}
