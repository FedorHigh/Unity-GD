using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
    
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            _button.onClick.Invoke();
        }
    }
}
