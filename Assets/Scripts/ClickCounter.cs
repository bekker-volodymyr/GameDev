using TMPro;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textToChange;

    int _counter = 0;

    public void OnClick()
    {
        _textToChange.text = $"Clicks: {(++_counter)}";
    }
}
