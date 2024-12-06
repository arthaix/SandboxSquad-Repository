using UnityEngine;

public class TheSizeOfTheBridgeFragment : MonoBehaviour
{
    [SerializeField] private GameObject bridgeFragment;
    public static float theSize;

    private void Start()
    {
        BoxCollider boxCollider = bridgeFragment.GetComponent<BoxCollider>();

        Vector3 localSize = boxCollider.size;

        Vector3 worldScale = bridgeFragment.transform.lossyScale;

        Vector3 worldRight = bridgeFragment.transform.right * (localSize.x * worldScale.x); 
        Vector3 worldForward = bridgeFragment.transform.forward * (localSize.z * worldScale.z); 

        float xLength = worldRight.magnitude;
        float zLength = worldForward.magnitude;

        theSize = Mathf.Min(xLength, zLength);
    }
}
