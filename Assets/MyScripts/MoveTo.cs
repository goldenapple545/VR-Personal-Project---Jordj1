using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveTo : XRGrabInteractable
{
    [SerializeField] private Transform objectWillFollow;
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        StartCoroutine(MoveToObject());
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        
        StopCoroutine(MoveToObject());
        transform.position = objectWillFollow.position;
        transform.rotation = objectWillFollow.rotation;
    }

    IEnumerator MoveToObject()
    {
        while (true) {
            objectWillFollow.position = transform.position;
            objectWillFollow.rotation = transform.rotation;

            yield return null;
        }
    }
}
