using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class CharacterManager : NetworkBehaviour
{
    public CharacterController characterController;
    CharacterNetworkManager characterNetworkManager;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);

        characterController = GetComponent<CharacterController>();
        characterNetworkManager = GetComponent<CharacterNetworkManager>();
    }

    protected virtual private void Update()
    {
        //If character is being controlled by us, then update the global value to tell every other client where I am
        if (IsOwner)
        {
            characterNetworkManager.networkPosition.Value = transform.position;
            characterNetworkManager.networkRotation.Value = transform.rotation;
        }
        //If character is not being controlled by us, update my position to match where I should be
        else
        {
            //Position
            transform.position = Vector3.SmoothDamp(transform.position,
                characterNetworkManager.networkPosition.Value,
                ref characterNetworkManager.networkPositionVelocity,
                characterNetworkManager.networkPositionSmoothTime);

            //Rotation
            transform.rotation = Quaternion.Slerp(transform.rotation,
                characterNetworkManager.networkRotation.Value,
                characterNetworkManager.networkRotationSmoothTime);
        }
    }

    protected virtual private void LateUpdate()
    {

    }
}
