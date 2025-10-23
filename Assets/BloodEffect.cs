using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    private void OnEnable()
    {
        HealthSystem.OnHealthChanged += Effect;
    }

    private void OnDisable()
    {
        HealthSystem.OnHealthChanged -= Effect;
    }



    void Effect(float damage)
    {
        GameObject blood = Instantiate(gameObject, transform.position, Quaternion.identity);
        Destroy(blood,1f);
    }
}
