using TowerDefense;
using UnityEngine;
using UnityEngine.UI;

public class TowerCost : MonoBehaviour
{
    //public int cost = 0;
    public Text costDisplay;
    public Tower_SO tower_SO;

    // Start is called before the first frame update
    void Start()
    {         
        costDisplay.text = "Cost: " + tower_SO.cost.ToString();
    }
}
