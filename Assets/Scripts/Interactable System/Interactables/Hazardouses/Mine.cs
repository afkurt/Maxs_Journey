using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Mine : InteractableBase
{
    private bool hasExploded;
    

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void BeginInteraction()
    {
        if (hasExploded) return;
        hasExploded = true;
        animator.SetTrigger("Boom");

        StartCoroutine(DelayedDamage());
        
    }

    private IEnumerator DelayedDamage()       // Düzelt
    {
        
        
        yield return new WaitForSeconds(1f);
        float explosionRadius = 2.5f;
        float explosionForce = 15f;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);


        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                Rigidbody2D rb = hit.GetComponentInParent<Rigidbody2D>();

                if (rb != null)
                {
                    Vector2 direction = (rb.position - (Vector2)transform.position).normalized;
                    rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
                    _healthSystem.TakeDamage(1f);
                }
            }
        }
        Destroy(gameObject);
        //   _playerRB.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        //   _healthSystem.TakeDamage(1f);
    }

    public override void EndInteraction()
    {
        
    }
}
