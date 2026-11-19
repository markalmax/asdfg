using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed,sensitivity;
    private float xRotation;
    private Rigidbody rb;
    private Transform shade;
    private 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>(); 
        shade = transform.Find("Shade");
    }
    void Update()
    {
        move();
        look();
    }
    private float desiredX;
    void look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        desiredX += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        
        transform.localRotation = Quaternion.Euler(0, desiredX, 0); 
        shade.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);  
    }
    void move()
    {
        float InputX=Input.GetAxisRaw("Horizontal");
        float InputY=Input.GetAxisRaw("Vertical");
        
        rb.AddForce(transform.right*speed*InputX);
        rb.AddForce(transform.forward*speed*InputY);
    }
}
