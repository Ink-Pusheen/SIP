using UnityEngine;

public class InteractionSphere : MonoBehaviour
{
    private PlayerScript player;

    private void Awake()
    {
        player = transform.parent.GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractableBase interactable = other.GetComponent<InteractableBase>();

        if (interactable == null) return;

        player.playerLogic.interactableInRange = other.gameObject;

        interactable.DisplayInteractionIndicator();
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableBase interactable = other.GetComponent<InteractableBase>();

        if (interactable == null) return;

        player.playerLogic.interactableInRange = null;

        interactable.HideInteractionIndicator();
    }
}
