using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Image CatFoot;
    [SerializeField] RectTransform uiRect;
    [SerializeField] Vector2 mousePosition;
    [SerializeField] Vector2 localposition;

    void Start()
    {
        mousePosition = Input.mousePosition;
        var mouse = RectTransformUtility.ScreenPointToLocalPointInRectangle(uiRect, mousePosition, null, out localposition);


    }

    void Update()
    {
        CatFoot.transform.position = mousePosition;
    }
}
