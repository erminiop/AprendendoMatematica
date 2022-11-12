using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour

{
    [SerializeField] private CanvasGroup canvasLoading;
    [SerializeField][Range(0.1f,3f)] private float timeCanvas = 0.5f;
    public static Loader Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneAsync(string sceneName) 
    {
        StartCoroutine(Loading(sceneName));
    }

    private IEnumerator Loading(string sceneName)
    {
        yield return StartCoroutine(FadeIn());
        var loadingBar = SceneManager.LoadSceneAsync(sceneName);
        while(loadingBar.isDone == false)
        {
            yield return null;
        }
        yield return StartCoroutine(FadeEnd());
        
    }

    IEnumerator FadeIn()
    {
        float ini = 0;
        float end = 1;
        float speed = (end - ini) / timeCanvas;
        canvasLoading.alpha = ini;
        while(canvasLoading.alpha < end)
        {
            canvasLoading.alpha += speed * Time.deltaTime;
            yield return null;
        }
        canvasLoading.alpha = end;
    }

    IEnumerator FadeEnd()
    {
        float ini = 0;
        float end = 1;
        float speed = (ini - end) / timeCanvas;
        canvasLoading.alpha = end;
        while (canvasLoading.alpha > ini)
        {
            canvasLoading.alpha += speed * Time.deltaTime;
            yield return null;
        }
        canvasLoading.alpha = ini;
    }

}
