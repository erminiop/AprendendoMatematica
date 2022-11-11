using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
            Loader.Instance.Loading(sceneName);
        }
    }
}
