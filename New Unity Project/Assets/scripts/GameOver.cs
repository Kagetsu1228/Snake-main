
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text pointsText;
    public void Setup(int highscore)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        pointsText.text = highscore.ToString() + " points";
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
