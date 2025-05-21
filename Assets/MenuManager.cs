using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject panelConfig;
    private bool isMuted = false;

    public void OpenConfig()
    {
        panelConfig.SetActive(true);
    }

    public void CloseConfig()
    {
        panelConfig.SetActive(false);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        Debug.Log("Áudio está " + (isMuted ? "desativado" : "ativado"));
    }
}
