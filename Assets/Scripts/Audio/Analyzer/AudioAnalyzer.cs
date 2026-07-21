using Unity.Collections;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour
{
    public int SampleRate = 64; //Intervals at which the audio is defined

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Utilizing the clips position as well as the audio clip to determine the loudness of the clip
    public float ReturnAudioLoudness(int startPoint, AudioClip inAudioClip)
    {
        //int startPos = startPoint - SampleRate; //Determin the starting position of the audio being interpreted

        //if (startPos < 0) return 0; //A check if the clip isn't even started, returns 0

        //Created array with the size of the sample rate at which the audio will be determined
        float[] soundData = new float[SampleRate];

        //Create the array that the data will be written to
        var sampleCount = inAudioClip.samples * inAudioClip.channels; //Multiply the samples by channels of the audio clip to get the samples
        var samples = new NativeArray<float>(sampleCount, Allocator.Temp); //Create a temporary allocation for the number of samples

        //Grabs the data of the audio utilizing the created array for floats and the sample rate to decipher it
        inAudioClip.GetData(samples, 0);

        //Compute the loudness
        float totalLoudness = 0;

        //For loop that dates the array of data and determines the audio volume with a Mathf Absolute
        for (int point = 0; point < samples.Length; point++)
        {
            //Debug.Log(point + " " + samples[point]);
            totalLoudness += Mathf.Abs(samples[point]);
        }

        return totalLoudness / SampleRate; //Return the found total loudness divided by the sampe rate
    }
}
