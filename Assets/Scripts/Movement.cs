using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed;
    private float InputX,InputY;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        InputX=Input.GetAxis("Horizontal");
        InputY=Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(InputX*speed,0,InputY*speed));
    }
}
