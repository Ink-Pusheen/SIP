using System;
using UnityEngine;

public class AudioInteractable : InteractableBase
{
    public AudioCollectable audioToCapture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract(PlayerLogic playerLogic)
    {
        if (audioToCapture == null)
        {
            throw new ArgumentException("Audio is null");
        }
        Debug.Log("Capture Audio");
        playerLogic.inventory.playerInventoryLogic.AddCollectable(audioToCapture);
    }
}
