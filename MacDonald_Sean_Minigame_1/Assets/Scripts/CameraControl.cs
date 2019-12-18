using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // set initial position of camera
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // follows the player around
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
