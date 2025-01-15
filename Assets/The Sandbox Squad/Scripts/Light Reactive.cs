using UnityEngine;

public class LightReactive : MonoBehaviour
{
    [SerializeField] private int lightReactiveObjectID;
    [SerializeField] private GameObject cpen_reader;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject createBridge1;
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
        Debug.Log("WORKIN");
        switch (lightReactiveObjectID)
        {
            case 1:
                SkinnedMeshRenderer ghostieMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
                ghostieMeshRenderer.SetBlendShapeWeight(0, Mathf.Lerp(ghostieMeshRenderer.GetBlendShapeWeight(0), 0, 0.4f * Time.deltaTime));
                createBridge1.transform.position = player.transform.position;
                break;
            case 2:
                Debug.Log("WORKIN");
                cpen_reader.SetActive(true);
                chest.GetComponent<BoxCollider>().enabled = false;
                Animator animator = chest.GetComponent<Animator>();
                animator.SetBool("open", true);
                break;
        }
    }
}
