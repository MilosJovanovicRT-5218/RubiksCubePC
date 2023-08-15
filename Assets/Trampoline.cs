using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float initialJumpForce = 10f; // Po�etna ja�ina skoka
    public float jumpForceIncrement = 2f; // Inkrement za svaki slede�i skok
    private float currentJumpForce; // Trenutna ja�ina skoka
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpForce = initialJumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trampoline")
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Resetujte vertikalnu brzinu
        rb.AddForce(Vector3.up * currentJumpForce, ForceMode.Impulse);
        currentJumpForce += jumpForceIncrement; // Pove�ajte ja�inu skoka za slede�i put
    }
}
