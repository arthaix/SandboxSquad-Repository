using System.Collections;
using UnityEngine;

public class PressTheButton : MonoBehaviour
{

    [SerializeField] private GameObject buttonMain;
    private Vector3 basicPosition;
    private bool isPressedRN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PublicReccurectingEmergencySpringService()
    {
        if (!isPressedRN)
        {
            basicPosition = buttonMain.transform.position;
            MoveTheButton(false);
            isPressedRN = true;
        }
    }

    private IEnumerable MoveTheButton(bool up)
    {
        yield return new WaitForSeconds(0.1f);
        if (up)
        {
            buttonMain.transform.position += new Vector3(0, 0.1f, 0);
            if (buttonMain.transform.position.y < basicPosition.y)
            {
                MoveTheButton(true);
            }
            else
            {
                isPressedRN = false;
            }
        }
        else
        {
            buttonMain.transform.position += new Vector3(0, -0.1f, 0);
            if (buttonMain.transform.position.y < basicPosition.y - 0.5)
            {
                MoveTheButton(true);
            }
            else
            {
                MoveTheButton(false);
            }
        }
    }
}
