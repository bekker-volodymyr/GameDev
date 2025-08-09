using UnityEngine;

public class RandomButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform buttonRect;

    [SerializeField]
    private RectTransform canvasRect;

    public void OnClick()
    {
        // Розміри канвасу і кнопки
        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;

        float buttonWidth = buttonRect.rect.width;
        float buttonHeight = buttonRect.rect.height;

        // Визначаємо діапазон позицій (щоб кнопка не вийшла за межі)
        float minX = -canvasWidth / 2 + buttonWidth / 2;
        float maxX = canvasWidth / 2 - buttonWidth / 2;
        float minY = -canvasHeight / 2 + buttonHeight / 2;
        float maxY = canvasHeight / 2 - buttonHeight / 2;

        // Генеруємо випадкову локальну позицію
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}
