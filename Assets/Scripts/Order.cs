using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {
    public static GameObject obj;
    public static Order comp;

    public int minTime;
    public int maxTime;

    public static int type; // type of light fixture

    private void Start() {
        obj = this.gameObject;
        comp = this;

        StartCoroutine("NewOrder");
    }

    private void Update() {
        
    }

    public IEnumerator NewOrder() {
        // gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = null;
        // GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        type = Random.Range(0, LightFixture.totalUnlocked);
        GetComponent<SpriteRenderer>().sprite = Singleton.allLights[type].GetComponent<LightFixture>().off;
        // GetComponent<SpriteRenderer>().color = Singleton.allLights[type].GetComponent<SpriteRenderer>().color;
        // gameObject.SetActive(true);
    }
}
