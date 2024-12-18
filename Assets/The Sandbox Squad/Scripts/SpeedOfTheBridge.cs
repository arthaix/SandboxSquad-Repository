using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class SpeedOfTheBridge : MonoBehaviour
{
    public float deacceleration;
    public float initalaSpeed;
    public float maxYPos;

    private void Update()
    {
        if (CheckRepublic())
        {
            this.transform.position += new Vector3(0, initalaSpeed, 0);
            initalaSpeed -= deacceleration;
            deacceleration -= 0.00005f;
            if (initalaSpeed < 0.02 && initalaSpeed != 0)
            {
                initalaSpeed = 0.02f;
            }
            if (deacceleration < 0f)
            {
                deacceleration = 0f;
            }
        }
    }

    public bool CheckRepublic()
    {
        if (this.transform.position.y >= maxYPos)
        {
            if (this.transform.position.y > maxYPos)
            {
                this.transform.position = new Vector3(this.transform.position.x, maxYPos, this.transform.position.z);
            }
            return false;
        }
        return true;
    }
}
