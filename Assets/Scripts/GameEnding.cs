using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource caughtSound;
    public AudioSource exitSound;
    public float displayImageDuration = 1f;
    public float fadeDuration = 1f;

    float m_Timer = 0f;
    bool m_IsPlayerOnExit;
    bool m_IsPlayerCaught;
    bool m_hasAudioPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerOnExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitSound);
        } else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtSound);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) m_IsPlayerOnExit = true;
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_hasAudioPlayed)
        {
            m_hasAudioPlayed = true;
            audioSource.Play();
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart) SceneManager.LoadScene(0);
            else Application.Quit();
        }
    }
}
