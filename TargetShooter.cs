using System.Collections;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _secondsWaitForShooting;
    [SerializeField] private Transform _target;  
    
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;

            yield return new WaitForSeconds(_secondsWaitForShooting);
        }
    }
}