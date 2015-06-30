using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySceneManager : MonoBehaviour 
{
    public SceneFadeInOut _SceneFadeIn;
    public FlyCreator _FlyCreator;
    public ScoreDialog _ScoreDialog;
    public StartImg _StartImg;
    public Slider _TimeSlider;
    public Text _ScoreText;

    private float _RemainTime;
    private int _Score;

    private Actor _TimeSliderActor;

    private FlyCreator _FCInstance;

	// Use this for initialization
	void Start () 
    {
        _Score = 0;
        _RemainTime = 60.0f;

        _TimeSliderActor = _TimeSlider.GetComponent<Actor>();

        Instantiate(_SceneFadeIn, new Vector2(512.0f, 384.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

        Invoke("RunStartImgAction", 1.0f);
        Invoke("AddFlyCreator", 1.5f);

        Invoke("StartTimer", 1.5f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(_RemainTime <= 0.0f)
        {
            this.enabled = false;

            Destroy(_FCInstance);

            ScoreDialog scoreDialog = Instantiate(_ScoreDialog) as ScoreDialog;
            scoreDialog._Score = _Score;
        }
	}

    void StartTimer()
    {
        StartCoroutine("Timer");
    }

    void AddFlyCreator()
    {
        _FCInstance = Instantiate(_FlyCreator);
    }

    void RunStartImgAction()
    {
        _StartImg.RunStartImgAction();
    }


    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            _RemainTime -= 0.1f;
            _TimeSlider.value = _RemainTime / 60.0f;
        }
    }


    public void AddScore(int score)
    {
        _Score += score;
        _ScoreText.text = "" + _Score;
    }


    public void SubtractTime(float sec)
    {
        _RemainTime -= sec;

        if (_TimeSliderActor.GetNumberOfRunningAction() == 0)
        {
            _TimeSliderActor.RunAction(new Vibration(0.5f, new Vector2(5.0f, 5.0f)));
        }
    }


    public void BtnBackClicked()
    {
        Application.LoadLevel("TitleScene");
    }


    public void BtnRetryClicked()
    {
        Application.LoadLevel("PlayScene");
    }
}
