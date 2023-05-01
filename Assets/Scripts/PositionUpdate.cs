using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour
{
    public GameObject Char;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(Char.transform.position.x, transform.position.y, Char.transform.position.z);
        transform.position = newPosition;
    }
}
