using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksPuzzleManager : MonoBehaviour
{
    [SerializeField] bool isBlueTankInPosition;
    [SerializeField] bool isRedTankInPosition;

    [SerializeField] Level3AllPuzzleStatuses allPuzzleStatuses;

    public bool puzzleCompleted;

    [SerializeField] GameObject redTankIndicator, blueTankIndicator;
    [SerializeField] GameObject redTank, blueTank;

    [SerializeField] Material indicatorMaterialSuccess;

    private void Update()
    {
        
    }

    public void DoWhenBlueTankInPosition()
    {
        blueTankIndicator.GetComponent<Renderer>().material = indicatorMaterialSuccess;
        isBlueTankInPosition = true;
        blueTank.SetActive(true);

        if (isBlueTankInPosition && isRedTankInPosition)
        {
            print("succesfully placed both tanks");
            print("tank puzzle compelted");
            puzzleCompleted = true;
            allPuzzleStatuses.IsPuzzle2Completed = true;
        }
    }
    public void DoWhenRedTankInPosition()
    {
        redTankIndicator.GetComponent<Renderer>().material = indicatorMaterialSuccess;
        isRedTankInPosition = true;
        redTank.SetActive(true);

        if (isBlueTankInPosition && isRedTankInPosition)
        {
            print("succesfully placed both tanks");
            print("tank puzzle compelted");
            puzzleCompleted = true;
            allPuzzleStatuses.IsPuzzle2Completed = true;
        }

    }

}
