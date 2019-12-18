using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpin : MonoBehaviour
{
    private float rotateY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateY += 0.5f;
        transform.eulerAngles = new Vector3(0, rotateY, 0);
    }
}
