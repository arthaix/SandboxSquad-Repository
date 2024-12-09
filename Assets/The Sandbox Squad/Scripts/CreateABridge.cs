using System.Collections;
using System.Linq;
using UnityEngine;

public class CreateABridge : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject bridgeFragment;
    [SerializeField] private bool twitter = true;
    [SerializeField] private float bridgeCreationSpeed = 1;
    private GameObject brigdoo;
    private Vector3 postione = new Vector3(0, -5, 0);
    private bool orpOrzel = false;

    private void Start()
    {
        //startPoint = this.transform;
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
        string sideo = DetermineSide();
        if (twitter)
        {
            if (sideo.Any(c => c == 'N'))
            {
                CreateBridgeSegment('N');
                postione += new Vector3(TheSizeOfTheBridgeFragment.theSize, 0, 0);
            }
            else
            {
                CreateBridgeSegment('S');
                postione += new Vector3(-TheSizeOfTheBridgeFragment.theSize, 0, 0);
            }
        }
        else
        {
            //TODO: add create a bridgeEW
        }
    }


    public void CreateBridgeSegment(char dist, bool dontBuildNext = false)
    {
        GameObject segmento = Instantiate(bridgeFragment, startPoint);
        segmento.transform.position += postione;
        segmento.GetComponent<SpeedOfTheBridge>().initalaSpeed = 0.02f;
        segmento.GetComponent<SpeedOfTheBridge>().deacceleration = 0.005f / bridgeCreationSpeed;
        if (!dontBuildNext)
        {
            StartCoroutine(CreateNextBridgeFragment(dist));
        }
    }

    IEnumerator CreateNextBridgeFragment(char dist)
    {
        yield return new WaitForSeconds(0.5f);
        if (CheckDistance(dist))
        {
            CreateBridgeSegment(dist, true);
            string sideAgain = DetermineSide();
            orpOrzel = true;
            if (sideAgain.Any(c => c == 'E'))
            {
                //TODO: add create a bridgeEW
            }
        }
    }

    public string DetermineSide()
    {
        string side = "";
        if (startPoint.position.x > endPoint.position.x)
        {
            side += "S";
        }
        else
        {
            side += "N";
        }
        if (startPoint.position.z > endPoint.position.z)
        {
            side += "E";
        }
        else
        {
            side += "W";
        }
        return side;
    }

    public bool CheckDistance(char side)
    {
        switch(side)
        {
            case 'N':
                if ((startPoint.position + postione + new Vector3(TheSizeOfTheBridgeFragment.theSize, 0, 0)).x > endPoint.position.x)
                {
                    return true;
                }
                break;
            case 'S':
                if ((startPoint.position + postione + new Vector3(-TheSizeOfTheBridgeFragment.theSize, 0, 0)).x < endPoint.position.x)
                {
                    return true;
                }
                //TODO: add create a bridgeEW
                break;
            default:
                break;
        }
        return false;
    }
}
