using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public int hp;

    private GameController gc;

    void Start()
    {
        //get GameController
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject == null) Debug.Log("GameController not found");
        gc = gameController.GetComponent<GameController>();
    }

    void Update()
    {
        if(hp <= 0)
        {
            gc.gameOver(gameObject);
        }
    }

    public void addHealth(int health) { hp += health; }
    public void subHealth(int health) { hp -= health; }
}
