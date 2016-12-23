using UnityEngine;
using System.Collections;

public class AttackProperties : MonoBehaviour {

    //properties
    private GameObject owner;
    public int damage;

    public void setOwner(GameObject player) { owner = player; }
    public GameObject getOwner() { return owner; }
    public void setDamage(int dmg) { damage = dmg; }

}
