using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private struct inputMenu
    {
      public const string sceneName ="Level_1";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(inputMenu.sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
