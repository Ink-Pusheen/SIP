using UnityEngine;

public class InfluencedModel : InfluencedBase
{
    //Temp material change
    [SerializeField] MeshRenderer modelRenderer;
    [SerializeField] Material[] materials;

    //Models to change between
    [SerializeField] GameObject monoChromeModel;
    [SerializeField] GameObject[] forestModels;
    [SerializeField] GameObject[] snowModels;
    [SerializeField] GameObject[] caveModels;
    

    private void Start()
    {
        //modelRenderer = GetComponent<MeshRenderer>();
    }

    //Hide all models
    void HideModels()
    {
        monoChromeModel.SetActive(false); //Disable the base monochrome house

        //Loop through the other variants
        for (int index = 0; index < 3; index++)
        {
            forestModels[index].SetActive(false); //Disable the forest model
            caveModels[index].SetActive(false); //Disable the cave model
            snowModels[index].SetActive(false); //Disable the snow model
        }
    }

    #region Overrides

    public override void OnForestInfluence(int modelIndex)
    {
        //Hide the models before showing the specified one
        HideModels();

        //base.OnForestInfluence();
        Debug.Log("Forest");
        forestModels[modelIndex].SetActive(true); //Display the specified model
    }

    public override void OnCaveInfluence(int modelIndex)
    {
        //Hide the models before showing the specified one
        HideModels();

        //base.OnCaveInfluence();
        Debug.Log("Cave");
        caveModels[modelIndex].SetActive(true); //Display the specified model
    }

    public override void OnSnowInfluence(int modelIndex)
    {
        //Hide the models before showing the specified one
        HideModels();

        //base.OnSnowInfluence();
        Debug.Log("Snow");
        snowModels[modelIndex].SetActive(true); //Display the specified model
    }

    #endregion Override
}
