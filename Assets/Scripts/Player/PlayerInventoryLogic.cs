using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class AudioSlot
{
    public string name;

    public TMP_Text soundName;

    public GameObject containerObject;
}

[Serializable]
public class PlayerInventoryLogic
{
    [Header("Logic Cores")]
    public PlayerScript playerScript { private get; set; }

    [Header("Inventory")]
    public List<AudioCollectable> audioCollectables = new List<AudioCollectable>();
    public AudioSlot[] audioSlots;

    public int curSelectionPage;
    [SerializeField] int selectionPages;

    [SerializeField] Button selectionUp;
    [SerializeField] Button selectionDown;

    public int inventoryIndex;

    [Header("Audio Setting")]
    public GameObject audioSetter; //Panel to set the audio to the selected music sheet track


    public void CloseInventoryMenus()
    {
        playerScript.playerLogic.ExitInventoryMenus();
    }

    public void AddCollectable(AudioCollectable audioCollectableCollected)
    {
        if (audioCollectables.Contains(audioCollectableCollected))
        {
            Debug.Log("Already Collected");
        }
        else
        {
            audioCollectables.Add(audioCollectableCollected);

            if (audioCollectables.Count > 5)
            {
                selectionPages = Mathf.FloorToInt(audioCollectables.Count / 5);
            }
            else
            {
                selectionPages = 0;
            }
        }
    }

    public void UpdateSoundInventory()
    {
        if (audioCollectables.Count == 0)
        {
            for (int slot = 0; slot < audioSlots.Length; slot++)
            {
                audioSlots[slot].containerObject.SetActive(false);
            }

            selectionUp.interactable = false;
            selectionDown.interactable = false;

            return;
        }

        //Disable while loading
        selectionUp.interactable = false;
        selectionDown.interactable = false;

        int slotObject = 0;

        for (int slot = inventoryIndex; slot < inventoryIndex + 5; slot++)
        {
            if (audioCollectables.Count > slot)
            {
                audioSlots[slotObject].containerObject.SetActive(true);

                audioSlots[slotObject].soundName.text = audioCollectables[slot].soundName;
            }
            else
            {
                audioSlots[slotObject].containerObject.SetActive(false);
            }

            slotObject++;
        }

        if (audioCollectables.Count > 5)
        {
            if (inventoryIndex == 0)
            {
                selectionUp.interactable = false;
                selectionDown.interactable = true;
            }
            else
            {
                selectionUp.interactable = curSelectionPage > 0 ? true : false; 

                selectionDown.interactable = curSelectionPage == selectionPages ? false : true;
            }
        }
        else
        {
            selectionUp.interactable = false;
            selectionDown.interactable = false;
        }
    }

    public void ScrollList(bool scrollUp)
    {
        inventoryIndex += scrollUp ? -5 : 5;
        curSelectionPage += scrollUp ? -1 : 1;

        UpdateSoundInventory();
    }

    public void OpenAssignMenu(int audioSlot)
    {
        //Grab the audiocollectable
        AudioCollectable selectedAudioCollectable = audioCollectables[audioSlot + inventoryIndex];

        //Open the audio setter
        audioSetter.SetActive(true);

        //Set the audio collectable
        audioSetter.GetComponent<MusicSoundAssigner>().audioToAssign = selectedAudioCollectable;
    }
}
