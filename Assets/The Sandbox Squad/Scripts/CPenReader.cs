using UnityEngine;

public class CPenReader : MonoBehaviour
{
    int sentenceScanLevel = 0;
    bool scanningSentence;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ReadingPoint")
        {
            string readingPointName = "Reading point " + (sentenceScanLevel + 1);
            if (other.name == readingPointName)
            {
                sentenceScanLevel += 1;
                print("Scan " + sentenceScanLevel);
            }

        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scanChecker();
    }

    void scanChecker()
    {
        if (sentenceScanLevel == 3)
        {
            print("sentence scanned");
            sentenceScanLevel = 0;
        }
    }
}
