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
            else
            {
                print("Scanfailed");
                sentenceScanLevel = 0;
            }
        }
        scanChecker();
    }

    void scanChecker()
    {
        if (sentenceScanLevel == 5)
        {
            print("sentence scanned");
            sentenceScanLevel = 0;
        }
    }
}
