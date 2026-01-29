using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

// The Grid class in the TowerDefense namespace will manage and store data
// for all of the units or buildings currently occupying tiles.
// To implement this we will use a Dictionary to store this data.

namespace TowerDefense{
    public class Grid : MonoBehaviour
    {
        private Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

        public bool Occupied(Vector3Int tileCoordinates)
        {
            return gameObjects.ContainsKey(tileCoordinates);
        }
        // The Add() and Remove() methods allow us to add and remove GameObjects
        // in a controlled way so we don't accidentally try and add GameObjects
        // to tiles which are already occupied.

        public bool Add(Vector3Int tileCoordinates, GameObject gameObject)
        {
            // Add a gameObject to the grid, if tileCoordinates are not occupied
            // by another GameObject. Return true if gameObject was added successfuly.
            // Return false if not.

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
            // Destroy and remove a GameObject from the grid if one occupies tileCoordinates.

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
            // World position is in float values; grid cells are integer values since they 
            // are basically arrays or collections and we can look at grid cells as a part of 
            // an array index.
            // Convert worldPosition to grid coordinates by rounding
            // the x,y, and z values to integers. Return grid coordinate value.

            //Debug.Log($"World Position {worldPosition}");
            return new Vector3Int(
                Mathf.RoundToInt(worldPosition.x),
                Mathf.RoundToInt(worldPosition.y),
                Mathf.RoundToInt(worldPosition.z)
            );
        }
        
        public static Vector3 GridToWorld(Vector3Int gridPosition)
        {
            //Convert gridPosition to worldPosition and return the value.

            //Debug.Log($"Grid Position {gridPosition}");
            return gridPosition;
        }
    }
}

