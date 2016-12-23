using UnityEngine;
using System.Collections;

public class FieldSpawn : MonoBehaviour
{

    public GameObject baseTile;//base tile object
    public GameObject[,] field;//2d array of tiles for battlefield

    private GameController gc;

    private Vector3 offset;

    void Start()
    {
        //get GameController
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject == null) Debug.Log("GameController not found");
        gc = gameController.GetComponent<GameController>();

        offset = gameObject.transform.position;
    }

    public void initField()
    {
        field = new GameObject[6, 3];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 pos = new Vector3(i, 0, j) + gameObject.transform.position;
                field[i, j] = Instantiate(baseTile, pos, Quaternion.identity) as GameObject;
                Tile tile = field[i, j].GetComponent<Tile>();

                if (i < 3) tile.setOwner(gc.player1);
                else tile.setOwner(gc.player2);

                field[i, j].transform.SetParent(gameObject.transform);
            }
        }
    }

    //public bool withinFieldBoundary(GameObject obj)
    //{
    //    Vector3 pos = obj.transform.position;
    //    return withinFieldBoundary(pos);
    //}
    //
    //public bool withinFieldBoundary(Vector3 pos)
    //{
    //    float x = pos.x;
    //    float z = pos.z;
    //
    //    if (x >= 0 && x < 6 && z >= 0 && z < 3) return true;
    //    else return false;
    //}

    //field-adjusted position from raw position
    public Vector3 getFieldPos(Vector3 realPos)
    {
        return realPos - offset;
    }

    public Vector3 getFieldPos(GameObject obj)
    {
        return getFieldPos(obj.transform.position);
    }

    //raw position from field-adjusted position
    public Vector3 getRealPos(Vector3 fieldPos)
    {
        return fieldPos + offset;
    }

    public Vector3 getRealPos(GameObject obj)
    {
        return getRealPos(obj.transform.position);
    }

    public Vector3 clampToField(Vector3 pos)
    {
        float clampx = Mathf.Clamp(pos.x, 0f + offset.x, 5f + offset.x);
        float clampz = Mathf.Clamp(pos.z, 0f + offset.z, 2f + offset.z);
        return new Vector3(clampx, pos.y, clampz);
    }

    public Vector3 clampToField(GameObject obj)
    {
        return clampToField(obj.transform.position);
    }

    public Tile getTile(Vector3 pos)
    {
        //makes sure pos is always legal
        Vector3 p = getFieldPos(clampToField(pos));

        return field[(int)p.x, (int)p.z].GetComponent<Tile>();
    }

    public Tile getTile(float xPos, float zPos)
    {
        //note: y value does not matter
        Vector3 pos = new Vector3(xPos, 0.0f, zPos);
        return getTile(pos);
    }
}