using UnityEngine;

public enum MusicalInfluenceState { Forest, Cave, Snow}
public class InfluencedBase : MonoBehaviour
{
    public bool bCanBeInfluenced = true; //Can this piece be influenced? <Default True>

    private MusicalInfluenceState currentInfluenceState;

    public MusicalInfluenceState GetCurState() {  return currentInfluenceState; }

    public void SwitchInfluenceState(MusicalInfluenceState newInfluenceState, int indexForModel)
    {
        if (!bCanBeInfluenced) return; //Don't allow change if so

        switch (newInfluenceState)
        {
            case MusicalInfluenceState.Forest:
                //Anything forest
                OnForestInfluence(indexForModel);
                break;

            case MusicalInfluenceState.Cave:
                //Anything cave
                OnCaveInfluence(indexForModel);
                break;

            case MusicalInfluenceState.Snow:
                //Anything snow
                OnSnowInfluence(indexForModel);
                break;
        }
    }

    //Like the switch state but forced for chain reaction like implications for when things change
    public void ForceSwitchInfluenceState(MusicalInfluenceState newInfluenceState, int indexForModel)
    {
        switch (newInfluenceState)
        {
            case MusicalInfluenceState.Forest:
                //Anything forest
                OnForestInfluence(indexForModel);
                break;

            case MusicalInfluenceState.Cave:
                //Anything cave
                OnCaveInfluence(indexForModel);
                break;

            case MusicalInfluenceState.Snow:
                //Anything snow
                OnSnowInfluence(indexForModel);
                break;
        }
    }

    #region Overridable Influence Functions

    public virtual void OnForestInfluence(int modelIndex) {}

    public virtual void OnCaveInfluence(int modelIndex) {}

    public virtual void OnSnowInfluence(int modelIndex) {}

    #endregion Overridable Influence Functions
}
