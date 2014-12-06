using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowWeapon : MonoBehaviour {
    public ChooseMaterial materialSelector;
    public ChooseWeapon weaponSelector;

    // Update is called once per frame
    void Update() {
        var model = weaponSelector.selection;
        var mat = materialSelector.selection;

        var weapon = new Weapon(model, mat);

        var text = GetComponent<Text>();
        text.text = "Name: " + weapon.ToString();
    }
}
