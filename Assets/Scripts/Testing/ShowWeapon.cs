using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowWeapon : MonoBehaviour {
    const string fmt = "{0,-10} : {1}\n";
    public ChooseMaterial materialSelector;
    public ChooseWeapon weaponSelector;

    // Update is called once per frame
    void Update() {
        var model = weaponSelector.selection;
        var mat = materialSelector.selection;

        var weapon = new Weapon(model, mat);

        var text = GetComponent<Text>();
        text.text = weapon.ToString() + "\n";
        text.text += string.Format(fmt, "Value", weapon.value);
        text.text += string.Format(fmt, "Weight", weapon.weight);
        text.text += string.Format(fmt, "Element", weapon.element);
        text.text += string.Format(fmt, "AttackType", weapon.attackType);
        text.text += string.Format(fmt, "Damage", weapon.damage.ToString());
        text.text += string.Format(fmt, "Accuracy", weapon.accuracy);
        text.text += "\n-------Armor Class--------\n";
        text.text += string.Format(fmt, "melee", weapon.armorClass[AttackType.Melee]);
        text.text += string.Format(fmt, "ranged", weapon.armorClass[AttackType.Ranged]);
        text.text += string.Format(fmt, "magic", weapon.armorClass[AttackType.Magic]);
        text.text += "\n-------Resistance--------\n";
        text.text += string.Format(fmt, "Slash", weapon.resistance[Element.Slash]);
        text.text += string.Format(fmt, "Crush", weapon.resistance[Element.Crush]);
        text.text += string.Format(fmt, "Pierce", weapon.resistance[Element.Pierce]);
        text.text += string.Format(fmt, "Fire", weapon.resistance[Element.Fire]);
        text.text += string.Format(fmt, "Ice", weapon.resistance[Element.Ice]);
        text.text += string.Format(fmt, "Electric", weapon.resistance[Element.Electric]);
        text.text += string.Format(fmt, "Earth", weapon.resistance[Element.Earth]);
        text.text += string.Format(fmt, "Dark", weapon.resistance[Element.Dark]);
        text.text += string.Format(fmt, "Light", weapon.resistance[Element.Light]);
    }
}
