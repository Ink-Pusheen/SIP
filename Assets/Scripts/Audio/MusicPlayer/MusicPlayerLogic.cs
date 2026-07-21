using System.Collections.Generic;
using UnityEngine;

public class StyleInfluence
{
    public string influenceType; //Type of influence
    public int influenceStrength; //Strength of this influence
}

public class MusicPlayerLogic : MonoBehaviour
{
    [Header("Influence Variables")]

    [SerializeField] List<StyleInfluence> influenceList = new List<StyleInfluence>();

    public int forestInluence;
    public int caveInfluence;
    public int snowInfluence;

    private void resetInfluence()
    {
        foreach (StyleInfluence influence in influenceList)
        {
            influence.influenceStrength = 0;
        }
    }

    public void AddInfluence(AudioCollectable inSound)
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
