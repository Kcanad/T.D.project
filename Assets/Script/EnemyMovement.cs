using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _startspeed;
    [SerializeField] private float _triggerRange;
    private float _speed;
    private Transform target;
    private Enemy _enemy;

    private int wavepointindex = 0;

    private void Start()
    {
        _speed = _startspeed;
        _enemy = GetComponent<Enemy>();
        target = Waypoint.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= _triggerRange)
        {
            GetNextWaypoint();
        }
    }
    public void Slow(float slowmovespeed)
    {
        _speed = _startspeed * slowmovespeed;
    }


    void GetNextWaypoint()
    {
        if (wavepointindex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointindex++;
        target = Waypoint.points[wavepointindex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
