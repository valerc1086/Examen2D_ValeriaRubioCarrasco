using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
