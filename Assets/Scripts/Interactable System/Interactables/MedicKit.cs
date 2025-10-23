using UnityEngine;

public class MedicKit : InteractableBase
{
    public override void BeginInteraction()
    {
        Destroy(gameObject);
        _healthSystem.Heal(10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        _healthSystem = collision.gameObject.GetComponentInParent<HealthSystem>();
        BeginInteractionCallback?.Invoke();

    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    public override void EndInteraction() { }
    

    
}
