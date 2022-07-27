using UnityEngine;
public class Move : MonoBehaviour
{
    public float _speed = 6;
    public float _jumpForce = 6;
    private Rigidbody _rig;
    private Vector2 _input;
    private Vector3 _movementVector;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        //Need to freez rotation so the player do not flip over
        _rig.freezeRotation = true;
    }
    
    public void Movement(Vector2 _input)
    {
        //Keep the movement vector aligned with the player rotation
        _movementVector = _input.x * transform.right * _speed + _input.y * transform.forward * _speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        _rig.velocity = new Vector3(_movementVector.x, _rig.velocity.y, _movementVector.z);
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            _rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public bool OnPlatform()
    {
        RaycastHit hit;
        //Simple way to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.transform.tag == "Obstacles")
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
}

    private bool IsGrounded()
    {
        RaycastHit hit;
        //Simple way to check for ground
        if (Physics.Raycast(transform.position , Vector3.down, out hit ,  1f) )
        {
            if (hit.transform.tag == "Ground")
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
}