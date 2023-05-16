using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _partToRotate;
    private Enemy _targetEnemy;

    [Header("Attributes")]
    [SerializeField] private float _range;
    [SerializeField] private float _turnspeed;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireCountDown;

    [Header("Unity Setup Fields")]
    private Transform target;
    public string enemyTag = "Enemy";
    public GameObject bulletprefab;
    public Transform firePoint;

    [Header("Laser Setting")]
    [SerializeField] private bool _uselaser = false;
    [SerializeField] public int DamageOvertime;
    public LineRenderer LineRenderer;
    public float Slow;


    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            if (_uselaser)
            {
                if (LineRenderer.enabled)
                    LineRenderer.enabled = false;
            }
            return;
        }
        LockOnTarget();
        if (_uselaser)
        {
            Laser();
        }
        else
        {
            if (_fireCountDown <= 0)
            {
                Shoot();
                _fireCountDown = 1f / _fireRate;

            }
            _fireCountDown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnspeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        _targetEnemy.Takedamage(DamageOvertime * Time.deltaTime);
        //_targetEnemy.Slow(Slow);
        if (!LineRenderer.enabled)
            LineRenderer.enabled=true;

        LineRenderer.SetPosition(0, firePoint.position);
        LineRenderer.SetPosition(1, target.position);
    }
    void Shoot()
    {
       GameObject bulletGo = (GameObject) Instantiate(bulletprefab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_range);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            target = nearestEnemy.transform;
            _targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
}
