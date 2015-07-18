using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDialog : MonoBehaviour 
{
    public Text dialogScoreText;

    public void ShowDialog(int score)
    {
        dialogScoreText.text = score.ToString();
        this.gameObject.SetActive(true);
    }


	void Awake () 
    {
        this.gameObject.SetActive(false);
	}


    public void BackBtnClicked()
    {
        Application.LoadLevel("TitleScene");
    }


    public void RetryButtonClicked()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
