using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; 
    public float radius = 10.0f; 
    public float speed = 50.0f; 

    private float angle = 0f; 

    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            angle += speed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle -= speed * Time.deltaTime; 
        }

        
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        float z = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        Vector3 newPosition = target.position + new Vector3(x, 0, z);

        
        transform.position = newPosition;

        
        transform.LookAt(target.position);

        
        Vector3 currentRotation = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(60f, currentRotation.y, currentRotation.z);
    }
}