using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    //Canvas Image: Follow mouse if Item selected
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
