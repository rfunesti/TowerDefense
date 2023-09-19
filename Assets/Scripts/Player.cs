using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        Player player;
        public GameObject towerPrefab;
        public int gold;

        Grid grid;
        Cursor cursor;
        UICursorCapture cursorCapture;

        private void Awake()
        {
            grid = FindObjectOfType<Grid>();
            cursorCapture = FindObjectOfType<UICursorCapture>();
            cursor = GetComponentInChildren<Cursor>();
        }

        private void OnClick()
        {
            Debug.Log("I'm a button and I've been clicked!");
            player.towerPrefab = towerPrefab;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !cursorCapture.cursorOverUI)
            {
                
                TryPlaceTower(grid, Grid.WorldToGrid(cursor.transform.position));
            }
        }

        public bool TryPlaceTower(Grid grid, Vector3Int tileCoordinates)
        {
            if (gold < Tower_SO.GetCost(towerPrefab))
            {
                return false;
            }
            if (grid.Occupied(tileCoordinates))
            {
                return false;
            }
            GameObject newTower = Instantiate(towerPrefab, tileCoordinates, Quaternion.identity);
            grid.Add(tileCoordinates, newTower);
            gold -= Tower_SO.GetCost(towerPrefab);
            ValueDisplay.OnValueChanged.Invoke("PlayerGold", gold);
            return true;
        }
    }
}

