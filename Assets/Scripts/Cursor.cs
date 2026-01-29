using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cursor : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector3Int GetTargetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;            
            if (Physics.Raycast(ray, out hit))
            {                
                Vector3Int targetTile;
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                if (targetTile.x == 12)
                {
                    targetTile.x -= 1;
                    targetTile.y = 1;
                }
                //Debug.Log($"Target Tile: {targetTile}");
                return targetTile;
            }
            return Vector3Int.one;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = GetTargetTile();
        }
    }
}


