using UnityEngine;

public class NPCInteractable : InteractableBase
{
    InfluencedNPC npcInfluence; //The component of the npc influence

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
        Debug.Log("Talk to the NPC");
    }
}
