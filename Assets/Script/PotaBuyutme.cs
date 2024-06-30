using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sure;
    [SerializeField] private int baslangicSuresi;
    [SerializeField] private GameManager gameManager;

    IEnumerator Start()
    {
        sure.text = baslangicSuresi.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            baslangicSuresi--;
            sure.text = baslangicSuresi.ToString();

            if (baslangicSuresi == 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.PotaBuyut(transform.position);
        gameObject.SetActive(false);
    }
}
