using UnityEngine;
using UnityEngine.UI;

public class ifQuizHint : MonoBehaviour
{
    public SOMaker somakerhint;
    public Text hint;

    private void Start()
    {
        hint.text = $"{somakerhint.hint}";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            hint.gameObject.SetActive(false);
        }
    }
}
