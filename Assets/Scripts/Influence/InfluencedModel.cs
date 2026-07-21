using UnityEngine;

public class InfluencedModel : InfluencedBase
{
    //Temp material change
    [SerializeField] MeshRenderer modelRenderer;
    [SerializeField] Material[] materials;

    private void Start()
    {
        modelRenderer = GetComponent<MeshRenderer>();
    }

    #region Overrides

    public override void OnForestInfluence()
    {
        base.OnForestInfluence();
        Debug.Log("Forest");
        modelRenderer.material = materials[0];
    }

    public override void OnCaveInfluence()
    {
        base.OnCaveInfluence();
        Debug.Log("Cave");
        modelRenderer.material = materials[1];
    }

    public override void OnSnowInfluence()
    {
        base.OnSnowInfluence();
        Debug.Log("Snow");
        modelRenderer.material = materials[2];
    }

    #endregion Override
}
