using UnityEngine;
using UnityEngine.Events;


public class OnPlayerTrigger : MonoBehaviour
{
    public UnityEvent playerEnterEvent;
    public UnityEvent playerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerExitEvent.Invoke();
        }
    }
}
