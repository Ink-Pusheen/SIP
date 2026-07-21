using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InfluenceDialogue
{
    public string name; //Name of the influence type

    public List<string> DialogueLines = new(); //List of dialogue lines for this type
}

public class InfluencedNPC : InfluencedBase
{
    [Header("Sprite Changing")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] influenceSprites;
    /// <summary>
    /// 0 - Monochrome
    /// 1 - Forest
    /// 2 - Cave
    /// 3 - Snow
    /// </summary>

    [Header("Dialogue")]
    [SerializeField] List<InfluenceDialogue> dialogues = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Grab the actual sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnForestInfluence()
    {
        //Change the sprite
        if (spriteRenderer is not null) spriteRenderer.sprite = influenceSprites[1];
    }

    public override void OnCaveInfluence()
    {
        //Change the sprite
        if (spriteRenderer is not null) spriteRenderer.sprite = influenceSprites[2];
    }

    public override void OnSnowInfluence()
    {
        //Change the sprite
        if(spriteRenderer is not null) spriteRenderer.sprite = influenceSprites[3];
    }

    public InfluenceDialogue ReturnCurrentDialogue()
    {
        switch(GetCurState())
        {
            case MusicalInfluenceState.Forest:
                //Anything forest
                return dialogues[1];

            case MusicalInfluenceState.Cave:
                //Anything cave
                return dialogues[2];

            case MusicalInfluenceState.Snow:
                //Anything snow
                return dialogues[3];
        }

        return dialogues[0];
    }
}
