using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class CreateABridge : MonoBehaviour
{
    private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject bridgeFragment;
    [SerializeField] private bool twitter = true;
    [SerializeField] private float bridgeCreationSpeed;
    private GameObject brigdoo;
    private Vector3 postione = new Vector3(0, -5, 0);

    private void Start()
    {
        startPoint = this.transform;
        postione = startPoint.position;
        brigdoo = Instantiate(bridgeFragment, startPoint);
        brigdoo.transform.position -= new Vector3(0, 5, 0);
        brigdoo.GetComponent<SpeedOfTheBridge>().initalaSpeed = 0.02f;
        brigdoo.GetComponent<SpeedOfTheBridge>().deacceleration = 0.005f / bridgeCreationSpeed;
        if (twitter)
        {
            brigdoo.transform.Rotate(0, 90, 0);
        }
        brigdoo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        brigdoo.SetActive(true);
        CreateBridgeSegment(brigdoo);
        if (twitter)
        {
            postione += new Vector3(TheSizeOfTheBridgeFragment.theSize*DetermineSide(twitter), 0, 0);
        }
        else
        {
            postione += new Vector3(0, 0, TheSizeOfTheBridgeFragment.theSize * DetermineSide(twitter));
        }
    }


    public void CreateBridgeSegment(GameObject praviousBridgeFragment)
    {
        GameObject segmento = Instantiate(bridgeFragment, startPoint);
        segmento.transform.position += postione;
        segmento.GetComponent<SpeedOfTheBridge>().initalaSpeed = 0.02f;
        segmento.GetComponent<SpeedOfTheBridge>().deacceleration = 0.005f / bridgeCreationSpeed;
        if (twitter)
        {
            postione += new Vector3(TheSizeOfTheBridgeFragment.theSize * DetermineSide(twitter), 0, 0);
            if (postione.x >= endPoint.transform.position.x)
            {

            }
        }
        else
        {
            postione += new Vector3(0, 0, TheSizeOfTheBridgeFragment.theSize * DetermineSide(twitter));
        }
    }

    public int DetermineSide(bool xaxis)
    {
        if (xaxis)
        {
            if (startPoint.position.x > endPoint.position.x)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            if (startPoint.position.z > endPoint.position.z)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
