using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class TopSesi : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    [Header("Yuvarlanma Ayarları")]
    [Tooltip("Topun ses çıkarması için gereken minimum hız.")]
    public float minHiz = 0.5f;

    [Header("Dinamik Pitch (Hız Sesi)")]
    [Tooltip("Sesin en kalın olduğu (yavaşken) perde değeri.")]
    public float minPitch = 0.8f;
    [Tooltip("Sesin en ince olduğu (hızlıyken) perde değeri.")]
    public float maxPitch = 2.0f;
    [Tooltip("Topun bu hıza ulaştığında pitch en yüksek değere ulaşır.")]
    public float maxHiz = 15.0f;

    [Header("Çarpma Sesleri")]
    public AudioClip carpmaSesi;
    [Tooltip("En yüksek ses için gereken çarpma hızı.")]
    public float maxCarpmaHizi = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // Başlangıç ayarları güvenliği
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        Kontrol();
    }

    void Kontrol()
    {
        // Hareket hızı (Unity 6: linearVelocity)
        float hiz = rb.linearVelocity.magnitude;
        bool hareketEdiyor = hiz > minHiz;

        // Yer kontrolü (Topun temas edip etmediği)
        bool yerde = Physics.Raycast(transform.position, Vector3.down, 0.6f);

        if (hareketEdiyor && yerde)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Pitch ayarlaması: Hıza göre sesi incelt
            float oran = Mathf.Clamp01(hiz / maxHiz);
            
            // Min ve Max pitch arasında geçiş yap
            audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, oran);
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (carpmaSesi == null) return;

        // Çarpma hızını al
        float carpmaSiddeti = collision.relativeVelocity.magnitude;

        // Çok yavaş çarpmalarda ses çalma
        if (carpmaSiddeti < 1f) return;

        // Sesi şiddete göre ayarla (max 1.0)
        float sesSeviyesi = Mathf.Clamp01(carpmaSiddeti / maxCarpmaHizi);

        // Sesi bir kez çal (PlayOneShot) - Mevcut çalan yuvarlanma sesini kesmez
        audioSource.PlayOneShot(carpmaSesi, sesSeviyesi);
    }
}
