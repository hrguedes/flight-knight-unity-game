using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speedLase = 10.0f;
    void Start()
    {
    }

    void Update()
    {
        #region Moviment
        transform.Translate(Vector3.up * (_speedLase * Time.deltaTime));
        #endregion

        #region Limits

        if (transform.position.y > 5.31f)
        {
            Destroy(gameObject);
        }
        #endregion
    }
}