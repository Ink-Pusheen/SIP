using System;
using UnityEngine;

[Serializable]
public class MenuStates
{
    public string name;
    public GameObject menuObject;
}

public class PlayerInventory : MonoBehaviour
{
    [Header("States")]
    [SerializeField] MenuStates[] menuStates;

    [Header("Logic Cores")]
    public PlayerInventoryLogic playerInventoryLogic = new PlayerInventoryLogic();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInventoryLogic.playerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Menus

    public void OpenInventoryMenus()
    {
        menuStates[0].menuObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void CloseInventoryMenus()
    {
        //Hide all menus
        HideAllMenus();

        //Signal the player they are no longer in the menus
        playerInventoryLogic.CloseInventoryMenus();
    }

    public void HideAllMenus()
    {
        //Loop through all states and disable them all
        for (int state = 0; state < menuStates.Length; state++)
        {
            menuStates[state].menuObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void SwapMenu(string menuToShow)
    {
        //Hide all Menus
        HideAllMenus();

        //Loop through the states and enable to specified one
        for (int state = 0; state < menuStates.Length; state++)
        {
            if (menuToShow == menuStates[state].name) menuStates[state].menuObject.transform.localScale = new Vector3(1, 1, 1);

            else continue;
        }

        MenuSwapFunctions(menuToShow);
    }

    private void MenuSwapFunctions(string newMenu)
    {
        switch (newMenu)
        {
            case "InventoryMenu":
                playerInventoryLogic.inventoryIndex = 0;
                playerInventoryLogic.UpdateSoundInventory();
            break;
        }
    }

    #endregion Menus

    #region Inventory Functions

    public void ScroleList(bool scrollUp)
    {
        playerInventoryLogic.ScrollList(scrollUp);
    }

    //Open the audio setter menu
    public void OpenAudioSetter(int elementIndex)
    {
        if (MusicPlayer.Instance.bIsRunning) return; //No changes whilst this is playing

        playerInventoryLogic.OpenAssignMenu(elementIndex);
    }

    #endregion
}
