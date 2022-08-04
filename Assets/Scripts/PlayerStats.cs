using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    // public delegate void OnUnlock();
    // public static event OnUnlock Unlock;

    public static GameObject obj;
    public static PlayerStats comp;

    public GameObject moneyText;
    public float billTime;
    private float billTimer;

    public int bills;
    public int money;

    private void Start() {
        obj = this.gameObject;
        comp = this;

        // bills = 5;
        money = 100;
        moneyText.GetComponent<Text>().text = "$" + money;

        billTimer = 0;
    }

    private void Update() {
        if (billTimer < billTime) {
            billTimer += Time.deltaTime;
        } else {
            billTimer = 0;
            UpdateMoney(-bills);
        }
    }

    public int GetMoney() {
        return money;
    }

    public void UpdateMoney(int change) {
        money += change;
        moneyText.GetComponent<Text>().text = "$" + money;

        CheckUnlock();
    }

    public void CheckUnlock() {
        // if (LightFixture.totalUnlocked == type) Debug.Log("level" + type);
        // if (money > type*100) Debug.Log("money" + type);
        if (LightFixture.totalUnlocked == 9 && money > 900) 
            Singleton.allLights[9].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 8 && money > 900) 
            Singleton.allLights[8].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 7 && money > 900) 
            Singleton.allLights[7].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 6 && money > 900) 
            Singleton.allLights[6].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 5 && money > 900) 
            Singleton.allLights[5].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 4 && money > 900) 
            Singleton.allLights[4].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 3 && money > 900) 
            Singleton.allLights[3].GetComponent<LightFixture>().Unlock();
        else if (LightFixture.totalUnlocked == 2 && money > 150) 
            Singleton.allLights[2].GetComponent<LightFixture>().Unlock();
    }
}
