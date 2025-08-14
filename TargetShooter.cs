using System.Collections;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _secondsWaitForShooting;
    [SerializeField] private Transform _target;  
    
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var secondsWaitForShooting = new WaitForSeconds(_secondsWaitForShooting);

        while (enabled)
        {
            var direction = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;
            bullet.velocity = direction * _bulletSpeed;

            yield return secondsWaitForShooting;
        }
    }
}