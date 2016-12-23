using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private GameController gc;

    public GameObject basicSpawn, basicAttack, deck;
    private string basicFire, cardFire;

    public float fireRate;
    private float nextFire;

    void Start()
    {
        //get GameController
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject == null) Debug.Log("GameController not found");
        gc = gameController.GetComponent<GameController>();

        initPlayerControls();

        nextFire = Time.time;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(basicFire) && Time.time >= nextFire)
        {
            Vector3 pos = basicSpawn.transform.position;
            Quaternion rot = basicSpawn.transform.rotation;
            GameObject basic = Instantiate(basicAttack, pos, rot) as GameObject;
            basic.GetComponent<AttackProperties>().setOwner(gameObject);
            nextFire = Time.time + fireRate;
        }
        else if (Input.GetButtonDown(cardFire))
        {
            
        }
	}

    void initPlayerControls()
    {
        int pNum = 0;
        if (gameObject == gc.player1) pNum = 1;
        else if (gameObject == gc.player2) pNum = 2;
        else Debug.Log("Attack: cant find player");

        basicFire = "p" + pNum.ToString() + "_basic";
        cardFire = "p" + pNum.ToString() + "_card";
    }
}
