using UnityEngine;
using UnityEngine.UI;

public class MusicNote : MonoBehaviour
{
    [SerializeField] Image barImage; //Display of the note
    [SerializeField] Button selfButton; //Reference to the self button

    [SerializeField] bool isActive; //Is this note currently active?



    private void Start()
    {
        barImage = GetComponent<Image>(); //Grab the image component

        selfButton = GetComponent<Button>(); //Grab Button Component
    }

    //Flip flop the active state
    public void AlterActiveState()
    {
        isActive = !isActive; //Swap the state

        //Change the image color accordingly

        if (isActive) barImage.color = Color.green; //Active

        else barImage.color = Color.white; //Inactive
    }

    //Force deactivate the specified node
    public void ForceDeactivate()
    {
        isActive = false; //Set to false

        barImage.color = Color.white; //Reset the color
    }

    public void SetInteractableState(bool isInteractable)
    {
        if (isInteractable) selfButton.interactable = true; //Make button interactable

        else selfButton.interactable = false; //Make button uninteractable
    }
}
