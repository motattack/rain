using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 3f;
    public Transform target;
    public Vector2 maxPosition;
    public Vector2 minPosition;


    public void LateUpdate()
    {
        var position = target.position;
        var newPos = new Vector3(position.x, position.y + yOffset, -10f);

        newPos.x = Mathf.Clamp(newPos.x, minPosition.x, maxPosition.x);
        newPos.y = Mathf.Clamp(newPos.y, minPosition.y, maxPosition.y);
        
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
