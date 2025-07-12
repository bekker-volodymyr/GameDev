using UnityEngine;

public class MessagesSendings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BroadcastMessage("OnMessageReceived", "Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
