using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public bool CanFire;
    public float MaxDistance = 100f;

    private Coroutine _coroutineFiring;
    private WaitForSeconds _waitForFiring;
    [SerializeField] private float _waitTimeFiring = 0.1f;

    [SerializeField] private LineRenderer _lineRenderer;

    void Start()
    {
        if (_lineRenderer == null)
            _lineRenderer = GetComponent<LineRenderer>();

        _waitForFiring = new WaitForSeconds(_waitTimeFiring);

        _lineRenderer.enabled = false;
        CanFire = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon(transform.position + transform.forward * MaxDistance);
        }
    }

    public void FireWeapon(Vector3 targetPosition)
    {
        if (CanFire){
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetPosition);

            CanFire = false;

            StartCoroutine(FiringCor());
        }    
    }

    private IEnumerator FiringCor(){
        yield return _waitForFiring;

        CanFire = true;
        _lineRenderer.enabled = false;
    }
}
