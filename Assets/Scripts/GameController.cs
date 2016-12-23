using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private FieldSpawn fs;
    public GameObject fieldSpawn;

    public GameObject player1, player2;

    void Start () {
        //field
        fs = fieldSpawn.GetComponent<FieldSpawn>();
        fs.initField();
	}

    public void gameOver(GameObject player)
    {
        return;
    }
}