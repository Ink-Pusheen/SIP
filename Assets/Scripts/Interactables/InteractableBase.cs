using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    [SerializeField] GameObject interactIndicator;

    public virtual void OnInteract(PlayerLogic playerLogic)
    {

    }

    public void DisplayInteractionIndicator()
    {
        interactIndicator.SetActive(true);
    }

    public void HideInteractionIndicator()
    {
        interactIndicator.SetActive(false);
    }
}
