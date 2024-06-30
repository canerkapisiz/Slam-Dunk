using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("LEVEL TEMEL OBJELER")]
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject pota;
    [SerializeField] private GameObject potaBuyume;
    [SerializeField] private GameObject[] ozellikOlusmaNoktalari;
    [SerializeField] private AudioSource[] sesler;
    [SerializeField] private ParticleSystem[] efektler;

    [Header("UI TEMEL OBJELER")]
    [SerializeField] private Image[] gorevGorselleri;
    [SerializeField] private Sprite gorevTamamSprite;
    [SerializeField] private int atilmasiGerekenTop;
    [SerializeField] private GameObject[] paneller;
    [SerializeField] private TextMeshProUGUI levelAdi;
    int basketSayisi;
    float parmakPozX;

    void Start()
    {
        levelAdi.text = "LEVEL : " + SceneManager.GetActiveScene().name;

        for (int i = 0; i < atilmasiGerekenTop; i++)
        {
            gorevGorselleri[i].gameObject.SetActive(true);
        }

        Invoke("OzellikOlussun", 3f);
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        parmakPozX = touchPosition.x - platform.transform.position.x;
                        break;
                    case TouchPhase.Moved:
                        if(touchPosition.x - parmakPozX > -1.15 && touchPosition.x - parmakPozX < 1.15)
                        {
                            platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(touchPosition.x - parmakPozX,
                       platform.transform.position.y, platform.transform.position.z), 5f);
                        }
                        break;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (platform.transform.position.x > -1.15)
                {
                    platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x - 0.3f,
                        platform.transform.position.y, platform.transform.position.z), 0.050f);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (platform.transform.position.x < 1.15)
                {
                    platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x + 0.3f,
                    platform.transform.position.y, platform.transform.position.z), 0.050f);
                }
            }
        }
    }

    public void Basket(Vector3 poz)
    {
        basketSayisi++;
        gorevGorselleri[basketSayisi - 1].sprite = gorevTamamSprite;
        efektler[0].transform.position = poz;
        efektler[0].gameObject.SetActive(true);
        sesler[1].Play();
        if (basketSayisi == atilmasiGerekenTop)
        {
            Kazandin();
        }
    }

    void Kazandin()
    {
        sesler[3].Play();
        paneller[1].SetActive(true);
        PlayerPrefs.GetInt("level", PlayerPrefs.GetInt("level")+1);
        Time.timeScale = 0;
    }

    public void Kaybettin()
    {
        sesler[2].Play();
        paneller[2].SetActive(true);
        Time.timeScale = 0;
    }

    public void PotaBuyut(Vector3 poz)
    {
        efektler[1].transform.position = poz;
        efektler[1].gameObject.SetActive(true);
        sesler[0].Play();
        pota.transform.localScale = new Vector3(55f, 55f, 55f);
    }

    void OzellikOlussun()
    {
        int randomSayi = Random.Range(0, ozellikOlusmaNoktalari.Length);

        if(potaBuyume != null)
        {
            potaBuyume.transform.position = ozellikOlusmaNoktalari[randomSayi].transform.position;
            potaBuyume.SetActive(true);
        }
    }

    public void ButonlarinIslemleri(string deger)
    {
        switch (deger)
        {
            case "durdur":
                Time.timeScale = 0;
                paneller[0].SetActive(true);
                break;
            case "devamEt":
                Time.timeScale = 1;
                paneller[0].SetActive(false);
                break;
            case "tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "sonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;
        }
    }
}
