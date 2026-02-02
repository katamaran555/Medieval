using UnityEngine;

public class KafesYonetici : MonoBehaviour
{
    public Animator kapakAnim; // Cage.001 buraya sürüklenecek
    public Rigidbody topRB;    // Topun Rigidbody'si buraya sürüklenecek

    [Header("Movement Settings")]
    public float startZ = -12.15f; // Başlangıç Z pozisyonu (Inspector'dan ayarlanabilir)
    public float distance = 10.0f; // Hareket mesafesi
    public float speed = 5.0f;     // Hareket hızı

    private bool isMoving = true;
    private bool basladiMi = false;

    void Start()
    {
        // Başlangıçta objeyi startZ konumuna taşıyoruz
        transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
    }

    void Update()
    {
        if (isMoving)
        {
            // startZ noktasından 'distance' kadar ileri gidip geri gelme
            // PingPong(Time.time * speed, distance) 0 ile distance arasında değişir.
            float offset = Mathf.PingPong(Time.time * speed, distance);
            float z = startZ + offset;
            
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
    }

    // Sadece bu objeye (Collider'ına) tıklandığında çalışır
    void OnMouseDown()
    {
        if (isMoving)
        {
            DropBall();
        }
    }

    void DropBall()
    {
        if (basladiMi) return;

        isMoving = false;
        basladiMi = true;

        if (kapakAnim != null)
        {
            kapakAnim.Play("KapakAcilma");
        }

        if (topRB != null)
        {
            topRB.isKinematic = false;
            topRB.useGravity = true;
        }
    }
}