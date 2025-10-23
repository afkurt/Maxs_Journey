using UnityEngine;

public class Deadzone : InteractableBase
{
    public override void BeginInteraction()
    {
        _healthSystem.TakeDamage(3f);
    }

    public override void EndInteraction()
    {
    }

    
}
