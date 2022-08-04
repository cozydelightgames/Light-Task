using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {
    public static GameObject[] allLights;
    public GameObject light0;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
    public GameObject light9;

    private void Start() {
        allLights = new GameObject[] {light0, light1, light2, light3, light4, light5, light6, light7, light8, light9};
    }
    
}
