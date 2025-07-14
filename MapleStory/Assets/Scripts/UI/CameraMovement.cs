using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    public float offsetY = 1f;
    public float offsetZ = -10f;
    public float smooth = 5f;

    Vector3 target;

    void LateUpdate()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
    }
}
