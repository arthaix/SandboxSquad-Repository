using UnityEngine;

public class LightReactive : MonoBehaviour
{
    public int lightReactiveObjectID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void lightInteraction()
    {
        switch(lightReactiveObjectID)
        {
            case 1:
                SkinnedMeshRenderer ghostieMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
                ghostieMeshRenderer.SetBlendShapeWeight(0, Mathf.Lerp(ghostieMeshRenderer.GetBlendShapeWeight(0), 0, 0.4f * Time.deltaTime));
            break;

        }
    }
}
