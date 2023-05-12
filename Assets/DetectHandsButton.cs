using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectHandsButton : MonoBehaviour
{
    [SerializeField] UnityEvent doOnHandTouch;
    [SerializeField] Level3ButtonPuzzle level3ButtonPuzzle;
    [SerializeField] int objectIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("hand touched button " +this.gameObject.name);
            level3ButtonPuzzle.CurrentIndex = objectIndex;
            level3ButtonPuzzle.CheckIndex();

        }
    }
}




