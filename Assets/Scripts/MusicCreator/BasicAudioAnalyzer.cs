using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAudioAnalyzer : MonoBehaviour
{
    public static BasicAudioAnalyzer Instance;

    public List<string> audioInfluenceTypes = new(); //List of current effect sound effects

    public List<AudioCollectable> ActiveAudio = new(); //List of currently active audio interactables

    [SerializeField] string CurrentEquatedInfluence; //Based on the inputs, what would the game craft?

    [SerializeField] TMP_Text MusicPlayerStateText; //Display button to start or stop the music player

    [SerializeField] TMP_Text CurrentLoudnessText; //Display of the current loudness of the selected clips
    [SerializeField] TMP_Text InfluenceState; //What type of influence will the music player convey

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


        if (highest == forestInfluence && forestInfluence is not 0) possibleInfluences.Add("Forest"); //Add to the possibilities list

        if (highest == caveInfluence && caveInfluence is not 0) possibleInfluences.Add("Cave"); //Add to the possibilities list

        if (highest == snowInfluence && snowInfluence is not 0) possibleInfluences.Add("Snow"); //Add to the possibilities list


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

        int volumeLevel = ReturnAudioLoudnessLevel(); //Grab the current audio level

        //Switch case to determine the subset from the total loudness as long as it is not -1 and there is a current influence
        if(volumeLevel != -1 && CurrentEquatedInfluence != "")
        {
            switch (CurrentEquatedInfluence)
            {

                case "Forest": //If the chosen influence is Forest

                    if (volumeLevel is 0)  //Debug.Log("Whimsy Forest"); //Volume <= 10
                    {
                        InfluenceState.text = "[Whimsy Forest]";
                        MusicPlayer.Instance.modelIndex = 0;
                    }

                    else if (volumeLevel is 1)  //Debug.Log("Normal Forest"); //Volume > 10 & <= 40
                    {
                        InfluenceState.text = "[Normal Forest]";
                        MusicPlayer.Instance.modelIndex = 1;
                    }

                    else if (volumeLevel is 2)  //Debug.Log("Uneasy Forest"); //Volume > 40
                    {
                        InfluenceState.text = "[Uneasy Forest]";
                        MusicPlayer.Instance.modelIndex = 2;
                    }

                    break;

                case "Snow": //If the chosen influence is Snow

                    if (volumeLevel is 0)  //Debug.Log("Frozen Glacier"); //Volume <= 10
                    {
                        InfluenceState.text = "[Frozen Glacier]";
                        MusicPlayer.Instance.modelIndex = 0;
                    }

                    else if (volumeLevel is 1) //Debug.Log("Snowy Wonderland"); //Volume > 10 & <= 40
                    {
                        InfluenceState.text = "[Snowy Wonderland]";
                        MusicPlayer.Instance.modelIndex = 1;
                    }

                    else if (volumeLevel is 2)  //Debug.Log("Snowstorm"); //Volume > 40
                    {
                        InfluenceState.text = "[Snowstorm]";
                        MusicPlayer.Instance.modelIndex = 2;
                    }

                    break;

                case "Cave": //If the chosen influence is Cave

                    if (volumeLevel is 0)  //Debug.Log("Crystal Cavern"); //Volume <= 10
                    {
                        InfluenceState.text = "[Crystal Cavern]";
                        MusicPlayer.Instance.modelIndex = 0;
                    }

                    else if (volumeLevel is 1)  //Debug.Log("Common Cave"); //Volume > 10 & <= 40
                    {
                        InfluenceState.text = "[Common Cave]";
                        MusicPlayer.Instance.modelIndex = 1;
                    }

                    else if (volumeLevel is 2)  //Debug.Log("Trembling Tunnels"); //Volume > 40
                    {
                        InfluenceState.text = "[Trembling Tunnels]";
                        MusicPlayer.Instance.modelIndex = 2;
                    }

                    break;
            }
        }
        else
        {
            InfluenceState.text = "[No Identified Influence]";
        }

        CurrentLoudnessText.text = $"Current Volume: {totalLoudness.ToString("F2")}"; //Display the total loudness of the selected clips
    }

    //Function to return the audio level
    int ReturnAudioLoudnessLevel()
    {
        if (totalLoudness is 0) return -1;

        if (totalLoudness <= 10) return 0; //Return the quietest option

        else if (totalLoudness > 10 && totalLoudness <= 40) return 1; //Return the medium volume

        else return 2; //Else return the loudest state
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
