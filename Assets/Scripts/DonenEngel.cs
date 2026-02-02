using UnityEngine;

public class DonenEngel : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 100.0f; // Hızı artırdık çünkü normalize edilmiş değer küçük olacak

    private bool isDragging = false;
    private float lastMouseX;

    void OnMouseDown()
    {
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
            transform.Rotate(Vector3.up * -delta * rotationSpeed, Space.Self);

            lastMouseX = currentMouseX;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}