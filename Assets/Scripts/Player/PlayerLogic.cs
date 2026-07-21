using System;
using UnityEngine;



[Serializable]
public class PlayerLogic
{
    [Header("Logic Cores")]
    public PlayerInventory inventory;

    [Header("Movement")]
    private Rigidbody rb;

    public float moveSpeed = 6;
    public float moveClamp = 6;

    [Header("Interaction")]
    public GameObject interactableInRange;

    [Header("Inventory")]
    public bool inInventory { get; private set; }

    public PlayerLogic(Rigidbody Rigidbody)
    {
        rb = Rigidbody;
    }

    #region Player Movement

    public void MoveCharacter(float x, float y)
    {
        Vector3 moveForce = Vector3.ClampMagnitude(new Vector3(x, 0, y) * moveSpeed, moveClamp);

        //rb.AddForce(moveForce);
        rb.linearVelocity = moveForce;
    }

    public void Interact()
    {
        if (interactableInRange == null)
        {
            Debug.Log("Nothing to Interact with");
        }
        else
        {
            interactableInRange.GetComponent<InteractableBase>().OnInteract(this);
        }
    }

    #endregion Player Movement

    #region Inventory

    public void OpenInventoryMenus()
    {
        inventory.OpenInventoryMenus();
        inInventory = !inInventory;
    }

    public void ExitInventoryMenus()
    {
        inInventory = !inInventory;
    }

    #endregion
}
