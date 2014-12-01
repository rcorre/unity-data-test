using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestWeaponLoading : MonoBehaviour {
    // Use this for initialization
    void Start() {
        var weapon1 = DataManager.GetWeapon("longSword");
        var testRoll = weapon1.damage.Roll();
        Debug.Log("name: " + weapon1.name);
        Debug.Log("weight: " + weapon1.weight);
        Debug.Log("properties[0]: " + weapon1.properties[0]);
        Debug.Log("damage: " + weapon1.damage);
        Debug.Log("test roll: " + testRoll);
        var textBox = GetComponent<Text>();
        textBox.text = "Weapon Test:\n";
        textBox.text += "name: " + weapon1.name + "\n";
        textBox.text += "weight: " + weapon1.weight + "\n";
        textBox.text += "properties[0]: " + weapon1.properties[0] + "\n";
        textBox.text += "damage: " + weapon1.damage + "\n";
        textBox.text += "test roll: " + testRoll + "\n";
    }
}
