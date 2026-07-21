using UnityEngine;

public enum MusicalInfluenceState { Forest, Cave, Snow}
public class InfluencedBase : MonoBehaviour
{
    public bool bCanBeInfluenced = true; //Can this piece be influenced? <Default True>

    private MusicalInfluenceState currentInfluenceState;

    public MusicalInfluenceState GetCurState() {  return currentInfluenceState; }

    public void SwitchInfluenceState(MusicalInfluenceState newInfluenceState)
    {
        if (!bCanBeInfluenced) return; //Don't allow change if so

        switch (newInfluenceState)
        {
            case MusicalInfluenceState.Forest:
                //Anything forest
                OnForestInfluence();
                break;

            case MusicalInfluenceState.Cave:
                //Anything cave
                OnCaveInfluence();
                break;

            case MusicalInfluenceState.Snow:
                //Anything snow
                OnSnowInfluence();
                break;
        }
    }

    //Like the switch state but forced for chain reaction like implications for when things change
    public void ForceSwitchInfluenceState(MusicalInfluenceState newInfluenceState)
    {
        switch (newInfluenceState)
        {
            case MusicalInfluenceState.Forest:
                //Anything forest
                OnForestInfluence();
                break;

            case MusicalInfluenceState.Cave:
                //Anything cave
                OnCaveInfluence();
                break;

            case MusicalInfluenceState.Snow:
                //Anything snow
                OnSnowInfluence();
                break;
        }
    }

    #region Overridable Influence Functions

    public virtual void OnForestInfluence() {}

    public virtual void OnCaveInfluence() {}

    public virtual void OnSnowInfluence() {}

    #endregion Overridable Influence Functions
}
