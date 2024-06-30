using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGuc : MonoBehaviour
{
    [SerializeField] private float aci;
    [SerializeField] private float uygulanacakGuc;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(aci, 90, 0) * uygulanacakGuc, ForceMode.Force);
    }
}
