using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetPointA, _targetPointB;
    [SerializeField] private float _platformSpeed = 1.0f;
    private Transform _actualTarget;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlatformMovement();
    }

    void PlatformMovement()
    {
        float step = _platformSpeed * Time.deltaTime;
               
        if (Vector3.Distance(transform.position, _targetPointB.position) < 0.01f)
        {
            _actualTarget = _targetPointA;
        }
        else if (Vector3.Distance(transform.position, _targetPointA.position) < 0.01f)
        {
            _actualTarget = _targetPointB;
        }

        transform.position = Vector3.MoveTowards(transform.position, _actualTarget.position, step);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    // todo parenting


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
