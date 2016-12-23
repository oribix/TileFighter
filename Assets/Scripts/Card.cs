using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    private string cardName, rulesText, flavorText;
    private GameObject owner;
    public GameObject ability;

    //shortcut variables
    private Vector3 position;
    private Quaternion rotation;

    void Start()
    {
        if (owner != null)
        {
            position = owner.transform.position;
            rotation = owner.transform.rotation;
        }
    }

    public void setOwner(GameObject player) { owner = player; }
    public GameObject getOwner() { return owner; }

    public void useAbility()
    {
        if (ability == null) return;
        GameObject a = Instantiate(ability, position, rotation) as GameObject;
        AttackProperties ap = a.GetComponent<AttackProperties>();
        if(ap != null) ap.setOwner(owner);
    }
}