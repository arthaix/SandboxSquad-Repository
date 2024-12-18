using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class CreateABridge : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject bridgeFragment;
    [SerializeField] private bool twitter = true;
    [SerializeField] private float bridgeCreationSpeed = 1;
    private GameObject brigdoo;
    private Vector3 postione = new Vector3(0, -5, 0);
    private Quaternion rotatione = new Quaternion();
    private bool orpOrzel = false;

    private void Start()
    {
        //startPoint = this.transform;
        //postione += startPoint.position;
        if (twitter)
        {
            rotatione = Quaternion.Euler(0, 90, 0);
        }
        brigdoo = Instantiate(bridgeFragment, startPoint.transform.position, rotatione);
        brigdoo.transform.position -= new Vector3(0, 5, 0);
        brigdoo.GetComponent<SpeedOfTheBridge>().initalaSpeed = 0.05f;
        brigdoo.GetComponent<SpeedOfTheBridge>().deacceleration = 0.005f / bridgeCreationSpeed;
        brigdoo.GetComponent<SpeedOfTheBridge>().maxYPos = startPoint.position.y;
        brigdoo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        brigdoo.SetActive(true);
        string sideo = DetermineSide();
        Debug.Log(sideo);
        if (!twitter)
        {
            if (sideo.Any(c => c == 'N'))
            {
                CreateBridgeSegment('N');
            }
            else
            {
                CreateBridgeSegment('S');
            }
        }
        else
        {
            if (sideo.Any(c => c == 'E'))
            {
                CreateBridgeSegment('E');
            }
            else
            {
                CreateBridgeSegment('W');
            }
        }
        Destroy(this.GetComponent<Collider>());
    }

    public void CreateBridgeSegment(char dist, bool dontBuildNext = false)
    {
        if (!dontBuildNext)
        {
            AddPosition(dist);
        }
        GameObject segmento = Instantiate(bridgeFragment, startPoint.transform.position, rotatione);
        segmento.transform.position += postione;
        segmento.GetComponent<SpeedOfTheBridge>().initalaSpeed = 0.05f;
        segmento.GetComponent<SpeedOfTheBridge>().deacceleration = 0.005f / bridgeCreationSpeed;
        segmento.GetComponent<SpeedOfTheBridge>().maxYPos = startPoint.position.y;
        if (!dontBuildNext)
        {
            StartCoroutine(CreateNextBridgeFragment(dist));
        }
    }

    public void AddPosition(char sideo)
    {
        if (sideo == 'N')
        {
            postione += new Vector3(TheSizeOfTheBridgeFragment.theSize, 0, 0);
        }
        else if (sideo == 'S')
        {
            postione += new Vector3(-TheSizeOfTheBridgeFragment.theSize, 0, 0);
        }
        else if (sideo == 'E')
        {
            postione += new Vector3(0, 0, TheSizeOfTheBridgeFragment.theSize);
        }
        else
        {
            postione += new Vector3(0, 0, -TheSizeOfTheBridgeFragment.theSize);
        }
    }

    IEnumerator CreateNextBridgeFragment(char dist)
    {
        yield return new WaitForSeconds(0.8f);
        if (CheckDistance(dist))
        {
            CreateBridgeSegment(dist, true);
            string sideAgain = DetermineSide();
            if (orpOrzel == false)
            {
                orpOrzel = true;
                if (!twitter)
                {
                    rotatione = Quaternion.Euler(0, 90, 0);
                    if (sideAgain.Any(c => c == 'E'))
                    {
                        CreateBridgeSegment('E');
                    }
                    else
                    {
                        CreateBridgeSegment('W');
                    }
                }
                else
                {
                    rotatione = Quaternion.Euler(0, 0, 0);
                    if (sideAgain.Any(c => c == 'S'))
                    {
                        CreateBridgeSegment('S');
                    }
                    else
                    {
                        CreateBridgeSegment('N');
                    }
                }
            }
        }
        else
        {
            CreateBridgeSegment(dist);
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
            side += "W";
        }
        else
        {
            side += "E";
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
                break;
            case 'E':
                if ((startPoint.position + postione + new Vector3(-TheSizeOfTheBridgeFragment.theSize, 0, 0)).z > endPoint.position.z)
                {
                    return true;
                }
                break;
            case 'W':
                if((startPoint.position + postione + new Vector3(-TheSizeOfTheBridgeFragment.theSize, 0, 0)).z < endPoint.position.z)
                {
                    return true;
                }
                break;
            default:
                break;
        }
        return false;
    }
}
