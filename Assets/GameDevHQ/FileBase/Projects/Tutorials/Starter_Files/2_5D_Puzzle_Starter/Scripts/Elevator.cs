using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _elevatorCalled = false;
    [SerializeField] private Transform _origin, _target;
    private float _speed = 1.0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_elevatorCalled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else if (!_elevatorCalled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
        }
    }

    public void CallElevator()
    {
        _elevatorCalled = true;
    }

    public void EntryElevator()
    {
        _elevatorCalled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
