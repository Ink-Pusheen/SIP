using UnityEngine;

public class InfluencedChainReaction : InfluencedBase
{
    [SerializeField] InfluencedBase[] itemsToInfluence;

    [SerializeField] SpriteRenderer spriteRenderer; //2d visualization changes
    [SerializeField] Sprite[] sprites;

    [SerializeField] MeshRenderer modelRenderer;
    [SerializeField] Material[] materials;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Overrides

    public override void OnForestInfluence(int changeIndex)
    {
        Debug.Log("Forest");

        Invoke("ForceForestState", 2); //Delay before forcing the forest state
    }

    //Function for the delayed forest effect
    void ForceForestState()
    {
        foreach (InfluencedBase item in itemsToInfluence)
        {
            item.ForceSwitchInfluenceState(MusicalInfluenceState.Forest, MusicPlayer.Instance.modelIndex);
        }
    }

    public override void OnCaveInfluence(int changeIndex)
    {
        Debug.Log("Cave");

        Invoke("ForceCaveState", 2); //Delay before forcing the cave state
    }

    //Function for the delayed cave effect
    void ForceCaveState()
    {
        foreach (InfluencedBase item in itemsToInfluence)
        {
            item.ForceSwitchInfluenceState(MusicalInfluenceState.Cave, MusicPlayer.Instance.modelIndex);
        }
    }

    public override void OnSnowInfluence(int changeIndex)
    {
        Debug.Log("Snow");

        Invoke("ForceSnowState", 2); //Delay before forcing the snow state
    }

    //Function for the delayed snow effect
    void ForceSnowState()
    {
        foreach (InfluencedBase item in itemsToInfluence)
        {
            item.ForceSwitchInfluenceState(MusicalInfluenceState.Snow, MusicPlayer.Instance.modelIndex);
        }
    }

    #endregion Override
}
