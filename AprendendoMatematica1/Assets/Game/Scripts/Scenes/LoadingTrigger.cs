using UnityEngine;

public class LoadingTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    struct tagName
    {
        public const string player = "Player";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName.player))
        {
            Loader.Instance.LoadSceneAsync(sceneName);
        }
    }
}
