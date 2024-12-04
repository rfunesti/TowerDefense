using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    
    [SerializeField] private string completedText = "GAME OVER!";
    [SerializeField] private Text completedDisplay;

    public UnityEvent OnGameOver = new UnityEvent();

    /*private void OnEnable()
    {
        completedDisplay.text = completedText;
    }*/

    public void CompleteObjective()
    {
        if (gameObject.activeSelf)
        {
            completedDisplay.text = "";
            completedDisplay.text = completedText;
            OnGameOver.Invoke();
        }

    }

}
