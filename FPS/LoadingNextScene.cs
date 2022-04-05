using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingNextScene : MonoBehaviour
{
    public int scenenumber = 2;
    public Slider loadingBar;
    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransitionNextScene(scenenumber));
    }

    // Update is called once per frame

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            loadingBar.value = ao.progress;
            loadingText.text = (ao.progress * 100f).ToString() + "%";

            if (ao.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1.5f); // 로딩씬 화면을 길게 늘림
                ao.allowSceneActivation = true;

            }
            yield return null;
        }    
    }
}
