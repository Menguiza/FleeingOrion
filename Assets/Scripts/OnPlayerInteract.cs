using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerInteract : MonoBehaviour
{
    [SerializeField] UnityEvent doOnInteract;
    [SerializeField] Transform originalButtonTransform;
    [SerializeField] private Vector3 originalButtonPosition;
    [SerializeField] private Vector3 onButtonPressOriginalPosition;
    [SerializeField] private Vector3 onButtonPressChangedPosition;

    [SerializeField] float howMuchShouldGoDown = 0.15f;

    private void Awake()
    {
        originalButtonPosition = transform.position;
        onButtonPressChangedPosition = originalButtonPosition - new Vector3(0, howMuchShouldGoDown, 0);
        onButtonPressOriginalPosition = originalButtonPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("hand touched lever " + this.gameObject.name);
            doOnInteract.Invoke();
            originalButtonTransform.DOMove(onButtonPressChangedPosition, 0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("restoring lever original pos;");
            originalButtonTransform.DOMove(onButtonPressOriginalPosition, 0.2f);
        }
    }


}
