using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    public float amount;
    public float maxAmount;
    public float smoothingAmount;

    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = - Input.GetAxis("Mouse X") * Time.deltaTime * amount;
        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * amount;

        mouseX = Mathf.Clamp(mouseX, -maxAmount, maxAmount);
        mouseY = Mathf.Clamp(mouseY, -maxAmount, maxAmount);

        Vector3 finalPos = new Vector3(mouseX, mouseY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + initialPos, Time.deltaTime * smoothingAmount);
    }
}
