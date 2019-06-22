using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 10f;
    public float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        var position = player.position;
        transform.position = new Vector3(position.x - 20f, y: position.y + pitch, position.z - 20f);
    }

    // Update is called once per frame
    private void Update()
    {
        var position = player.position;
        transform.LookAt(position);
        
        transform.RotateAround(position, Vector3.up, Input.GetAxisRaw("Mouse X") * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
