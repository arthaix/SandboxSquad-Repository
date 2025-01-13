using UnityEngine;
using UnityEngine.InputSystem;

public class CPenReader : MonoBehaviour
{
    public AudioClip scanningAudio;
    public AudioClip scannedAudio;
    int sentenceScanLevel = 0;
    bool scanningSentence;
    public GameObject scannerLight;
    AudioSource audio;
    public Material scanTextMaterial;


    public InputActionReference triggerInput;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.resource = scanningAudio;
        scanTextMaterial.SetFloat("_Scanned_amount", 0f);
    }
    
    
    public void activateReading()
    {
        if (scanningSentence == false)
        {
            scannerLight.SetActive(true);
            audio.resource = scanningAudio;
            audio.loop = true;
            audio.Play();
        }
        scanningSentence = true;
    }

    public void deactivateReading()
    {
        if (audio.resource == scanningAudio)
        {
            audio.Stop();
        }
        scanningSentence = false;
        sentenceScanLevel = 0;
        scanChecker();
    }



    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "ReadingPoint" && scanningSentence)
        {
            string readingPointName = "Reading point " + (sentenceScanLevel + 1);
            if (other.name == readingPointName)
            {
                sentenceScanLevel += 1;
                print("Scan " + sentenceScanLevel);
                scanChecker();
            }
            /*       THIS FAILS THE SCAN IF YOU SCAN OUT OF ORDER
            else
            {
                print("Scan failed");
                sentenceScanLevel = 0;
            }
            */
        }
    }

    void scanChecker()
    {
        
        if (sentenceScanLevel == 6)
        {
            print("Sentence Scanned");
            audio.resource = scannedAudio;
            audio.loop = false;
            audio.Play();
            sentenceScanLevel = 0;
        }
        else if (sentenceScanLevel == 0)
        {
            scannerLight.SetActive(false);
            scanningSentence = false;
        }
        else
        {
            scannerLight.SetActive(true);
            audio.resource = scanningAudio;
            audio.loop = true;
            audio.Play();
        }
        scanTextMaterial.SetFloat("_Scanned_amount", 0.75f * sentenceScanLevel);
    }
}
