using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Grid : MonoBehaviour
    {
        private Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

        public bool Occupied(Vector3Int tileCoordinates)
        {
            return gameObjects.ContainsKey(tileCoordinates);
        }

        public bool Add(Vector3Int tileCoordinates, GameObject gameObject)
        {
            if (gameObjects.ContainsKey(tileCoordinates))
            {
                return false;
            }
            gameObjects.Add(tileCoordinates, gameObject);
            return true;
        }
        //Remove() is not currently being used in this version of the project per Torben
        public void Remove(Vector3Int tileCoordinates)
        {
            if (!gameObjects.ContainsKey(tileCoordinates))
            {
                return;
            }
            Destroy(gameObjects[tileCoordinates]);

            //remove from Dictionary using Vector3Int key tileCoordinates
             gameObjects.Remove(tileCoordinates);
        }

        public static Vector3Int WorldToGrid(Vector3 worldPosition)
        {
            //Debug.Log($"World Position {worldPosition}");
            return new Vector3Int(
                Mathf.RoundToInt(worldPosition.x),
                Mathf.RoundToInt(worldPosition.y),
                Mathf.RoundToInt(worldPosition.z)
            );
        }
        
        public static Vector3 GridToWorld(Vector3Int gridPosition)
        {           
            //Debug.Log($"Grid Position {gridPosition}");
            return gridPosition;
        }
    }
}

