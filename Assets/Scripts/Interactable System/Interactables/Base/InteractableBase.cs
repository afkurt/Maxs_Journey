using System;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public Action BeginInteractionCallback;
    public Action EndInteractCallback;

    public Rigidbody2D _playerRB;
    public HealthSystem _healthSystem;

    public abstract void BeginInteraction();
    public abstract void EndInteraction();

    public virtual void OnEnable () 
    {
        BeginInteractionCallback += BeginInteraction;
        EndInteractCallback += EndInteraction;
    }

    public virtual void OnDisable()
    {
        BeginInteractionCallback -= BeginInteraction;
        EndInteractCallback += EndInteraction;
    }


    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        _playerRB = other.collider.GetComponentInParent<Rigidbody2D>();
        _healthSystem = FindFirstObjectByType<HealthSystem>();
        BeginInteractionCallback?.Invoke();
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        EndInteractCallback?.Invoke();
    }
}
