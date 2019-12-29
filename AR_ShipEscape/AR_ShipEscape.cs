using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AR_ShipEscape : MonoBehaviour
{
    //나레이션
    public GameObject narrationBox;
    public Text narrationText;

    //이미지
    public Image fade;

    //버튼
    public GameObject nextButton;
    public int selectNumber = 1;
    public GameObject button;

    //씬 확인
    public bool _sceneFinished = false;
    bool _statusCompleted = false;
    bool endBox = false;

    //말풍선 사이즈
    Vector3 speechBoxSize;
    Vector3 tigerBoxSize;
    Vector3 sharkBoxSize;
    Vector3 teacherBoxSize;
    Vector3 selectBoxSize;
     
    //대화박스
    public GameObject speechBox;
    public Text speechText;  
    public Text[] selectBox = new Text[3];
    public GameObject tigerBox;
    public GameObject sharkBox;
  
    public GameObject sTigerBox;
    public GameObject sSharkBox;

    public GameObject selectableBox;
    public Text lastSpeechText;

    //장소

    public GameObject Ship1;

    //상태
  
    public int cnt = 0;
    public GameObject wrongEndBox;
    public GameObject endingBox;

    //물체
    public GameObject[] Characters_move;
    public GameObject[] insideobjects;
    public GameObject in_water;
    public GameObject out_water;
    public GameObject outside_ship;
    public GameObject[] outpickJacket;
    public GameObject[] out_Jacket;


    public GameObject[] in_jacket;
    public GameObject tiger_Jacket;
    public GameObject shark_jacket;
    public GameObject tiger_pick_Jacket;
    public GameObject shark_pick_Jacket;

    public GameObject lifeship;

    //애니메이션
    public Animator[] Characters_ani;

    //지속
    public static int status;

    void Awake()
    {
        speechBoxSize = speechBox.transform.localScale;
        tigerBoxSize = tigerBox.transform.localScale;
        sharkBoxSize = sharkBox.transform.localScale;
       
        selectBoxSize = selectableBox.transform.localScale;

        status = 0;

    }

    void Update()
    {
        



    }
    public void PlayStory(int status)
    {
        nextButton.SetActive(false);
        if (_sceneFinished)
        {
            return;
        }
        switch (status)
        {
            case 0:
                StartCoroutine(IntroCut());  //
                break;
            case 1:
                StartCoroutine(IntroCut2()); //
                break;
            case 2:
                StartCoroutine(Speech1());   //
                break;
            case 3:
                StartCoroutine(Speech2());   // 
                break;
            case 4:
                StartCoroutine(Speech3());   // 
                break;
            case 5:
                StartCoroutine(Speech4());   // 
                break;
            case 6:
                StartCoroutine(Speech5());   //
                break;
            case 7:
                StartCoroutine(Speech6());   //
                break;
            case 8:
                StartCoroutine(Speech7());   //
                break;
            case 9:
                StartCoroutine(Speech8());   //
                break;
            case 10:
                StartCoroutine(select01());   //
                break;
            case 11:
                StartCoroutine(SelectSpeech1(selectNumber));   //
                break;
            case 12:
                if (selectNumber == 0)
                    StartCoroutine(WrongAct01_0());

                if (selectNumber == 1)
                    StartCoroutine(WrongAct01_1());
                if (selectNumber == 2)
                    StartCoroutine(GoodAct01_2());
                break;
            case 13:
                if (selectNumber == 0)
                    StartCoroutine(WrongSpeech01_0());
                
                if (selectNumber == 1)
                    StartCoroutine(WrongSpeech01_1());
                if (selectNumber == 2)
                    StartCoroutine(Speech9());
                break;
               
            case 14:
                if (selectNumber == 0)
                    StartCoroutine(WrongSpeech01_0_2());

                if (selectNumber == 1)
                    StartCoroutine(WrongSpeech01_1_2());
                if (selectNumber == 2)
                    StartCoroutine(Speech10());
                break;
            case 15:
                if (selectNumber == 0 || selectNumber == 1)
                    StartCoroutine(Wrongend01());
                if (selectNumber == 2)
                    StartCoroutine(Speech11());
                break;
            case 16:
                StartCoroutine(Speech12());
                break;
            case 17:
                StartCoroutine(Speech13());
                break;
            case 18:
                StartCoroutine(Speech14());
                break;
            case 19:
                StartCoroutine(Speech15());
                break;
            case 20:
                StartCoroutine(select02());
                break;
            case 21:
                StartCoroutine(SelectSpeech2(selectNumber));   //
                break;
            case 22:
                if (selectNumber == 0)
                    StartCoroutine(WrongAct02_0());
                if(selectNumber == 1)
                    StartCoroutine(GoodAct02_1());

                if (selectNumber == 2)
                    StartCoroutine(WrongAct02_2());
                break;
            case 23:
                if (selectNumber == 0)
                    StartCoroutine(WrongSpeech02_0());
                if (selectNumber == 1)
                    StartCoroutine(Speech16());

                if (selectNumber == 2)
                    StartCoroutine(WrongSpeech02_2());
                break;
            case 24:
                if (selectNumber == 0 || selectNumber == 2)
                    StartCoroutine(Wrongend02());
                if(selectNumber == 1)
                    StartCoroutine(select03());
                break;
            case 25:
                StartCoroutine(SelectSpeech3(selectNumber));
                break;
            case 26:
                
                if (selectNumber == 0)
                   StartCoroutine(GoodAct03_0()); 
                if (selectNumber == 1)
                    StartCoroutine(WrongAct03_1());

                if (selectNumber == 2)
                    StartCoroutine(WrongAct03_2());
                    
                break;
            case 27:

                if (selectNumber == 0)
                    StartCoroutine(Speech17());
                if (selectNumber == 1)
                    StartCoroutine(WrongSpeech03_1());

                if (selectNumber == 2)
                    StartCoroutine(WrongSpeech03_2());

                break;
            case 28:

                if (selectNumber == 0)
                    StartCoroutine(Speech18());
                if (selectNumber == 1)
                    StartCoroutine(Wrongend03());

                if (selectNumber == 2)
                    StartCoroutine(Wrongend04());

                break;
            case 29:
                if (selectNumber == 0)
                    StartCoroutine(GoodEnd());
                break;
        }
    }
    public void CompleteAnimation(int status)
    {
        DOTween.Kill("remove"); //Dotween실행을 정지시킨다.
        StopAllCoroutines();

        switch (status)
        {
            case 0:
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration1;    //
                break;
            case 1:
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration2;   //
                break;
            case 2:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration3;   //
                break;
            case 3:             
                speechBox.SetActive(true);
                tigerBox.SetActive(false);
                sharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration4;   //
                break;
            case 4:
                sharkBox.SetActive(false);
                speechBox.SetActive(true);
                tigerBox.SetActive(true);                
                speechText.text = Narration_Script.Instance.Narration5;   //
                break;
            case 5:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration6;   //
                break;
            case 6:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration7;   //
                break;
            case 7:
                speechBox.SetActive(false);
                tigerBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration8;   //
                break;
            case 8:
                narrationBox.SetActive(false);
                speechBox.SetActive(true);
                sharkBox.SetActive(true);               
                speechText.text = Narration_Script.Instance.Narration9;   //
                break;
            case 9:
               
                speechBox.SetActive(false);
                sharkBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration10;   //
                break;
            case 10:
                break;
            case 11:
                narrationBox.SetActive(false);
                speechBox.SetActive(true);
                sharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Alarm[selectNumber];   //
                break;
            case 12:
                break;
            case 13:
                if (selectNumber == 0)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.shipFail[1];
                }
                
                if (selectNumber == 1)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.shipFail[0];
                }

                if (selectNumber == 2)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Narration11;
                }
                break;
            case 14:

                if (selectNumber == 0)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.ship[0];
                }
              
                if (selectNumber == 1)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.ship[0];
                }
                if (selectNumber == 2)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Narration12;
                }
                break;
            case 15:
                if(selectNumber == 0 || selectNumber == 1)
                {
                    speechBox.SetActive(false);
                    tigerBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = Narration_Script.Instance.Narration_End1;   //
                  
                }
                if (selectNumber == 2)
                {
                    tigerBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Narration13;
                }
                break;
            case 16:
                sharkBox.SetActive(false);
                tigerBox.SetActive(true);
                speechBox.SetActive(true);               
                speechText.text = Narration_Script.Instance.Narration14;
                break;
            case 17:
                tigerBox.SetActive(false);
                sharkBox.SetActive(true);                
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration15;
                break;
            case 18:
                tigerBox.SetActive(false);
                sharkBox.SetActive(true);
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration16;
                break;
            case 19:
                sharkBox.SetActive(false);
                tigerBox.SetActive(true);              
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration17;
                break;
            case 20:
                break;
            case 21:
                if(selectNumber == 0){
                narrationBox.SetActive(false);
                speechBox.SetActive(true);
                sharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Alarm[3];
                }
                if (selectNumber == 1)
                {
                    narrationBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Alarm[4];
                }
                if (selectNumber == 2)
                {
                    narrationBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Alarm[5];

                }

                break;
            case 22:
                break;
             case 23:
                if (selectNumber == 0 || selectNumber == 2)
                {
                    sharkBox.SetActive(false);
                tigerBox.SetActive(true);
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.shipFail[2];
                }
                if (selectNumber == 1)
                {
                    tigerBox.SetActive(false);
                    sharkBox.SetActive(true);                   
                    speechBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Narration18;
                }
                break;
            case 24:
                if (selectNumber == 0 || selectNumber == 2)
                {
                    speechBox.SetActive(false);
                    tigerBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = Narration_Script.Instance.Narration_End2;
                }
                else
                {

                }               
                break;
            case 25:
                if (selectNumber == 0)
                {
                    narrationBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Alarm[6];
                }
                if (selectNumber == 1)
                {
                    narrationBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Alarm[7];
                }
                if (selectNumber == 2)
                {
                    narrationBox.SetActive(false);
                    speechBox.SetActive(true);
                    sharkBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Alarm[8];

                }
                break;
            case 26:
                break;
            case 27:
                if (selectNumber == 0)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.Narration21;
                }
                if (selectNumber == 1)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.shipFail[3];
                }
                if (selectNumber == 2)
                {
                    sharkBox.SetActive(false);
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    speechText.text = Narration_Script.Instance.shipFail[3];

                }
                break;
            case 28:
                if(selectNumber == 0)
                {
                    tigerBox.SetActive(false);
                    sharkBox.SetActive(true);
                    speechBox.SetActive(true);                    
                    speechText.text = Narration_Script.Instance.Narration22;
                }

                if (selectNumber == 1 )
                {
                    speechBox.SetActive(false);
                    tigerBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = Narration_Script.Instance.Narration_End3;
                }
                if (selectNumber == 2)
                {
                    speechBox.SetActive(false);
                    tigerBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = Narration_Script.Instance.Narration_End4;
                }

                break;




        }
        nextButton.SetActive(true);
        Narration_Script.Instance.inputAllowed = true;
        _statusCompleted = true;
    }
    public void InputButton()
    {
        if (Narration_Script.Instance.inputAllowed == false)
        {
            return;
        }
        if (_statusCompleted == false)  //대화가 나오고 있는 상태이면 complete문을 실행
        {
            CompleteAnimation(status);
        }
        else                            //대화가 나오고 있지 않은 상태면 else문 실행
        {
            if (endBox)    //게임오버
            {
                _sceneFinished = true;
                fade.DOFade(0.6f, 0.3f).OnComplete(Gameover);

                //TrackedOut();
            }
            else
            {
                CutChange();
                status++;
                PlayStory(status);
            }
        }
    }
    void Gameover()
    {
        wrongEndBox.SetActive(true);
    }

    IEnumerator IntroCut() //수학여행을 가는중
    {
        Narration_Script.Instance.inputAllowed = false;
        yield return new WaitForSeconds(1f);
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration1, 1.5f).SetEase(Ease.Linear).SetId("remove");       
        Narration_Script.Instance.inputAllowed = true;        
        yield return new WaitForSeconds(1.6f);    
        StartCoroutine(NarrationEndSet());
    }
    IEnumerator IntroCut2() //배 안 휴게실에서
    {
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration2, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
    }


    IEnumerator Speech1()   //우리 음료수 뽑아먹자
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration3, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech2()   //그래 난 3프로 먹어야징
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration4, 1f).SetEase(Ease.Linear).SetId("remove");
        Characters_move[1].transform.DORotate(new Vector3(0, -90.0f, 0), 0.5f);
        Characters_ani[1].SetBool("actPickup", true);
       
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech3()   //나는 오성 사이다!
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));       
        yield return new WaitForSeconds(0.5f);
        Characters_ani[1].SetBool("actPickup", false);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration5, 1f).SetEase(Ease.Linear).SetId("remove");
        Characters_move[0].transform.DORotate(new Vector3(0, -90.0f, 0), 0.5f);
        Characters_ani[0].SetBool("actPickup", true);
        yield return new WaitForSeconds(2.0f);
        Characters_ani[0].SetBool("actPickup", false);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech4()   //꿀꺽꿀꺽
    {
        button.SetActive(false);
        Characters_ani[1].SetBool("actDrink", true);
        Characters_ani[0].SetBool("actDrink", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[0].transform.DORotate(new Vector3(0, 0f, 0), 1.0f);
        Characters_move[1].transform.DORotate(new Vector3(0, -180.0f, 0), 1.0f);      
        SpeechRepeatSet(tigerBox);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration6, 1f).SetEase(Ease.Linear).SetId("remove");        
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech5()   //꿀맛이다 크아
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration7, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);      
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
   
    IEnumerator Speech6() //쿠콰쾅
    {
        button.SetActive(false);
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("ship_earthquake"));
        narrationText.DOText(Narration_Script.Instance.Narration8, 1.5f).SetEase(Ease.Linear).SetId("remove");         
        yield return new WaitForSeconds(1.5f);        
        insideobjects[0].transform.DOMove(new Vector3(72.8f, 4.4f, -93.7f),2.0f);
        insideobjects[0].transform.DORotate(new Vector3(4.03755f, -43.67896f, 12.92103f), 2.0f);
        insideobjects[1].transform.DOMove(new Vector3(56.6f, 13.3f, -88.6f), 2.0f);
        insideobjects[1].transform.DORotate(new Vector3(-3.658478f, 130.862f, -3.581421f), 2.0f);
        insideobjects[2].transform.DOMove(new Vector3(45.6f, 1.200001f, -53.7f), 2.0f);
        insideobjects[2].transform.DORotate(new Vector3(-7.441162f, 71.65346f, 1.007572f), 2.0f);
        insideobjects[3].transform.DOMove(new Vector3(50f, 10.2f, -72.9f), 2.0f);
        insideobjects[3].transform.DORotate(new Vector3(0f, 90f, 0f), 1.0f);
        Characters_move[1].transform.DOMove(new Vector3(-25f, 12.7f, -41.8f), 1.0f);
        Characters_move[1].transform.DORotate(new Vector3(-2.668043e-08f,-178f, 12.93f), 1.0f);
        Characters_move[0].transform.DOMove(new Vector3(-29f, 5.9f, -58.9f), 1.0f);
        Characters_move[0].transform.DORotate(new Vector3(-6.670107e-09f, 0.4551976f, -14.98709f), 1.0f);
        yield return new WaitForSeconds(2.1f);
        // yield return new WaitForSeconds(1.6f);
        Characters_ani[1].SetBool("actDrink", false);
        Characters_ani[0].SetBool("actDrink", false);
        StartCoroutine(NarrationEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech7()   //뭐지..?
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration9, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech8() //쪼로록
    {
        button.SetActive(false);
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("water",true));
        narrationText.DOText(Narration_Script.Instance.Narration10, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);
        in_water.transform.DOMove(new Vector3(-2.7f, 74f, -6.9f), 30f);
        StartCoroutine(NarrationEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech9()   //서둘러!
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration11, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        Characters_ani[0].SetBool("actRun", true);
        Characters_ani[1].SetBool("actRun", true);
        Characters_move[1].transform.DORotate(new Vector3(-6.404991e-08f, 180f, -4.223738e-07f), 0.5f);
        Characters_move[0].transform.DORotate(new Vector3(7.689639e-26f, 180f, 2.001982e-23f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(2.5f, 5.8f, -44.1f), 0.5f);
        Characters_move[1].transform.DOMove(new Vector3(-10f, 5.8f, -44.8f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DORotate(new Vector3(1.999317e-23f, 87.03545f, -1.035393e-24f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(-4.158724e-07f, 85.39755f, 9.773542e-08f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(48f, 19.3f, -41.7f), 1.0f);
        Characters_move[1].transform.DOMove(new Vector3(46f, 5.8f, -40.3f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        Characters_move[0].transform.DORotate(new Vector3(-8.247375e-25f, 0f, 0f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(5.693453e-08f, 0f, 0f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(48f, 19.3f, -25.9f), 0.5f);
        Characters_move[1].transform.DOMove(new Vector3(48f, 19.3f, -25.9f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DORotate(new Vector3(-1.996475e-23f, -90f, 1.485804e-24f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(4.177447e-07f, -90f, -8.939526e-08f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(14.5f, 36.8f, -27f), 1.0f);
        Characters_move[1].transform.DOMove(new Vector3(14.5f, 36.8f, -27f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech10()   //거의 다왔어!
    {
        button.SetActive(false);
        Characters_move[0].transform.DORotate(new Vector3(9.586112e-25f, 180f, 1.9997e-23f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(-8.357119e-08f, 180f, -4.189488e-07f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(14.6f, 36.6f, -43.3f), 0.5f);
        Characters_move[1].transform.DOMove(new Vector3(14.6f, 36.6f, -43.3f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DORotate(new Vector3(1.999812e-23f, 87.03545f, -9.350934e-25f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(-4.151812e-07f, 87.03545f, 1.006316e-07f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(50.1f, 51.6f, -43.1f), 1.0f);
        Characters_move[1].transform.DOMove(new Vector3(50.1f, 51.6f, -43.1f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        Characters_move[0].transform.DORotate(new Vector3(-5.432118e-25f, 0f, 0f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(7.245016e-08f, 0f, 0f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(50.3f, 51.6f, -27.7f), 0.5f);
        Characters_move[1].transform.DOMove(new Vector3(50.3f, 51.6f, -27.7f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DORotate(new Vector3(-1.977609e-23f, -90f, 3.115357e-24f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(4.229423e-07f, -90f, -6.018429e-08f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(27.46f, 69.58f, -30.32f), 1.0f);
        Characters_move[1].transform.DOMove(new Vector3(27.46f, 69.58f, -30.32f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration12, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);              
        Characters_move[0].SetActive(false);
        Characters_move[1].SetActive(false);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech11()   //겨우 빠져나왔다..
    {
        StartCoroutine(SoundManager._instance.StopSE("water"));
        button.SetActive(false);
        fade.DOFade(1.0f, 0.5f).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        Ship1.SetActive(false);
        in_water.SetActive(false);

        out_water.SetActive(true);
        outside_ship.SetActive(true);

        fade.DOFade(0.0f, 0.5f).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration13, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech12()   //근데 구명조끼 안에서 입으면 안되는거야?
    {
        button.SetActive(false);              
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration14, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech13()   //응 안에서 입기에는 위급시에 시간이 부족할 수 있거든
    {
        button.SetActive(false);      
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration15, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech14()   //이제 입자
    {
        Characters_ani[2].SetBool("actWear", true);
        Characters_ani[3].SetBool("actWear", true);
        button.SetActive(false);        
        SpeechRepeatSet(sharkBox);
        yield return new WaitForSeconds(0.5f);        
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration16, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        Characters_ani[2].SetBool("actWear", false);
        Characters_ani[3].SetBool("actWear", false);
        outpickJacket[0].SetActive(false);
        outpickJacket[1].SetActive(false);
        out_Jacket[0].SetActive(true);
        out_Jacket[1].SetActive(true);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech15()   //이제 어떡하지?
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration17, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator Speech16()   //뛰어야해
    {
        button.SetActive(false);
        Characters_ani[2].SetBool("actRun", false);
        Characters_ani[3].SetBool("actRun", false);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration18, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech17()   //뛰어야해
    {
        button.SetActive(false);
      
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        Characters_move[2].transform.DOMove(new Vector3(-3f, 2.1f, -96.5f), 2.0f); 
        Characters_move[3].transform.DOMove(new Vector3(10.4f, 3.4f, -90.2f), 2.0f);       
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration21, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech18()   //뛰어야해
    {
        button.SetActive(false);
   
        lifeship.SetActive(true);
        StartCoroutine(SoundManager._instance.Play_SE("ship_carklaxon",false));
        lifeship.transform.DOMove(new Vector3(-33.2f, 5f, -99.2f), 3.0f);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);             
        speechText.DOText(Narration_Script.Instance.Narration22, 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator select01()  //선택하는 박스가 일단 등장.(텍스도 다 있음)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
       
        //다른 것들 다 비활성화를 시켜준다.    
        sTigerBox.SetActive(true);
        sSharkBox.SetActive(false);
        Narration_Script.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));       
        selectableBox.SetActive(true);
        lastSpeechText.text = Narration_Script.Instance.Narration_Event;
        selectBox[0].text = Narration_Script.Instance.Alarm[0];
        selectBox[1].text = Narration_Script.Instance.Alarm[1];
        selectBox[2].text = Narration_Script.Instance.Alarm[2];

        selectableBox.transform.localScale = new Vector3(0, 0, 0);  //크기를 0으로 해준다.
        selectableBox.transform.DOScale(selectBoxSize, 0.2f).SetId("remove");
        yield return new WaitForSeconds(0.2f);

        selectableBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetId("remove");
        _statusCompleted = true;
    }

    IEnumerator select02()  //선택하는 박스가 일단 등장.(텍스도 다 있음)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);

        //다른 것들 다 비활성화를 시켜준다.    
        sTigerBox.SetActive(true);
        sSharkBox.SetActive(false);
        Narration_Script.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));
        selectableBox.SetActive(true);
        lastSpeechText.text = Narration_Script.Instance.Narration17;
        selectBox[0].text = Narration_Script.Instance.Alarm[3];
        selectBox[1].text = Narration_Script.Instance.Alarm[4];
        selectBox[2].text = Narration_Script.Instance.Alarm[5];

        selectableBox.transform.localScale = new Vector3(0, 0, 0);  //크기를 0으로 해준다.
        selectableBox.transform.DOScale(selectBoxSize, 0.2f).SetId("remove");
        yield return new WaitForSeconds(0.2f);

        selectableBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetId("remove");
        _statusCompleted = true;
    }

    IEnumerator select03()  //선택하는 박스가 일단 등장.(텍스도 다 있음)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);

        //다른 것들 다 비활성화를 시켜준다.    
        sTigerBox.SetActive(true);
        sSharkBox.SetActive(false);
        Narration_Script.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));
        selectableBox.SetActive(true);
        lastSpeechText.text = Narration_Script.Instance.Narration19;
        selectBox[0].text = Narration_Script.Instance.Alarm[6];
        selectBox[1].text = Narration_Script.Instance.Alarm[7];
        selectBox[2].text = Narration_Script.Instance.Alarm[8];

        selectableBox.transform.localScale = new Vector3(0, 0, 0);  //크기를 0으로 해준다.
        selectableBox.transform.DOScale(selectBoxSize, 0.2f).SetId("remove");
        yield return new WaitForSeconds(0.2f);

        selectableBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetId("remove");
        _statusCompleted = true;
    }

    IEnumerator SelectSpeech1(int selectNumber) //선택한 말이 노출된다.
    {
        button.SetActive(false);
        selectNumber = this.selectNumber;
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        speechText.DOText(Narration_Script.Instance.Alarm[selectNumber], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }

    IEnumerator SelectSpeech2(int selectNumber) //선택한 말이 노출된다.
    {
        button.SetActive(false);
        selectNumber = this.selectNumber;
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        if(selectNumber == 0) { 
        speechText.DOText(Narration_Script.Instance.Alarm[3], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }
        if (selectNumber == 1)
        {
            speechText.DOText(Narration_Script.Instance.Alarm[4], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }

        if (selectNumber == 2)
        {
            speechText.DOText(Narration_Script.Instance.Alarm[5], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }
    IEnumerator SelectSpeech3(int selectNumber) //선택한 말이 노출된다.
    {
        button.SetActive(false);
        selectNumber = this.selectNumber;
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        if (selectNumber == 0)
        {
            speechText.DOText(Narration_Script.Instance.Alarm[6], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }
        if (selectNumber == 1)
        {
            speechText.DOText(Narration_Script.Instance.Alarm[7], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }

        if (selectNumber == 2)
        {
            speechText.DOText(Narration_Script.Instance.Alarm[8], 1.5f).SetEase(Ease.Linear).SetId("remove");
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }

    IEnumerator GoodAct01_2() //구명조끼 챙겨서 바로 밖으로
    {
        button.SetActive(false);
        Characters_move[0].transform.DORotate(new Vector3(-1.500774e-08f, -4.969617e-17f, 0f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(2.65527e-08f, 7.548878f, 2.607567e-09f), 0.5f);
        Characters_ani[0].SetBool("actRun", true);
        Characters_ani[1].SetBool("actRun", true);
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DOMove(new Vector3(0.9f, 5.9f, -24.5f), 2.3f);
        Characters_move[1].transform.DOMove(new Vector3(-12.2f, 5.9f, -25.5f), 2.3f);
        yield return new WaitForSeconds(2.0f);
        Characters_ani[0].SetBool("actRun", false);
        Characters_ani[1].SetBool("actRun", false);
        yield return new WaitForSeconds(0.1f);
        Characters_ani[0].SetBool("actPickup", true);
        Characters_ani[1].SetBool("actPickup", true);
        yield return new WaitForSeconds(1.0f);
        in_jacket[0].SetActive(false);
        in_jacket[1].SetActive(false);
        Characters_ani[0].SetBool("actPickup", false);
        Characters_ani[1].SetBool("actPickup", false);
        yield return new WaitForSeconds(0.2f);
        tiger_pick_Jacket.SetActive(true);
        shark_pick_Jacket.SetActive(true);
        button.SetActive(true);

        status++;
        PlayStory(status);
    }
    IEnumerator GoodAct02_1() //비상구로 이동
    {
        button.SetActive(false);
        Characters_ani[2].SetBool("actRun", true);
        Characters_ani[3].SetBool("actRun", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DORotate(new Vector3(0f, 95.65345f, 0f), 0.5f);
        Characters_move[3].transform.DORotate(new Vector3(0f, 95.65345f, 0f), 0.5f);

        Characters_move[2].transform.DOMove(new Vector3(-37.2f, 50.80001f, -34.4f), 2.0f);        
        Characters_move[3].transform.DOMove(new Vector3(-39.5f, 50.80001f, -28.9f), 2.5f);
        yield return new WaitForSeconds(2.0f);
        Characters_move[2].transform.DOMove(new Vector3(-28.58f, 55.22f, -35.27f), 1.0f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[3].transform.DOMove(new Vector3(-28.58f, 55.22f, -35.27f), 1.3f);
        yield return new WaitForSeconds(0.5f);
        Characters_move[2].transform.DOMove(new Vector3(-21.7f, 50.01f, -36f), 1.0f);
        yield return new WaitForSeconds(0.3f);
        Characters_move[3].transform.DOMove(new Vector3(-21.7f, 50.01f, -36f), 1.3f);
        yield return new WaitForSeconds(0.7f);

        Characters_move[2].transform.DOMove(new Vector3(-2.7f, 50.01f, -36.4f), 1.0f);
        Characters_move[3].transform.DOMove(new Vector3(2.5f, 50.01f, -40.2f), 1.3f);
        yield return new WaitForSeconds(1.0f);

        Characters_move[2].transform.DORotate(new Vector3(0f, 175.8775f, 0f), 0.5f);
        yield return new WaitForSeconds(0.3f);
        Characters_move[3].transform.DORotate(new Vector3(0f, 175.8775f, 0f), 0.5f);
        yield return new WaitForSeconds(0.2f);       
      

        Characters_move[2].transform.DOMove(new Vector3(-1.12f, 50.01f, -59.58f), 1.0f);
        yield return new WaitForSeconds(0.3f);
        Characters_move[3].transform.DOMove(new Vector3(9.5f, 50.01f, -58.8f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }

    IEnumerator GoodAct03_0() //주변을 살피고 잘 뛰어내리자
    {
        button.SetActive(false);
      //  Characters_ani[2].SetBool("actFall", true);
       // Characters_ani[3].SetBool("actFall", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-3.7f, 65.7f, -66.2f), 2.0f);      
        Characters_move[3].transform.DOMove(new Vector3(7.6f, 65.7f, -73f), 2.0f);    

        yield return new WaitForSeconds(2.0f);

        Characters_move[2].transform.DOMove(new Vector3(-3f, -5.2f, -96.2f), 2.0f);
        Characters_move[3].transform.DOMove(new Vector3(5.1f, -5.2f, -86.7f), 2.0f);

        yield return new WaitForSeconds(2.0f);

        button.SetActive(true);
        status++;
        PlayStory(status);
    }


    IEnumerator WrongAct01_0() //자리로 돌아가자
    {
        button.SetActive(false);
        Characters_move[1].transform.DORotate(new Vector3(2.068406e-10f, 7.104215f, 2.577881e-11f), 0.5f);
        Characters_ani[0].SetBool("actRun", true);
        Characters_ani[1].SetBool("actRun", true);
        yield return new WaitForSeconds(0.5f);
        Characters_move[1].transform.DOMove(new Vector3(-18.9f, 6.8f, 34.8f), 2.5f);
        Characters_move[0].transform.DOMove(new Vector3(-18.8f, 13.8f, 12.4f), 2.5f);
        yield return new WaitForSeconds(2.5f);
        Characters_ani[0].SetBool("actRun", false);
        Characters_ani[1].SetBool("actRun", false);
        yield return new WaitForSeconds(0.3f);
        Characters_move[1].transform.DOMove(new Vector3(-8.7f, 8.6f, 37f), 0.5f);
        Characters_move[0].transform.DOMove(new Vector3(-7.5f, 8.6f, 12.2f), 0.5f);
        yield return new WaitForSeconds(0.7f);

        button.SetActive(true);

        status++;
        PlayStory(status);
    }

    IEnumerator WrongAct01_1() //구명조끼 바로 입자
    {
        button.SetActive(false);       
        yield return new WaitForSeconds(0.5f);
        Characters_move[0].transform.DORotate(new Vector3(-1.500774e-08f, -4.969617e-17f, 0f), 0.5f);
        Characters_move[1].transform.DORotate(new Vector3(2.65527e-08f, 7.548878f, 2.607567e-09f), 0.5f);
        Characters_ani[0].SetBool("actRun", true);
        Characters_ani[1].SetBool("actRun", true);
        yield return new WaitForSeconds(0.5f);      
        Characters_move[0].transform.DOMove(new Vector3(0.9f, 5.9f, -24.5f), 2.3f);        
        Characters_move[1].transform.DOMove(new Vector3(-12.2f, 5.9f, -25.5f), 2.3f);
        yield return new WaitForSeconds(2.0f);
        Characters_ani[0].SetBool("actRun", false);
        Characters_ani[1].SetBool("actRun", false);
        yield return new WaitForSeconds(0.1f);
        Characters_ani[0].SetBool("actPickup", true);
        Characters_ani[1].SetBool("actPickup", true);
        yield return new WaitForSeconds(1.0f);
        in_jacket[0].SetActive(false);
        in_jacket[1].SetActive(false);
        Characters_ani[0].SetBool("actPickup", false);
        Characters_ani[1].SetBool("actPickup", false);
        yield return new WaitForSeconds(0.2f);
        tiger_Jacket.SetActive(true);
        shark_jacket.SetActive(true);      
        button.SetActive(true);

        status++;
        PlayStory(status);
    }

    IEnumerator WrongAct02_0() //배에서 기다리자
    {
        button.SetActive(false);
        outside_ship.transform.DORotate(new Vector3(-27.45169f, 90f, -90f), 3.0f);
        yield return new WaitForSeconds(3.2f);
        StartCoroutine(SoundManager._instance.Play_SE("suicide"));
        outside_ship.transform.DOMove(new Vector3(63.1f, -84.9f, -13.3f), 3.0f);
        Characters_move[2].transform.DOMove(new Vector3(126.2109f, -37.6942f, -34.72001f), 4.0f);
        Characters_move[3].transform.DOMove(new Vector3(129.3791f, -35.65063f, -28.52f), 4.0f);
        yield return new WaitForSeconds(4.0f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }

    IEnumerator WrongAct02_2() //도구를 찾자
    {
        button.SetActive(false);
        Characters_ani[2].SetBool("actRun", true);
        Characters_ani[3].SetBool("actRun", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-39.1f, 50.36002f, -36.3f), 2.0f);
        Characters_move[2].transform.DORotate(new Vector3(0f, 84.93167f, 0f), 1.0f);

        Characters_move[3].transform.DOMove(new Vector3(-48.1f, 55.10004f, 3.6f), 2.0f);
        Characters_move[3].transform.DORotate(new Vector3(0f, 23.89004f, 0f), 1.0f);

        yield return new WaitForSeconds(2.0f);
        Characters_move[2].transform.DOMove(new Vector3(-28f, 55f, -35.3f), 1.0f);
        Characters_move[3].transform.DOMove(new Vector3(-72.9f, 55.44f, 10.9f), 1.5f);
        yield return new WaitForSeconds(1.5f);
        Characters_move[3].transform.DORotate(new Vector3(0f, -3.883942f, 0f), 1.0f);
        Characters_move[3].transform.DOMove(new Vector3(-76.1f, 55.44f, 15f), 1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-19.7f, 50.8f, -34.6f), 1.0f);

        yield return new WaitForSeconds(1.0f);

        outside_ship.transform.DORotate(new Vector3(-27.45169f, 90f, -90f), 3.0f);

        yield return new WaitForSeconds(3.5f);
        StartCoroutine(SoundManager._instance.Play_SE("suicide"));
        outside_ship.transform.DOMove(new Vector3(63.1f, -84.9f, -13.3f), 3.0f);

        Characters_move[2].transform.DOMove(new Vector3(126.2109f, -37.6942f, -34.72001f), 4.0f);
        Characters_move[3].transform.DOMove(new Vector3(129.3791f, -35.65063f, -28.52f), 4.0f);
        yield return new WaitForSeconds(4.0f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }
    IEnumerator WrongAct03_1() //머리로 뛰어내리자
    {
        button.SetActive(false);
        Characters_ani[2].SetBool("actFall", true);
        Characters_ani[3].SetBool("actFall", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-3.7f, 55.7f, -66.2f), 2.0f);
        Characters_move[2].transform.DORotate(new Vector3(89.66839f, -1.351898f, -179.9993f), 1.0f);
        Characters_move[3].transform.DOMove(new Vector3(7.6f, 59.7f, -73f), 2.0f);
        Characters_move[3].transform.DORotate(new Vector3(66.0069f, 1f, 180f), 1.0f);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DORotate(new Vector3(28.66663f, -1.3526f, 180f), 1.0f);        
        Characters_move[3].transform.DORotate(new Vector3(12.11784f, 1f, 180f), 1.0f);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-3f, -5.2f, -96.2f), 2.0f);
        Characters_move[3].transform.DOMove(new Vector3(5.1f, -5.2f, -86.7f), 2.0f);
        yield return new WaitForSeconds(2.0f);
        
        button.SetActive(true);
        status++;
        PlayStory(status);
    }

    IEnumerator WrongAct03_2() //배치기
    {
        button.SetActive(false);
        Characters_ani[2].SetBool("actFall", true);
        Characters_ani[3].SetBool("actFall", true);
        yield return new WaitForSeconds(1.0f);
        Characters_move[2].transform.DOMove(new Vector3(-3.7f, 55.7f, -66.2f), 2.0f);
        Characters_move[2].transform.DORotate(new Vector3(90f, 180f, 0f), 2.0f);

        Characters_move[3].transform.DOMove(new Vector3(7.6f, 59.7f, -73f), 2.0f);
        Characters_move[3].transform.DORotate(new Vector3(90f, 180f, 0f), 2.0f);

        yield return new WaitForSeconds(2.0f);

        Characters_move[2].transform.DOMove(new Vector3(-3f, -5.2f, -96.2f), 2.0f);
        Characters_move[3].transform.DOMove(new Vector3(5.1f, -5.2f, -86.7f), 2.0f);

        yield return new WaitForSeconds(2.0f);

        button.SetActive(true);
        status++;
        PlayStory(status);
    }




    IEnumerator WrongSpeech01_1()
    {
        button.SetActive(false);      
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[0], 1.5f).SetEase(Ease.Linear).SetId("remove");      
        yield return new WaitForSeconds(1.5f);       
        Characters_move[0].transform.DORotate(new Vector3(87.53971f, -4.969624e-17f, -3.449966e-23f), 1.0f).SetEase(Ease.Linear);
        Characters_move[1].transform.DORotate(new Vector3(87.63148f, 177.2753f, 180f), 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        Characters_move[0].transform.DOMove(new Vector3(0.6f, 32.3f, -40.1f), 2.0f).SetEase(Ease.Linear);
        Characters_move[1].transform.DOMove(new Vector3(-16.9f, 34.5f, -40.4f), 2.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
     
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator WrongSpeech01_1_2()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));     
        speechText.DOText(Narration_Script.Instance.ship[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        StartCoroutine(SoundManager._instance.Play_SE("water_choke"));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("choke"));
        yield return new WaitForSeconds(1.5f);         
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
        StartCoroutine(SoundManager._instance.StopSE("water"));
    }
    IEnumerator WrongSpeech01_0()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[1], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);
        Characters_move[1].transform.DORotate(new Vector3(78.70489f, -4.969624e-17f, -6.049366e-23f), 1.0f).SetEase(Ease.Linear);
        Characters_move[0].transform.DORotate(new Vector3(77.79195f, -172.8958f, 180f), 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.0f);
        Characters_move[0].transform.DOMove(new Vector3(-7.5f, 33.3f, 12.2f), 2.0f).SetEase(Ease.Linear);
        Characters_move[1].transform.DOMove(new Vector3(-8.7f, 33.79f, 31.97f), 2.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
      
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator WrongSpeech01_0_2()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        speechText.DOText(Narration_Script.Instance.ship[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        StartCoroutine(SoundManager._instance.Play_SE("water_choke"));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("choke"));
        yield return new WaitForSeconds(1.5f);       
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
        StartCoroutine(SoundManager._instance.StopSE("water"));
    }

    IEnumerator WrongSpeech02_0()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[2], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);
      
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

  
    IEnumerator WrongSpeech02_2()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[2], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator WrongSpeech03_1()
    {
        Characters_ani[2].SetBool("actFall", false);
        Characters_ani[3].SetBool("actFall", false);
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[3], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);

        Characters_move[2].transform.DOMove(new Vector3(-3f, 3.4f, -96.5f), 2.0f);
        Characters_move[2].transform.DORotate(new Vector3(-78.68204f, 178.6474f, -5.43794e-07f), 2.0f);

        Characters_move[3].transform.DOMove(new Vector3(10.4f, 3.4f, -90.2f), 2.0f);
        Characters_move[3].transform.DORotate(new Vector3(-73.41156f, -169.6936f, 4.485755e-06f), 2.0f);
        yield return new WaitForSeconds(2.0f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }


    IEnumerator WrongSpeech03_2()
    {
        Characters_ani[2].SetBool("actFall", false);
        Characters_ani[3].SetBool("actFall", false);
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(Narration_Script.Instance.shipFail[3], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.5f);

        Characters_move[2].transform.DOMove(new Vector3(-3f, 3.4f, -96.5f), 2.0f);
        Characters_move[2].transform.DORotate(new Vector3(90f, 180f, 0f), 2.0f);

        Characters_move[3].transform.DOMove(new Vector3(10.4f, 3.4f, -90.2f), 2.0f);
        Characters_move[3].transform.DORotate(new Vector3(90f, 180f, 0f), 2.0f);
        yield return new WaitForSeconds(2.0f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator GoodEnd()  // "그렇게 두 친구와 모든 학급 친구들이 무사히 탈출" };
    {
        endBox = true;
        NarrationStartSet();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration_Event2, 1.5f).SetEase(Ease.Linear).SetId("remove");
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missioncomplete", false));
        StartCoroutine(NarrationEndSet()); //대화가 다 나왔을때 실행된다.}
    }

    IEnumerator Wrongend01()
    {
        endBox = true;
        tigerBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration_End1, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure", false));
        StartCoroutine(NarrationEndSet());
        // SceneManager.LoadScene("classroomOnEarthquake");

    }
    IEnumerator Wrongend02()
    {
        endBox = true;
        tigerBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration_End2, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure", false));
        StartCoroutine(NarrationEndSet());
        // SceneManager.LoadScene("classroomOnEarthquake");

    }

    IEnumerator Wrongend03()
    {
        endBox = true;
        tigerBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration_End3, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure", false));
        StartCoroutine(NarrationEndSet());
        // SceneManager.LoadScene("classroomOnEarthquake");

    }

    IEnumerator Wrongend04()
    {
        endBox = true;
        tigerBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Narration_End4, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure", false));
        StartCoroutine(NarrationEndSet());
        // SceneManager.LoadScene("classroomOnEarthquake");

    }
    IEnumerator SpeechEndSet()
    {
        // _statusCompleted = true;
       
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);

    }

    void NarrationStartSet()
    {
       
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        selectableBox.SetActive(false);
        narrationBox.SetActive(true);
        narrationText.text = "";
    }


    IEnumerator NarrationEndSet()
    {       // _statusCompleted = true;    //대화가 다 나온상태라는 것.
        yield return new WaitForSeconds(2f);      
        CompleteAnimation(status);
    }

    IEnumerator SpeechStartSet(GameObject characterBox)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);       
        selectableBox.SetActive(false);
        // fireSpeechBox.SetActive(false);

        Narration_Script.Instance.inputAllowed = false;

        speechBox.SetActive(true);
        speechBox.transform.localScale = new Vector3(0, 0, 0);
        speechText.text = "";
        speechBox.transform.DOScale(speechBoxSize, 0.2f).SetId("remove");

        characterBox.SetActive(true);
        characterBox.transform.localScale = new Vector3(0, 0, 0);
        if (characterBox == tigerBox)
            characterBox.transform.DOScale(tigerBoxSize, 0.2f).SetId("remove");
        //0.2초 동안 tigerBox크기로 바꾼다.
        else if (characterBox == sharkBox)
            characterBox.transform.DOScale(sharkBoxSize, 0.2f).SetId("remove");
        else
            characterBox.transform.DOScale(teacherBoxSize, 0.2f).SetId("remove");
        yield return new WaitForSeconds(0.2f);
        speechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetId("remove");
        //띠용~ 같은 느낌
        characterBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetId("remove");
        yield return new WaitForSeconds(0.3f);
        Narration_Script.Instance.inputAllowed = true;
    }
    public void SelectButton(int selectNumber)  //버튼을 눌렀을때 실행되는 함수
    {
        StartCoroutine(SoundManager._instance.Play_SE("question")); // 선택음
        //SelectSpeech1(selectNumber);
        this.selectNumber = selectNumber;
        status++;
        PlayStory(status);
    }
    void SpeechRepeatSet(GameObject characterBox)   //2번 이상 말할 때
    {
        speechBox.SetActive(true);
        speechText.text = "";

        characterBox.SetActive(true);
    }
    void CutChange()
    {
        StopAllCoroutines();

        _statusCompleted = false;

        nextButton.SetActive(false);

        narrationText.text = "";
        narrationBox.SetActive(false);
    }
    public void TrackedOut()
    {
        CutChange();

        DOTween.KillAll();  //실행되는 DoTween 모두 없애준다.
    }

    public void GameoverBox(int number)    //다시 처음부터
    {

        if (number == 0)
        { //다른문제
            fade.DOFade(1, 0.5f).OnComplete(MainScene).SetId("remove");
        }
        else
        {//처음부터
            fade.DOFade(1, 0.5f).OnComplete(StartScene).SetId("remove");
        }
        wrongEndBox.SetActive(false);
        endingBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        speechBox.SetActive(false);
        narrationBox.SetActive(false);
        fade.DOFade(0, 0.5f).SetId("remove");
        endBox = false;
        //_statusCompleted = false;
        _sceneFinished = false;
    }

    public void FinshBox(bool _main)    //완료 여기서부터 다시
    {
        if (_main)  //다른문재
            fade.DOFade(1, 0.5f).OnComplete(MainScene).SetId("remove");
        else//다시
            fade.DOFade(1, 0.5f).OnComplete(StartScene).SetId("remove");

        endingBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        speechBox.SetActive(false);
        narrationBox.SetActive(false);
        endBox = false;
    }

    void MainScene()//다음문제
    {
        SceneManager.LoadScene(0);
    }

    void StartScene() //처음부터
    {
        SceneManager.LoadScene("Ship_Escape");  //씬에서 나갔다 다시 오면 초기화되있음.
    }
      

    IEnumerator FinishScene()
    {
        fade.DOFade(1.0f, 1.0f);
        yield return new WaitForSeconds(1.0f);//어두워짐
        SceneManager.LoadScene("0");
    }

    public void GoHome()
    {
        fade.DOFade(1.0f, 0.4f);
        SceneManager.LoadScene(0);
    }

    public void otherProblem()
    {
        fade.DOFade(1.0f, 0.4f);
        SceneManager.LoadScene("ARTarget");
    }

       
}
