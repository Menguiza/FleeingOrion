using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDetector : MonoBehaviour
{
    [SerializeField] string tankTag;
    [SerializeField] TanksPuzzleManager tanksPuzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tankTag)
        {
            print("tank " + tankTag + " is in place!");

            if (other.tag == "blueTank" && other.tag == tankTag)
            {
                tanksPuzzleManager.DoWhenBlueTankInPosition();
                other.gameObject.GetComponent<Renderer>().enabled = false;

                Destroy(other.gameObject, 15f);

            }
            else if (other.tag == "redTank" && other.tag == tankTag)
            {
                tanksPuzzleManager.DoWhenRedTankInPosition();
                other.gameObject.GetComponent<Renderer>().enabled = false;
                Destroy(other.gameObject, 15f);
            }
        }
    }
}
