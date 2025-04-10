using UnityEngine;
using Unity.Netcode;

public class TitleScreenManager : MonoBehaviour
{
    public void StartNetworkAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartNewGame()
    {
        WorldSaveGameManager.instance.StartCoroutine(WorldSaveGameManager.instance.LoadNewGame());
    }
}
