using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    public MusicalInfluenceState musicalInfluenceState; //State that will effect the surroundings
    [SerializeField] private bool bInfluenceSurroundings; //Should this current effect surroundings?

    public bool bIsRunning; //Comparator for other systems to check

    [SerializeField] Collider selfCollider; //Collider of influence

    private void Awake()
    {
        Instance = this; //Set the instance
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selfCollider = GetComponent<Collider>();
    }
    //senpai was here uwu
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshCollider()
    {
        //Reset the collider via off and on
        selfCollider.enabled = false;

        selfCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bInfluenceSurroundings) return; //If no music is playing or an effect isn't in play

        InfluencedBase influencedObject = other.GetComponent<InfluencedBase>();

        if (influencedObject == null)
        {
            Debug.Log("Target is null");
            return; //Return if this is not on the object
        }

        influencedObject.SwitchInfluenceState(musicalInfluenceState);
    }

    //Function to change the ongoing state that the music player will influence to
    public void ChangeInfluenceState(MusicalInfluenceState inNewState)
    {
        musicalInfluenceState = inNewState; //Set the new state

        ToggleMusicPlayer(true); //Activate the music box
    }

    //Function to toggle the Music box on and off
    public void ToggleMusicPlayer(bool bIsActive)
    {
        bInfluenceSurroundings = bIsActive; //Change the states accordingly
        bIsRunning = bIsActive;
    }
}
