using System.Collections;
using UnityEngine;

public class ArrowTarget : MonoBehaviour
{
    [SerializeField] private GameObject arrowBlack; // Object con màu đen
    [SerializeField] private GameObject arrowRed;   // Object con màu đỏ

    private Vector3 originalPosition; // Vị trí ban đầu
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.position; // Lưu vị trí ban đầu
        ResetArrow(); // Đảm bảo trạng thái ban đầu
    }

    public void ResetArrow()
    {
        rectTransform.position = originalPosition; // Đặt lại vị trí
        arrowBlack.SetActive(false);
        arrowRed.SetActive(false);
        gameObject.SetActive(false); // Tắt toàn bộ mũi tên
    }

    public void UpdateArrow(Vector3 targetPosition, bool isOverEnemy)
    {
        rectTransform.position = targetPosition; // Di chuyển mũi tên
        arrowBlack.SetActive(!isOverEnemy);      // Hiển thị mũi tên đen nếu không trúng enemy
        arrowRed.SetActive(isOverEnemy);         // Hiển thị mũi tên đỏ nếu trúng enemy
    }
}
