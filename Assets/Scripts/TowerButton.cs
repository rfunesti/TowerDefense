using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class TowerButton : MonoBehaviour
    {
        Button button;
        Player player;
        
        public GameObject towerPrefab;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            player = FindObjectOfType<Player>();
        }

        private void OnClick()
        {
            Debug.Log("I'm a button and I've been clicked!");
            player.towerPrefab = towerPrefab;
        }

    }

}