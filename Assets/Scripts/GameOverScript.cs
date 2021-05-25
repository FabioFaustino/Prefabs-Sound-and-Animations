using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score : " + score.ToString();
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartButtpn()
    {
        SceneManager.LoadScene("SampleScene");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
