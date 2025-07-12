using UnityEngine;

public class FirstScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("This is message from Start method of FirstScript.");
        Debug.Log($"Object name: {gameObject.name}");
        Debug.Log($"Object coords: {transform.position}");
        Debug.Log($"Object rotation: {transform.rotation}");
        Debug.Log($"Object scale: {transform.localScale}");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("This is message from Update method of FirstScript.");
    }
}
