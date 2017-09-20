using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleLevelGeneration : MonoBehaviour
{
    public Room[] rooms;
    public int numOfRooms;
    public float waitTime;

    Room lastRoom;
    List<Vector3> occupiedPositions = new List<Vector3>();
    bool canSpawn;

    private IEnumerator Start()
    {
        for(int i = 0; i < numOfRooms; i++)
        {
            int randomRoom = Random.Range(0, rooms.Length);
            Room room = Instantiate(rooms[randomRoom]);

            if(lastRoom != null)
            {
                room.transform.position = lastRoom.transform.position;
                room.transform.rotation = lastRoom.transform.rotation;
            }

            for(int j = 0; j < room.tiles.Length; j++)
            {
                if (!occupiedPositions.Contains(room.tiles[j].transform.position))
                    canSpawn = true;
                else
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                lastRoom = room;

                for (int k = 0; k < lastRoom.tiles.Length; k++)
                {
                    if (!occupiedPositions.Contains(lastRoom.tiles[k].transform.position))
                        occupiedPositions.Add(lastRoom.tiles[k].transform.position);
                }
            }
            else
                numOfRooms++;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
