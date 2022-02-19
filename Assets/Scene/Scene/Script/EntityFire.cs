using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [HideInInspector] public bool canFire = true;
    public List<Bullet> bullets = new List<Bullet>();
    Bullet cycledBullet;

    public void FireBullet(int power)
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isActiveAndEnabled)
                {
                    cycledBullet = bullets[i];
                    break;
                }
            }
            if (cycledBullet != null)
            {
                cycledBullet.gameObject.transform.position = _spawnPoint.position;
                cycledBullet.Init(_spawnPoint.TransformDirection(Vector3.right), power);
                cycledBullet.gameObject.SetActive(true);
                cycledBullet = null;
            }
            else
            {
                var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
                    .Init(_spawnPoint.TransformDirection(Vector3.right), power);
                bullets.Add(b);
            }
        } else
        {
            var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
                .Init(_spawnPoint.TransformDirection(Vector3.right), power);
            bullets.Add(b);
        }
    }
}
