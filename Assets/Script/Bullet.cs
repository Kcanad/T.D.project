using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _speedBullet;
    [SerializeField] private float _timeDestroyEffects;
    [SerializeField] private float _radiusExplode;
    [SerializeField] public int _damage;
    private Transform _target;
    public GameObject impactEffects;

    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _speedBullet * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    public void Seek (Transform targetenemy)
    {
        _target = targetenemy;
    }


    void HitTarget()
    {
        Debug.Log("Hit");

        GameObject effects = (GameObject) Instantiate(impactEffects,transform.position ,transform.rotation);
        Destroy(effects,_timeDestroyEffects);

        if(_radiusExplode > 0f)
        {
           Explode();
        }
        else
        {
            Damage(_target);

        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplode);

        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }


    }

    void Damage(Transform enemy)
    {
        Enemy enemyTakeDamage =enemy.GetComponent<Enemy>();
        if(enemyTakeDamage != null)
        {
            enemyTakeDamage.Takedamage(_damage);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radiusExplode);
    }
}
