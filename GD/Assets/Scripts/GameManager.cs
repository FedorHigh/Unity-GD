using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Reload()
    {
        Load(SceneManager.GetActiveScene().name);
    }
}
