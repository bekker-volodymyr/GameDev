using UnityEngine;

public class CreatePrimitive : MonoBehaviour
{
    void Start()
    {
        SpawnPrimitive((PrimitiveType)UnityEngine.Random.Range(0, 6), transform.position, transform.rotation);
    }

    void Update()
    {
        
    }

    void SpawnPrimitive(PrimitiveType primitiveType, Vector3 position, Quaternion rotation)
    {
        GameObject primitive = GameObject.CreatePrimitive(primitiveType);
        primitive.transform.position = position;
        primitive.transform.rotation = rotation;
        primitive.name = primitiveType.ToString();
    }
}
