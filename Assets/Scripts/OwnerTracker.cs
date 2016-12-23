using UnityEngine;
using System.Collections;

public class OwnerTracker : MonoBehaviour {

    private GameObject ownerTracker;
    private Tile tile;

	void Start () {
        tile = gameObject.GetComponent<Tile>();
        ownerTracker = tile.getOwner();
    }
	
	// Update is called once per frame
	void Update () {
	    if(tile.getOwner() != ownerTracker)
        {
            tile.setTileColor();
            ownerTracker = tile.getOwner();
        }
	}
}
