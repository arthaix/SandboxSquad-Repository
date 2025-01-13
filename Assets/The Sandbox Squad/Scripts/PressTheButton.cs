using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PressTheButton : MonoBehaviour
{
    public static string[] code = new string[3];
    [SerializeField] private GameObject bridgeCreator;
    [SerializeField] private GameObject player;
    [SerializeField] private string code_fragment = null;
    private Vector3 basicPosition;
    private bool isPressedRN = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basicPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PublicReccurectingEmergencySpringService()
    {
        Debug.Log("Yeah, I'm here");
        if (!isPressedRN)
        {
            StartCoroutine(MoveTheButton(false));
            isPressedRN = true;
        }
    }

    private IEnumerator MoveTheButton(bool up)
    {
        yield return new WaitForSeconds(0.05f);
        if (up)
        {
            this.transform.position += new Vector3(0, 0.005f, 0);
            if (this.transform.position.y <= basicPosition.y)
            {
                StartCoroutine(MoveTheButton(true));
            }
            else
            {
                isPressedRN = false;
                AdjustTheCode(code_fragment);
                isCodeCorrect();
            }
        }
        else
        {
            this.transform.position += new Vector3(0, -0.005f, 0);
            if (this.transform.position.y <= basicPosition.y - 0.03)
            {
                StartCoroutine(MoveTheButton(true));
            }
            else
            {
                StartCoroutine(MoveTheButton(false));
            }
        }
    }

    private void AdjustTheCode(string code_input)
    {
        code[0] = code[1];
        code[1] = code[2];
        code[2] = code_input;
    }

    private void isCodeCorrect()
    {
        bool itIsCorrect = true;
        if (code.Any(c => c == null) || code[0] != "Triangle" || code[1] != "Circle" || code[2] != "Square")
        {
            itIsCorrect = false;
        }

        if (itIsCorrect)
        {
            bridgeCreator.transform.position = player.transform.position;
        }
    }
}
