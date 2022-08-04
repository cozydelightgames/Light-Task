using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightFixture : MonoBehaviour {
    public int type;
    public int price;
    public int stock;
    public bool unlocked;
    public static int totalUnlocked;
    public bool mouseDown;

    public GameObject info;
    public Text priceText;
    public Text stockText;

    public Sprite on;
    public Sprite off;
    public Sprite hover;

    Ray ray;
    RaycastHit2D hit;

    private void Start() {
        if (!unlocked) gameObject.SetActive(false);
        totalUnlocked = 2;

        priceText.text = "Price: " + price;
        stockText.text = "Stock: " + stock;

        mouseDown = false;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null &&
                hit.collider.gameObject == this.gameObject) {
                // buy1.SetActive(true);
                // buy5.SetActive(true);
                // buy10.SetActive(true);
                info.SetActive(true);
            }
        }
        // if (Input.GetKeyDown(KeyCode.Backspace)) {
        //     // buy1.SetActive(false);
        //     // buy5.SetActive(false);
        //     // buy10.SetActive(false);
        //     info.SetActive(false);
        // }
    }

    private void OnMouseOver() {
        // if (!mouseDown) transform.localRotation = Quaternion.Euler(0, 0, 5);
        GetComponent<SpriteRenderer>().sprite = hover;
    }

    private void OnMouseExit() {
        // transform.localRotation = Quaternion.Euler(0, 0, 0);
        GetComponent<SpriteRenderer>().sprite = on;
    }

    private void OnMouseDown() {
        mouseDown = true;
        // transform.localRotation = Quaternion.Euler(0, 0, 20);

        // if (Order.obj.activeSelf && unlocked) {
        // if (Order.comp.GetComponent<SpriteRenderer>().color != Color.black && unlocked) {
        if (Order.comp.GetComponent<SpriteRenderer>().sprite != null && unlocked) {
            if (type == Order.type) {
                if (stock > 0) {
                    Debug.Log("sold");
                    UpdateInfo(-1);

                    PlayerStats.comp.UpdateMoney(price);
                    Order.comp.StartCoroutine("NewOrder");
                } else {
                    Debug.Log("no stock");
                }
            } else {
                Debug.Log("incorrect light");
            }
        }
    }

    private void OnMouseUp() {
        mouseDown = false;
    }

    public void UpdateInfo(int s) {
        stock += s;
        if (stock == 0) GetComponent<SpriteRenderer>().sprite = off;
        else GetComponent<SpriteRenderer>().sprite = on;
        stockText.text = "Stock: " + stock;
    }

    public void Unlock() {
        gameObject.SetActive(true);
        unlocked = true;
        totalUnlocked++;
        Debug.Log("total unlocked: " + totalUnlocked);
    }

    // private 
}
