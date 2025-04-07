using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    public virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    public void UpdateAnimatorMovementParameters(float horizontal, float vertical)
    {
        character.animator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
        character.animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
    }
}
