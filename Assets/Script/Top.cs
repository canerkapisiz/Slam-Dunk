using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource topSesi;

    private void OnTriggerEnter(Collider other)
    {
        topSesi.Play();
        if (other.CompareTag("basket"))
        {
            gameManager.Basket(transform.position);
        }
        else if (other.CompareTag("oyunBitti"))
        {
            gameManager.Kaybettin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        topSesi.Play();
    }
}
