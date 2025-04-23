using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorMovement : MonoBehaviour
{
    private float _radius = 2f;
    public Image Character;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        Vector3 direction = mousePosition;

        float angle = Mathf.Atan2(direction.y, direction.x);

        float x = _radius * Mathf.Cos(angle);
        float y = (-80f/ 125) + _radius * Mathf.Sin(angle);

        transform.position = new Vector3(x, y, 0);

        float rotationAngle = angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        if(rotationAngle < 90 && rotationAngle > -90)
        {
            Character.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Character.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
