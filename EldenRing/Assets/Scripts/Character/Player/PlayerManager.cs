using UnityEngine;

public class PlayerManager : CharacterManager
{
    PlayerLocomotionManager playerLocomotionManager;

    protected override void Awake()
    {
        base.Awake();

        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    private protected override void Update()
    {
        base.Update();

        //If we do not control this game object, we do not control or edit it
        if (IsOwner)
            return;

        playerLocomotionManager.HandleAllMovement();
    }
}
