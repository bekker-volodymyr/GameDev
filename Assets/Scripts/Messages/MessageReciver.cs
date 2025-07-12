using UnityEngine;

public class MessageReciveer : MonoBehaviour
{
    public void OnMessageReceived(string message)
    {
        Debug.Log("Message received: " + message);
    }
}
