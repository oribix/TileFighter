using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private GameController gc; 

    public GameObject center, edge;
    //public GameObject[] brackets;
    private GameObject owner;

    void Start()
    {
        //get GameController
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController == null)
        {
            Debug.Log("GameController not found");
        }
        gc = gameController.GetComponent<GameController>();
        if (gc == null) Debug.Log("gc equal to null");

        setTileColor();
    }

    void Update()
    {
        setTileColor();
    }

    public GameObject getOwner() { return owner; }
    public void setOwner(GameObject player) { owner = player; }

    public void setTileColor()
    {
        //decide which Color to use
        Color color = Color.white;
        if (owner == gc.player1) color = Color.blue;
        else if (owner == gc.player2) color = Color.red;
        else Debug.Log("setTileColor: owner not equal to any player");

        //set the colors
        setColor(center, color, 65, 0);
        setColor(edge, color, 100, 125);
    }

    void setColor(GameObject obj, Color color, int dSat, int dVal)
    {
        //get desaturated color
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);
        s -= ((float)dSat / 255f);
        v -= ((float)dVal / 255f);
        Color newColor = Color.HSVToRGB(h, s, v);

        obj.GetComponent<Renderer>().material.color = newColor;
    }

}