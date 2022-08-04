using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restock : MonoBehaviour {
    public int amount;
    public int price;

    public LightFixture lf;

    public void BuyStock() {
        if (PlayerStats.comp.GetMoney() > price) {
            Debug.Log("bought");

            PlayerStats.comp.UpdateMoney(-price);
            lf.UpdateInfo(amount);
        } else {
            Debug.Log("not enough money");
        }
    }
}
