using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestWeaponLoading : MonoBehaviour {
    // Use this for initialization
    void Start() {
        var weapon1 = DataManager.GetWeapon("longSword");
        Debug.Log("name: " + weapon1.name);
        Debug.Log("weight: " + weapon1.weight);
        Debug.Log("toHit: " + weapon1.toHit);
        var textBox = GetComponent<Text>();
        textBox.text = "Weapon Test:\n";
        textBox.text += "name: " + weapon1.name + "\n";
        textBox.text += "weight: " + weapon1.weight + "\n";
        textBox.text += "toHit: " + weapon1.toHit + "\n";
    }
}
