using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoSocket : XRSocketInteractor
{
    private float removeTime = 0.0f;

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        StoreTime();
    }

    private void StoreTime()
    {
        removeTime = Time.time;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return CanQuickSelect(interactable) && HasSelectTime();
    }

    private bool CanQuickSelect(IXRSelectInteractable interactable)
    {
        return !hasSelection || IsSelecting(interactable);
    }

    private bool HasSelectTime()
    {
        return removeTime == 0.0f || Time.time > removeTime + recycleDelayTime;
    }
}
