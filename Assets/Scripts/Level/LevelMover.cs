using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Start()
    {
        PlayerMover.onDeath += StopMove;
    }
    void Update()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * Time.deltaTime*speed);
    }
    private void StopMove()
    {
        speed = 0;
    }
}
