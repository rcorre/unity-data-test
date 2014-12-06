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
        text.text += "\nValue: " + weapon.value;
        text.text += "\nWeight: " + weapon.weight;
        text.text += "\nElement: " + weapon.element;
        text.text += "\nAttackType: " + weapon.attackType;
        text.text += "\nDamage: " + weapon.damage.ToString();
        text.text += "\nAccuracy: " + weapon.accuracy;
        text.text += "\nAC[melee]: " + weapon.armorClass[AttackType.Melee];
        text.text += "\nAC[ranged]: " + weapon.armorClass[AttackType.Ranged];
        text.text += "\nAC[magic]: " + weapon.armorClass[AttackType.Magic];
        text.text += "\nAC[magic]: " + weapon.armorClass[AttackType.Magic];

        text.text += "\nResist[Slash]: " + weapon.resistance[Element.Slash];
        text.text += "\nResist[Crush]: " + weapon.resistance[Element.Crush];
        text.text += "\nResist[Pierce]: " + weapon.resistance[Element.Pierce];
        text.text += "\nResist[Fire]: " + weapon.resistance[Element.Fire];
        text.text += "\nResist[Ice]: " + weapon.resistance[Element.Ice];
        text.text += "\nResist[Electric]: " + weapon.resistance[Element.Electric];
        text.text += "\nResist[Earth]: " + weapon.resistance[Element.Earth];
        text.text += "\nResist[Dark]: " + weapon.resistance[Element.Dark];
        text.text += "\nResist[Light]: " + weapon.resistance[Element.Light];
    }
}
