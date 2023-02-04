using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public Text BestText;
    public TMP_InputField userName;
    private string bestPlayer;
    private int bestPoint;
    private void Start() 
    {
        UIManager.Instance.LoadBestPlayer();
        string bestPlayer = UIManager.Instance.bestPlayer;
        int bestPoint =  UIManager.Instance.bestPoint;
        BestText.text = $"Best: {bestPlayer}: {bestPoint}";    
    }
    public void NewStart()
    {
        UIManager.Instance.playerName = userName.text;
        SceneManager.LoadScene(0);
    }
}
