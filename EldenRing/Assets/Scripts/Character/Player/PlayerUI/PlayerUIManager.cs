using UnityEngine;
using Unity.Netcode;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;
    [Header("NETWORK JOIN")]
    [SerializeField] bool startGameAsClient;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            //Need to first shut down network in order to connect as a client
            NetworkManager.Singleton.Shutdown();
            //Then start network as a client
            NetworkManager.Singleton.StartClient();
        }
    }
}
