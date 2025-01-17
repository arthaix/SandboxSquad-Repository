using UnityEngine;

public class DoNotFall : MonoBehaviour
{

    [SerializeField, Tooltip("Put the point where you want the object to teleport back to here. Leave empty if you want it the same as starting position")] private Transform telepoint;
    private Vector3 telePointPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (telepoint == null)
        {
            telepoint = this.transform;
        }
        telePointPos = telepoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5)
        {
            TeleportTime();
        }
    }

    private void TeleportTime()
    {
        this.transform.position = telePointPos;
    }
}
