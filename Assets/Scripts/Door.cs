using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
            return;
        UIManager.Instance.ShowLevelComplate();
        
    }
    private void OnEnable()
    {
        
    }


}
