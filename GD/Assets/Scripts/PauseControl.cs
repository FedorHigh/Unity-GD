using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    private Image _image;
    public GameObject pauseMenu;

    void Start()
    {
        _image = GetComponent<Image>();
        pauseMenu.SetActive(false);
    }
    public void Toggle()
    {
        bool status = !_image.enabled;
        _image.enabled = status;
        pauseMenu.SetActive(status);
        Time.timeScale = status ? 0 : 1;
    }
}
