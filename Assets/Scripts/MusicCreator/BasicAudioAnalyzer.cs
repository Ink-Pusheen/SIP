using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicAudioAnalyzer : MonoBehaviour
{
    public static BasicAudioAnalyzer Instance;

    public List<string> audioInfluenceTypes = new(); //List of current effect sound effects

    public List<AudioCollectable> ActiveAudio = new(); //List of currently active audio interactables

    [SerializeField] string CurrentEquatedInfluence; //Based on the inputs, what would the game craft?

    [SerializeField] TMP_Text MusicPlayerStateText; //Display button to start or stop the music player

    AudioSource audSource; //Audio source
    AudioAnalyzer audAnalyzer; //Create a new audio analyzer
    [SerializeField] float totalLoudness; //Float of the total volume of all sound clips

    private void Awake()
    {
        Instance = this; //Set the instance

        audSource = GetComponent<AudioSource>(); //Grab the audio source
        audAnalyzer = GetComponent<AudioAnalyzer>(); //Grab the audio analyzer
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to add a new influence to the list and analyze
    public void AddInfluence(string inNewInfluence, AudioCollectable inNewAudioCollectable)
    {
        if (ActiveAudio.Contains(inNewAudioCollectable))
        {
            Debug.Log("Audio already in console");
            return;
        }

        audioInfluenceTypes.Add(inNewInfluence); //Add to the list(s)
        ActiveAudio.Add(inNewAudioCollectable);

        //Analyze
        AnalyzeNumericals();
    }

    //Function to remove an influence and reanalayze
    public void RemoveInfluence(string inInfluenceToRemove, AudioCollectable inAudioCollectableToRemove)
    {
        audioInfluenceTypes.Remove(inInfluenceToRemove); //Remove the first instance of this

        ActiveAudio.Remove(inAudioCollectableToRemove); //Remove the first instance of this

        //Analyze
        AnalyzeNumericals();
    }

    public void AnalyzeNumericals()
    {
        //Analyze the audio loudness after resetting it

        totalLoudness = 0;

        //Loop through all the active audio clips and analyze the volume
        for (int source = 0; source < ActiveAudio.Count; source++)
        {
            if (ActiveAudio[source].audioClip is null) continue;

            audSource.clip = ActiveAudio[source].audioClip; //Set the audio clip before analyzing
            //Debug.Log(audSource + " " + audSource.clip + " " + ActiveAudio[source].audioClip); //This will lag the console like holy god 30k something loops

            float clipSoundVolume = audAnalyzer.ReturnAudioLoudness(audSource.timeSamples, ActiveAudio[source].audioClip); //Analyze the sound clip

            totalLoudness += clipSoundVolume; //Add the found volume
        }
        return; //Temp

        //Analyze the type

        int forestInfluence = 0;
        int caveInfluence = 0;
        int snowInfluence = 0;

        for (int influenceIndex = 0; influenceIndex < audioInfluenceTypes.Count; influenceIndex++)
        {
            if (audioInfluenceTypes[influenceIndex] is "Forest") forestInfluence++;

            else if (audioInfluenceTypes[influenceIndex] is "Cave") caveInfluence++;

            else if (audioInfluenceTypes[influenceIndex] is "Snow") snowInfluence++;
        }

        int highest = Mathf.Max(forestInfluence, caveInfluence, snowInfluence); //Compare

        List<string> possibleInfluences = new(); //List in the case there was more than a singular match

        if (highest == forestInfluence && forestInfluence is not 0)
        {
            possibleInfluences.Add("Forest"); //Add to the possibilities list
            Debug.Log("Enact Forest");
        }

        if (highest == caveInfluence && caveInfluence is not 0)
        {
            possibleInfluences.Add("Cave"); //Add to the possibilities list
            Debug.Log("Enact Cave");
        }

        if (highest == snowInfluence && snowInfluence is not 0)
        {
            possibleInfluences.Add("Snow"); //Add to the possibilities list
            Debug.Log("Enact Snow");
        }

        if (possibleInfluences.Count is 0) //No Match
        {
            Debug.Log("No matches");
            CurrentEquatedInfluence = ""; //Reset the input
        }
        else if (possibleInfluences.Count is 1) //Only one match
        {
            Debug.Log("Single Match");
            CurrentEquatedInfluence = possibleInfluences[0]; //Set the only possibility
        }
        else //Multiple matches
        {
            Debug.Log("Multiple Matches");
            string randomMix = possibleInfluences[Random.Range(0, possibleInfluences.Count)]; //Select a random possibility

            CurrentEquatedInfluence = randomMix; //Set the randomly chosen possibility
        }
    }

    //Function to check if the music box is currently playing or not
    public void CheckMusicPlayerState()
    {
        bool isPlaying = MusicPlayer.Instance.bIsRunning;

        if (isPlaying) //Stop the audio player
        {
            MusicPlayer.Instance.ToggleMusicPlayer(false); //Disable the music player
            MusicPlayerStateText.text = "Play Music";
        }
        else
        {
            InitiateAudio(); //Check for what audio can be played
        }
    }

    //Function to initialize the music if there is currently a matching theming
    public void InitiateAudio()
    {
        if (CurrentEquatedInfluence is "")  //Do nothing as this isn't applicable
        {
            Debug.Log("No influence track to play");
            return;
        }


        if (CurrentEquatedInfluence is "Forest") //Case the current analysis is Forest
        {
            MusicPlayer.Instance.ChangeInfluenceState(MusicalInfluenceState.Forest); //Change to forest influence
        }
        else if (CurrentEquatedInfluence is "Cave") //Case the current analysis is Cave
        {
            MusicPlayer.Instance.ChangeInfluenceState(MusicalInfluenceState.Cave); //Change to cave influence
        }
        else if (CurrentEquatedInfluence is "Snow") //Case the current analysis is Snow
        {
            MusicPlayer.Instance.ChangeInfluenceState(MusicalInfluenceState.Snow); //Change to snow influence
        }

        MusicPlayerStateText.text = "Stop Music";
    }
}
