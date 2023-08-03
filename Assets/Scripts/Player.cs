using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject _lasePrefab;
    [SerializeField] private GameObject _tripleShootPrefab;
    [SerializeField] private float _fireRate = 0.35f;
    [SerializeField] private float _nextFire = 0.5f;

    public bool canTripleShoot = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start is called!");
        Debug.Log($"Name Obj: {name}");
        Debug.Log($"Position X: {transform.position.x}");
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        #region X and Y Player Moviments

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(
            (Time.deltaTime * speed * horizontalInput),
            (Time.deltaTime * speed * verticalInput)));

        #endregion

        #region Limits

        // Y (Vertical)
        transform.position = transform.position.y switch
        {
            > 4.15f => new Vector3(transform.position.x, 4.15f, 0),
            < -4.15f => new Vector3(transform.position.x, -4.15f, 0),
            _ => transform.position
        };
        // x (Horizontal)
        transform.position = transform.position.x switch
        {
            > 9.5f => new Vector3(-9.5f, transform.position.y, 0),
            < -9.5f => new Vector3(9.5f, transform.position.y, 0),
            _ => transform.position
        };

        #endregion

        #region Laser

        if (Input.GetKeyDown(KeyCode.T) && canTripleShoot)
        {
            Instantiate(_tripleShootPrefab, transform.position.normalized, quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_lasePrefab, transform.position + new Vector3(0, -0.3f, 0), quaternion.identity);
        }

        #endregion
    }
    
    
}