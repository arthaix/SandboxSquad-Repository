using UnityEngine;

public class Lighttoreact : MonoBehaviour
{
    bool lightActive;
    [SerializeField] GameObject lightObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Light Reactive")
        {
            if (lightActive)
            {
            LightReactive collidedReactor = other.GetComponent<LightReactive>();
            collidedReactor.lightInteraction();
            }
        }
    }
    void Start()
    {
        DeActivateLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLight()
    {
        lightObject.SetActive(true);
        lightActive = true;
    }
    public void DeActivateLight()
    {
        lightObject.SetActive(false);
        lightActive = false;
    }
}
