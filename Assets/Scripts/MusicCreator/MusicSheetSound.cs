using UnityEngine;

public class MusicSheetSound : MonoBehaviour
{
    public AudioCollectable setAudioCollectable; //What audio collectable is set to this sheet sound

    [SerializeField] MusicNote[] rowNotes; //Notes that are in the sheets row

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to loop through all notes to make them interactable or not
    public void SetNoteActiveState(bool isActive)
    {
        //Loop through the notes and set active or not based on the input boolean
        for (int note = 0; note < rowNotes.Length; note++)
        {
            rowNotes[note].ForceDeactivate(); //Remove the prior input

            rowNotes[note].SetInteractableState(isActive); //Set the active state
        }
    }

    //Function to clear the sound from the bar
    public void RemoveSound()
    {
        if (setAudioCollectable is null) return; //Don't enact if this is null

        if (MusicPlayer.Instance.bIsRunning) return; //No changes whilst this is running

        //Remove influence to the basic music analyzer
        BasicAudioAnalyzer.Instance.RemoveInfluence(setAudioCollectable.influenceStyle, setAudioCollectable);

        setAudioCollectable = null; //Null the sound

        SetNoteActiveState(false); //Deactivate all the notes
    }
}
