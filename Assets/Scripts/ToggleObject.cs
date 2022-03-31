using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
