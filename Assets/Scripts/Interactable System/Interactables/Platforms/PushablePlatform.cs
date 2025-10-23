using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class PushablePlatform : InteractableBase
{
    public UnityEvent Event;
    private Vector2 _defaultPosition;

    private void Start()
    {
        _defaultPosition = transform.position;
    }
    public override void BeginInteraction()
    {
        transform.DOMove(transform.position + -transform.up * .25f, .1f).SetEase(Ease.InOutSine);

        Event?.Invoke();
        
    }

    public override void EndInteraction()
    {
        transform.DOMove(_defaultPosition, .5f).SetEase(Ease.InOutSine);
    }
}
