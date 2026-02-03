using UnityEngine;

public class DonenEngel : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 100.0f; // Hızı artırdık çünkü normalize edilmiş değer küçük olacak
    public float autoRotationSpeed = 50.0f; // Otomatik dönme hızı
    public bool isAutoRotating = true; // Otomatik dönme aktif mi?
    public Vector3 rotationAxis = Vector3.forward; // Varsayılan Z ekseni

    private bool isDragging = false;
    private float lastMouseX;

    void Update()
    {
        if (isAutoRotating)
        {
            transform.Rotate(rotationAxis * autoRotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    void OnMouseDown()
    {
        if (isAutoRotating) return; // Otomatik dönüyorsa müdahale etme

        // Tıklama başladığında X pozisyonunu kaydet
        isDragging = true;
        lastMouseX = Input.mousePosition.x;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            float currentMouseX = Input.mousePosition.x;
            
            // Farkı ekran genişliğine bölerek cihaz çözünürlüğünden bağımsız hale getiriyoruz
            float delta = (currentMouseX - lastMouseX) / Screen.width;

            // Normalize ettiğimiz için delta çok küçük (0.0 - 1.0 arası), bu yüzden rotationSpeed çarpanı önemli
            // Dönüş yönünü etkilemek için negatif veya pozitif kullanabilirsiniz.
            transform.Rotate(rotationAxis * -delta * rotationSpeed, Space.Self);

            lastMouseX = currentMouseX;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}