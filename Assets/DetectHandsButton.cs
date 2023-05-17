using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectHandsButton : MonoBehaviour
{
    [SerializeField] UnityEvent doOnHandTouch;
    [SerializeField] Level3ButtonPuzzle level3ButtonPuzzle;
    [SerializeField] int objectIndex;

    [SerializeField] private Transform originalButtonTransform;
    [SerializeField] private Vector3 onButtonPressOriginalPosition;
    [SerializeField] private Vector3 onButtonPressChangedPosition;

    private void Awake()
    {
        onButtonPressChangedPosition = originalButtonTransform.position - new Vector3(0, 0.0267f, 0);
        onButtonPressOriginalPosition = originalButtonTransform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("hand touched button " + this.gameObject.name);
            level3ButtonPuzzle.CurrentIndex = objectIndex;
            level3ButtonPuzzle.CheckIndex();
            originalButtonTransform.DOMove(onButtonPressChangedPosition, 0.2f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("restoring button original pos;");
            originalButtonTransform.DOMove(onButtonPressOriginalPosition, 0.2f);
        }
    }

}


