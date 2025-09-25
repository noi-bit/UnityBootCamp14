using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //�ΰ� ���� ������
    public Animation LogoAnim;
    public TextMeshProUGUI LogoText;

    //Ÿ��Ʋ�� ���� ����
    public GameObject _title;
    public Slider _loadingSlider;
    public TextMeshProUGUI _loadingProgressText;

    //�񵿱� ���� ���¸� �ޱ� ���� ����
    private AsyncOperation _asyncOperation;

    private void Awake()
    {
        LogoAnim.gameObject.SetActive(true);
        _title.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        Logger.Log($"{GetType()} :: LoadGameCoroutine");

        LogoAnim.Play();
        yield return new WaitForSeconds(LogoAnim.clip.length);

        LogoAnim.gameObject.SetActive(false);
        _title.SetActive(true);

        _asyncOperation = SceneLoader.instance.LoadSceneAsync(SceneType.Lobby);
        if(_asyncOperation == null )
        {
            Logger.LogError("Lobby async loading error");
            yield break;
        }

        _asyncOperation.allowSceneActivation = false; //0.1~0.8 -> ���̵��� �ڵ����� ��, �װ� ���� ����

        //_loadingSlider.value = 0.5f;
        _loadingProgressText.text = ((int)(_loadingSlider.value * 100)).ToString();
        yield return new WaitForSeconds(0.5f);

        while(_asyncOperation.isDone == false)
        {
            _loadingSlider.value = _asyncOperation.progress; //< 0.5f ? 0.5f : _asyncOperation.progress;
            _loadingProgressText.text = ((int)(_loadingSlider.value * 100)).ToString(); 
            
            //�� �ε��� �Ϸ�Ǿ��ٸ� �ڷ�ƾ ���� �̵��ϱ�
            if(_asyncOperation.progress >= 0.9f)
            {
                _asyncOperation.allowSceneActivation = true; 
                yield break;
            }
            yield return null;
        }
    }
}
