using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject wall;

    public List<Vector3> createdTiles;

    public int tileAmount;
    public int tileSize;
    public float waitTime;

    public float chanceUp;
    public float chanceDown;
    public float chanceLeft;

	IEnumerator Start ()
    {
       // Random.seed = 10;
		for (int i = 0; i < tileAmount; i++)
        {
            int randomTile = Random.Range(0, tiles.Length);
            CreateTile(randomTile);
            float direction = Random.Range(0f, 1f);
            CallMoveGenerator(direction);
            yield return new WaitForSeconds(waitTime);
        }
	}

    void MoveGenerator(int direction)
    {
        switch(direction)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + tileSize);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - tileSize);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, transform.position.z);
                break;
        }
    }

    void CallMoveGenerator(float randomDirection)
    {
        if (randomDirection < chanceUp)
            MoveGenerator(0);
        else if (randomDirection < chanceDown)
            MoveGenerator(1);
        else if (randomDirection < chanceLeft)
            MoveGenerator(2);
        else
            MoveGenerator(3);
    }

    void CreateTile(int randomTile)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tile = Instantiate(tiles[randomTile], transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tile.transform.position);
        }
        else
            tileAmount++;
    }
}
