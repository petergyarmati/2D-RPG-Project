using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float thrustPower;

    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void AddTrust(Vector2 direction)
    {
        _rigidbody.AddForce(direction * thrustPower);
    }
}
