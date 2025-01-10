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

    public InputActionReference triggerInput;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.resource = scanningAudio;

    }

    private void Update()
    {
        float trigger = triggerInput.action.ReadValue<float>();
        if (trigger > 0)
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
        else
        {
            if (audio.resource == scanningAudio)
            {
                audio.Stop();
            }
            scanningSentence = false;
            sentenceScanLevel = 0;
            scanChecker();
        }
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "ReadingPoint" && scanningSentence)
        {
            string readingPointName = "Reading point " + (sentenceScanLevel + 1);
            if (other.name == readingPointName)
            {
                sentenceScanLevel += 1;
                print("Scan " + sentenceScanLevel);
            }
            /*
            else
            {
                print("Scan failed");
                sentenceScanLevel = 0;
            }
            */
        }
        scanChecker();
    }

    void scanChecker()
    {
        
        if (sentenceScanLevel == 5)
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
        }
        else
        {
            scannerLight.SetActive(true);
            audio.resource = scanningAudio;
            audio.loop = true;
            audio.Play();
        }
    }
}
