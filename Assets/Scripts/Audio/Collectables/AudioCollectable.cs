using UnityEngine;

[CreateAssetMenu(fileName = "AudioCollectable", menuName ="AudioCollectable")]
public class AudioCollectable : ScriptableObject
{
    public string soundName;

    public AudioClip audioClip;

    public string influenceStyle; //What type of style this should effect
    public int influenceStrength; //Strength of this influence
}
