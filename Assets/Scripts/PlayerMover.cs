using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    private GameController gc;
    private Rigidbody rb;
    public GameObject fieldSpawn;
    private FieldSpawn fs;

    //controller axis names
    private string horizontalAxis, verticalAxis;

    //status variables
    private bool rooted; //allow/disallow movement input
    private bool offSides; //allow/disallow movement offsides
    private bool hLegal, vLegal; //helps limit movement input

    void Start()
    {
        //get GameController
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject == null) Debug.Log("GameController not found");
        gc = gameController.GetComponent<GameController>();

        //shortcut variables because I am lazy
        rb = GetComponent<Rigidbody>();
        fs = fieldSpawn.GetComponent<FieldSpawn>();

        //flags
        hLegal = true;
        vLegal = true;

        //class properties
        offSides = false;
        rooted = false;

        initPlayerControls();
    }

    void Update ()
    {
        //get movement input
        float h = Input.GetAxisRaw(horizontalAxis);
        float v = Input.GetAxisRaw(verticalAxis);

        float roundh = Mathf.Round(h);
        float roundv = Mathf.Round(v);

        //handle the movement flags
        if (roundh == 0.0f) hLegal = true;
        if (roundv == 0.0f) vLegal = true;

        //handle the movement
        if (!rooted && !(roundv == 0.0f && roundh == 0.0f))
        {
            Vector3 newPos = rb.position;

            //allows only nondiagonal movement
            if (Mathf.Abs(v) >= Mathf.Abs(h)) //vertical quadrants
            {
                if (vLegal)
                {
                    newPos += new Vector3(0f, 0f, roundv);
                    vLegal = false;
                }
            }
            else//horizontal quadrants
            {
                if (hLegal)
                {
                    newPos += new Vector3(roundh, 0f, 0f);
                    hLegal = false;
                }
            }

            //checks if the new position is on a legal tile
            if (fs.getTile(newPos).getOwner() == gameObject || offSides)
            {
                rb.position = fs.clampToField(newPos);
            }
        }
    }

    //initializes the player's controls
    void initPlayerControls()
    {
        ////show joystick names
        //string[] joyStickNames = Input.GetJoystickNames();
        ////int len = joyStickNames.Length;
        //Debug.Log("joystick names: ");
        //int i = 0;
        //foreach(string name in joyStickNames)
        //{
        //    Debug.Log(i.ToString() + ": " + name);
        //    i++;
        //}

        int pNum = 0;
        if (gc.player1 == gameObject) pNum = 1;
        else if (gc.player2 == gameObject) pNum = 2;
        else Debug.Log("initPLayerControls: cannot find player");

        //assign axes
        horizontalAxis = "p" + pNum + "_horizontal";
        verticalAxis = "p" + pNum + "_vertical";

        ////xbox controller support
        //if (pNum > 0 && len >= pNum && joyStickNames[pNum - 1].Contains("Xbox 360"))
        //{
        //    xboxAxisFix = -1;
        //}
        //else xboxAxisFix = 1;
    }

    public void root() { rooted = true; }
    public void unroot() { rooted = false; }
    public void enableOffSides() { offSides = true; }
    public void disableOffSides() { offSides = false; }
}