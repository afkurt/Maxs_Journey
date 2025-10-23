using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStats", menuName = "PlayerSystem/Player Data")]
public class PlayerStats : ScriptableObject
{
    public float jumpForce = 12f;
    public float moveSpeed = 5f;
    
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public bool isGrounded;
}
