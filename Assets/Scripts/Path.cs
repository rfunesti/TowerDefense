using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Vector3> points = new List<Vector3>();

        // Awake will collect the path points before the coroutine starts.
        void Awake()
        {
            CollectPoints();
        }

        // CollectPoints: collect points from child GameObjects
        // and occupy grid.
        private void CollectPoints()
        {
            points = new List<Vector3>(); // Empty out the list for safety's sake
            Grid grid = FindObjectOfType<Grid>();

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Vector3 point = child.transform.position;

                points.Add(point);
                grid.Add(Grid.WorldToGrid(point), child);
                child.SetActive(false); // make the white spheres invisible
            }
        }
        // TryGetPoint: Returns a bool. Gets the path point at given index if index is valid.
        // out keyword specifies that this parameter is passed by reference
        // where we can make changes to this variable inside this function 
        // which will affect whatever variable was passed in.
        public bool TryGetPoint(int index, out Vector3 point)
        {
            point = Vector3.zero; // gives a default value

            if (index < 0 || index >= points.Count)
            {
                return false;
            }

            point = points[index];
            return true;
        }
    }
}

