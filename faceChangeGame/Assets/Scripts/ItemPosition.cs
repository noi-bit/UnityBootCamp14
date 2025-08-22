using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPosition : MonoBehaviour
{
    public Button setPosition;
    public Button targetItem;
    public Vector2 targetPosition;

    void Start()
    {
        targetItem.transform.position = targetPosition;
        setPosition.onClick.AddListener(SetPositionButton);
    }

    void Update()
    {
    }

    void SetPositionButton()
    {
        targetItem.transform.position = targetPosition;
    }
}
