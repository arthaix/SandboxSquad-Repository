using UnityEngine;

public class CreateABridge : MonoBehaviour
{
    [SerializeField] private Transform islandYouWant;
    [SerializeField] private float bridgeBuildSpeed;
    [SerializeField] private GameObject bridgeFragment;
    [SerializeField] private bool speedIncreases;
    private float positioney;

    Vector3 currentBridgePosition;

    private void Start()
    {
        currentBridgePosition = transform.position;
        positioney = transform.position.y;
        currentBridgePosition.y -= 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        CreateBridgeFragment();
    }

    private void CreateBridgeFragment()
    {
        GameObject newBridgeFragment = Instantiate(bridgeFragment);
        newBridgeFragment.transform.position = currentBridgePosition;

    }
}
