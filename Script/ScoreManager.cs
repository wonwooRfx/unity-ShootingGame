using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    public Text bestScoreUI;
    private int currentScore;
    private int bestScore;

    GameObject obj;

     public static ScoreManager Instance = null;

     public int Score
    {
       get
       {
          return currentScore;
       }
       set
       {
           //ScoreManager 클래스의 속성에 값을 할당한다.
         currentScore = value;
         currentScoreUI.text = "현재점수 : " + currentScore;

         if(currentScore > bestScore)
         {
             bestScore = currentScore;
             bestScoreUI.text = "최고점수 : " + bestScore;
             PlayerPrefs.SetInt("Best Score", bestScore);
         }
       }
    }

     void Awake()
     {
         if(Instance == null)
         {
             Instance = this;
         }
     }

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("CurrentScore");
        currentScoreUI = obj.GetComponent<Text>();
        GameObject obj2 = GameObject.Find("BestScore");
        bestScoreUI = obj2.GetComponent<Text>();

       // 최고점수를 불러와서 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //최고점수 화면에 표기
        bestScoreUI.text = "최고점수:" + bestScore;
    }

    //currentScore에 값을 넣고 화면에 표시하기
    /*public void SetScore(int value)
    {
        //ScoreManager 클래스의 속성에 값을 할당한다.
        currentScore = value;
        currentScoreUI.text = "현재점수 : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고점수 : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    //currentScore 값 가져요기
    public int GetScore()
    {
        return currentScore;
    }*/

  
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
