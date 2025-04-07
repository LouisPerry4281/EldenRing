using UnityEngine;

public class PlayerManager : CharacterManager
{
    [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
    [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;

    protected override void Awake()
    {
        base.Awake();

        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }

    private protected override void Update()
    {
        base.Update();

        //If we do not control this game object, we do not control or edit it
        if (IsOwner)
            return;

        playerLocomotionManager.HandleAllMovement();
    }

    private protected override void LateUpdate()
    {
        if (!IsOwner)
        {
            return;
        }

        base.LateUpdate();

        PlayerCamera.instance.HandleAllCameraActions();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            PlayerCamera.instance.player = this;
            PlayerInputManager.instance.player = this;
        }
    }


}
