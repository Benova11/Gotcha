using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;

    public void OnStartGameClicked()
    {
        SceneManager.LoadScene("Level2");
    }

    void Update()
    {
        HandLoopOnPlayButton();
    }

    void HandLoopOnPlayButton()
    {
        if (!LeanTween.isTweening())
        {
            var seq = LeanTween.sequence();
            seq.append(LeanTween.scale(startButton.gameObject, new Vector2(1.3f, 1.3f), 0.5f).setEase(LeanTweenType.easeInOutCirc));
            seq.append(LeanTween.scale(startButton.gameObject, new Vector2(1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutCirc));

            seq.reset();
        }
    }
}
