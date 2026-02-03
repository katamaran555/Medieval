using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu satır, bu scripti eklediğinizde otomatik olarak bir AudioSource bileşeni ekler.
[RequireComponent(typeof(AudioSource))]
public class TopBaslatici : MonoBehaviour
{
    private Rigidbody rb;
    private bool oyunBasladi = false;

    [Header("Ses Ayarları")]
    public AudioSource yuvarlanmaSesi; // Otomatik bulunacak
    public float sesIcinMinimumHiz = 0.5f;

    void Start()
    {
        // Topun fizik motorunu al
        rb = GetComponent<Rigidbody>();

        // Eğer Inspector'dan ses atanmadıysa, otomatik bulmaya çalış
        if (yuvarlanmaSesi == null)
        {
            yuvarlanmaSesi = GetComponent<AudioSource>();
        }

        // BAŞLANGIÇTA DONDUR!
        rb.isKinematic = true;
    }

    // Topun üzerine tıklanınca çalışır
    void OnMouseDown()
    {
        if (!oyunBasladi)
        {
            Baslat();
        }
    }

    void Baslat()
    {
        oyunBasladi = true;

        // Fiziği serbest bırak!
        rb.isKinematic = false;

        Debug.Log("Top Yuvarlanmaya Başladı!");
    }

    void Update()
    {
        if (oyunBasladi)
        {
            KontrolSes();
        }
    }

    void KontrolSes()
    {
        if (yuvarlanmaSesi == null) return;

        // Top hareket ediyor mu? (Unity 6 için linearVelocity)
        bool hareketEdiyor = rb.linearVelocity.magnitude > sesIcinMinimumHiz;

        // Yerde mi? (Basitçe aşağıya ışın yolluyoruz)
        bool yerde = Physics.Raycast(transform.position, Vector3.down, 0.6f);

        if (hareketEdiyor && yerde)
        {
            // Eğer top hareket ediyor ve yerdeyse, ses çalmıyorsa başlat
            if (!yuvarlanmaSesi.isPlaying)
            {
                yuvarlanmaSesi.Play();
            }
        }
        else
        {
            // Havadaysa veya durduysa sesi kes
            if (yuvarlanmaSesi.isPlaying)
            {
                yuvarlanmaSesi.Stop();
            }
        }
    }
}
