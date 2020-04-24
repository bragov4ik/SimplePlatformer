using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _projectile = null;
    private GameObject _projectileInstance;
    public float coolDownTime = 3f;
    private float lastShotTime;

    public GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        lastShotTime = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if (_projectileInstance == null && Time.time - lastShotTime >= coolDownTime)
        {
            lastShotTime = Time.time;
            startProjectile();
        }
    }
    void startProjectile()
    {
        _projectileInstance = Instantiate(_projectile) as GameObject;
        Vector3 targetDirection = _target.transform.position - this.transform.position;
        targetDirection.z = 0;
        _projectileInstance.transform.position = this.transform.position;
        _projectileInstance.transform.Rotate(0, 0, Mathf.Rad2Deg*(float)System.Math.Acos(-targetDirection.x / targetDirection.magnitude));
    }
}
