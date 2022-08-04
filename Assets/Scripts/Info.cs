using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    public GameObject info;

    void OnMouseExit() {
        info.SetActive(false);
    }
}