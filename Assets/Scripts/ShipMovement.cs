using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 90;

    [Header("Links")]

    public Transform SpaceShip;
    [SerializeField] private List<Engine> Engines = new List<Engine>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        float yaw = _rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float pitch = _rotationSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        float roll = _rotationSpeed * Input.GetAxis("Roll") * Time.deltaTime;

        SpaceShip.Rotate(pitch, yaw, roll);
    }

    private void Move()
    {
        Vector3 resultThrust = new Vector3();
        foreach (var engine in Engines)
        {
            resultThrust += engine.Thrust();
        }

        SpaceShip.Translate(resultThrust);
    }
}
