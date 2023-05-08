using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Hedef olarak karakterin Transform bile�enini kullanaca��z
    public Vector3 offset; // Kameran�n karaktere olan mesafesini belirlemek i�in kullanaca��z
    public float rotationSpeed = 5f;
    public Vector3 rotation = new Vector3(45f, 0f, 0f); // kamera rotasyon de�eri
    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Hedefin konumunu ve rotasyonunu takip eden kamera
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
