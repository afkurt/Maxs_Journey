using UnityEngine;

public class EndDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        UIManager.Instance.ShowEnding();
    }
}
