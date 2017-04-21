using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NetworkHUD : NetworkBehaviour {

    public NetworkLobbyManager manager;

    void Update()
    {
        manager = GameObject.Find("LobbyManager").GetComponent<NetworkLobbyManager>();
    }

    public void StartServer()
    {
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.StartServer();
        }
    }

    public void StartHost()
    {
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.StartHost();
        }
    }

    public void StartClient()
    {
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.StartClient();
        }
    }

    public void StopHost()
    {
        if (NetworkServer.active && NetworkClient.active)
        {
            manager.StopHost();
        }
    }

    public void ReadyUp()
    {
        if (NetworkClient.active && !ClientScene.ready)
        {

        }
    }

}
 


