using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Logic")]

    [SerializeField] Rigidbody rb;
    public PlayerLogic playerLogic;

    [SerializeField] PlayerInput playerInput;
    private InputAction horizontal;
    private InputAction vertical;
    private InputAction interact;
    private InputAction inventory;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerLogic = new PlayerLogic(rb);

        playerInput = GetComponent<PlayerInput>();

        //Setup Input Actions
        horizontal = playerInput.actions.FindAction("Horizontal");
        vertical = playerInput.actions.FindAction("Vertical");
        interact = playerInput.actions.FindAction("Interact");
        inventory = playerInput.actions.FindAction("Inventory");

        //Setup Logic Cores
        playerLogic.inventory = GetComponent<PlayerInventory>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLogic.inInventory) return;

        if (horizontal.IsPressed() || vertical.IsPressed())
        {
            playerLogic.MoveCharacter(horizontal.ReadValue<float>(), vertical.ReadValue<float>());
        }

        if (interact.WasPressedThisFrame())
        {
            playerLogic.Interact();
        }

        if (inventory.WasPressedThisFrame())
        {
            playerLogic.OpenInventoryMenus();
        }
    }
}
