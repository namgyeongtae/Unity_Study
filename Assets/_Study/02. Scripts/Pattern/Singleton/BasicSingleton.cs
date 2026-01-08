using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicSingleton : MonoBehaviour
{
    private static BasicSingleton instance;
    public static BasicSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<BasicSingleton>();

                if (obj == null)
                    obj = new GameObject("BasicSingleton").AddComponent<BasicSingleton>();

                instance = obj;
            }

            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }
}
