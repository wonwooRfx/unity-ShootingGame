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
           //ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
         currentScore = value;
         currentScoreUI.text = "�������� : " + currentScore;

         if(currentScore > bestScore)
         {
             bestScore = currentScore;
             bestScoreUI.text = "�ְ����� : " + bestScore;
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

       // �ְ������� �ҷ��ͼ� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //�ְ����� ȭ�鿡 ǥ��
        bestScoreUI.text = "�ְ�����:" + bestScore;
    }

    //currentScore�� ���� �ְ� ȭ�鿡 ǥ���ϱ�
    /*public void SetScore(int value)
    {
        //ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        currentScore = value;
        currentScoreUI.text = "�������� : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "�ְ����� : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    //currentScore �� �������
    public int GetScore()
    {
        return currentScore;
    }*/

  
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
