using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string name)
    {
        Block.BreakableCount = 0;
        SceneManager.LoadScene(name);
	}

    public void LoadNextLevel()
    {
        Block.BreakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BlockDestroed()
    {
        if(Block.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit();
	}

}
