using UnityEngine;
using UnityEngine.SceneManagement;


public class TimedReload : MonoBehaviour
{
    [SerializeField] float time = 2;
    public void Invoke()
    {
        Invoke("Reload", time);
    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}