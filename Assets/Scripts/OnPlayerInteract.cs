using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerInteract : MonoBehaviour
{
    [SerializeField] UnityEvent doOnInteract;
    [SerializeField] private Transform originalButtonTransform;
    [SerializeField] private Vector3 onButtonPressOriginalPosition;
    [SerializeField] private Vector3 onButtonPressChangedPosition;

    private void Awake()
    {
        originalButtonTransform = transform;
        onButtonPressChangedPosition = originalButtonTransform.position - new Vector3(0, 0.75f, 0);
        onButtonPressOriginalPosition = originalButtonTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("hand touched lever " + this.gameObject.name);
            doOnInteract.Invoke();
            originalButtonTransform.DOMove(onButtonPressChangedPosition, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            print("restoring lever original pos;");
            originalButtonTransform.DOMove(onButtonPressOriginalPosition, 0.5f);
        }
    }


}
