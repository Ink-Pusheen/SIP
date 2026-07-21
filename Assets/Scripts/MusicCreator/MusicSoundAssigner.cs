using UnityEngine;

public class MusicSoundAssigner : MonoBehaviour
{
    public AudioCollectable audioToAssign; //Element AudioCollectable to assign to the specified music note sheet sound

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignSound(MusicSheetSound sheetToAssign)
    {
        //Add the new influence to the basic music analyzer
        BasicAudioAnalyzer.Instance.AddInfluence(audioToAssign.influenceStyle, audioToAssign);

        sheetToAssign.setAudioCollectable = audioToAssign; //Set the specified audio

        sheetToAssign.SetNoteActiveState(true); //Activate the notes

        gameObject.SetActive(false); //Hide this menu
    }

    public void CancelSelection()
    {
        gameObject.SetActive(false); //Hide this menu
    }
}
