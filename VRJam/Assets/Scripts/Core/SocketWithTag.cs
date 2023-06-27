using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTag : XRSocketInteractor
{
    [SerializeField] private List<string> tags = new List<string>();

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
    }

    private void ToggleMesh(bool value)
    {
        meshRenderer.enabled = value;
    }
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && HasRelevantTag(interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && HasRelevantTag(interactable);
    }

    private bool HasRelevantTag(IXRInteractable interactable)
    {
        return tags.Contains(interactable.transform.tag);
    }
}
