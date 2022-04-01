using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combineMesh : MonoBehaviour {

    void Start()
    {
        Transform[] objects = GetComponentsInChildren<Transform>();

        int i = 2;
		Vector3 offset = new Vector3(0, 0.01f, 0);
        while (i < objects.Length)
        {
            objects[i].position -= offset*i;
            i++;
        }
    }
}
