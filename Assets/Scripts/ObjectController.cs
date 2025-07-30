using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField]
    private Vector3 force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject

        //System.Random random = new System.Random();
        //random.Next();

        //Vector3 force = new Vector3(x, y, z);

        // Vector3.up (0,1,0) * 5 = (0,5,0)
         _rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
         _rb.AddTorque(Vector3.right * 4f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �������� �� ������, ��������� ���������� �� UI
        //_rb.AddForce(force, ForceMode.Force);
    }

    // FixedUpdate ����������� 1 ��� �� ���������� �������� (�� ����������� 0.02 � = 50 ����/�)
    private void FixedUpdate()
    {
        // ��������� ������, ������� �� ������ ��'����
        _rb.AddForce(force, ForceMode.Force);
    }
}
