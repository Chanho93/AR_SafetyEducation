using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ClassroomSceneController2 : MonoBehaviour
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
  //  public GameObject fireSpeechBox;
   // public Text fireSpeechText;
    public Text[] selectBox = new Text[3];
    public GameObject tigerBox;
    public GameObject sharkBox;
    public GameObject teacherBox;

    public GameObject sTeacherBox;
    public GameObject sTigerBox;
    public GameObject sSharkBox;

    public GameObject selectableBox;
    public Text lastSpeechText;

    //장소
    public GameObject classroom;
    public GameObject outside;

    //상태
    public GameObject sleep;
    public int cnt = 0;
    public GameObject wrongEndBox;
    public GameObject endingBox;
    //물체
    public GameObject[] objects;
    public GameObject IPhone;
    public GameObject IPhoneFader;
    public Image IPhoneFaderAlpha;
    public GameObject ClassroomSet;

  

    //애니메이션
    public Animator[] characters;


    //지속
    public static int status;

    void Awake()
    {
        speechBoxSize = speechBox.transform.localScale;
        tigerBoxSize = tigerBox.transform.localScale;
        sharkBoxSize = sharkBox.transform.localScale;
        teacherBoxSize = teacherBox.transform.localScale;
        selectBoxSize = selectableBox.transform.localScale;
       
        status = 0;
       
    }

    void Update()
    {
        if (cnt == 15)
         objects_move1();
         objects_move2();
        

        
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
                StartCoroutine(IntroCut());  //"화창한 봄날 5교시.."
                break;
            case 1:
                StartCoroutine(IntroCut2()); //수업시간중...
                break;
            case 2:
                StartCoroutine(Speech1());   //루트 a가 b라면..c는 무엇인가? 
                break;
            case 3:
                StartCoroutine(Speech2());   // 호돌이 : 으아 저게 뭔소리여.."
                break;
            case 4:
                StartCoroutine(Speech3());   // 호돌이 : 수학은 너무 어려웡 
                break;
            case 5:
                StartCoroutine(Speech4());   // 호돌이 : 야 어제 축구 봤냐?
                break;
            case 6:
                StartCoroutine(Speech5());   //봤지 리버풀이 이겼다!"
                break;
            case 7:
                GameManager1.Instance.inputAllowed = true;
                StartCoroutine(earthquake());     //쿠쿠쿵쿵!
                break;
            case 8:
                StartCoroutine(Speech6());   //여러분 지진인가봐요!  저번에 배운 행동대피 요령대로 행동해요!"
                break;
            case 9:
                StartCoroutine(select01()); //select화면이 노출된다.
                break;
            case 10:
                StartCoroutine(SelectSpeech1(selectNumber));    //select한 텍스타가 화면이 노출된다.
                break;
            case 11:
                if (selectNumber == 0)  //정답인 경우
                {
                    StartCoroutine(GoodAct01());  //책상밑으로 숨는다.
                }
                else if(selectNumber == 1) //아닌경우
                {
                    StartCoroutine(Wrong01()); //뛰쳐나간다.
                }
                else if(selectNumber == 2)
                {
                    StartCoroutine(Wrong01_2());//제자리에서 대기
                }
                break;
            case 12:
                if(selectNumber == 0)
                {
                    StartCoroutine(Speech7()); //"썜 이제 어케해요?
                }


                if(selectNumber == 1)
                {
                    StartCoroutine(WrongSpeech01());  //어..어어!!쿵
                }
                if(selectNumber == 2)
                {
                    StartCoroutine(WrongSpeech01_2()); // 어..어어 퍽! 으악
                }
                break;
            case 13:
                if(selectNumber == 0)
                {
                    StartCoroutine(select02());   // 선택지
                }

                if (selectNumber == 1)
                {
                    StartCoroutine(Wrongend01());  //그렇게 두친구는 하늘나라로 가게 되었습니다.
                }
                if (selectNumber == 2)
                {
                    StartCoroutine(Wrongend02());  //호빵이만 하늘나라로 가게 되었습니다.
                }
                break;
            case 14:
                
                StartCoroutine(SelectSpeech2(selectNumber)); //선택지 질문이 나타남
                break;
            case 15:
                if(selectNumber == 0)
                {
                    GameManager1.Instance.inputAllowed = false;
                    StartCoroutine(Wrong02_1());          //다시 수업 시작할때
                }
                if(selectNumber == 1)
                {
                    GameManager1.Instance.inputAllowed = false; // 전화하는 장면
                    StartCoroutine(ToPhone());
                }
                if(selectNumber == 2)
                {
                    StartCoroutine(GoodAct02());   //복도로 대피
                }
                break;
           
            case 16:
                if (selectNumber == 0)
                {
                    StartCoroutine(WrongSpeech02_1());   //퍽..으악!
                }
                if (selectNumber == 2)            // 교실에 있으면 위험할뻔했따.
                {
                    StartCoroutine(Speech9());
                }
               
                break;

            case 17:

                if (selectNumber == 0)
                {
                    StartCoroutine(Wrongend02());    //결국 하늘나라로
                }
                if (selectNumber == 1)
                {
                    StartCoroutine(Wrongend01());       //결국 하늘나라로
                }
                   if (selectNumber == 2)
                {
                  
                    StartCoroutine(Speech10());   //복도로 나감
                }
                break;
            case 18:
                StartCoroutine(Speech8());             //이제 어디로가지?
                break;

            case 19:
                StartCoroutine(select03());        //선택지
                break;
            case 20:
                StartCoroutine(SelectSpeech3(selectNumber));      //선택지 노출
                break;
            case 21:
                if(selectNumber == 0)
                {
                    StartCoroutine(Wrong03());            //다른반
                }
                if(selectNumber == 1)
                {
                    StartCoroutine(GoodAct03());                   //운동장으로 대피!
                }
                if(selectNumber == 2)
                {
                    StartCoroutine(Wrong03_2());        //옥상
                }
                break;
            case 22:
                if (selectNumber == 0)
                {
                    StartCoroutine(WrongSpeech03_1());

                }
                if(selectNumber == 1)
                {
                    StartCoroutine(GoodEnd());
                }
                if (selectNumber == 2)
                {
                    StartCoroutine(WrongSpeech03_2());
                }
                break;
            case 23:
                if (selectNumber == 0)
                {
                    StartCoroutine(Wrongend01());
                }
                if (selectNumber == 2)
                {
                    StartCoroutine(Wrongend01());
                }
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
                narrationText.text = GameManager1.Instance.lines1[0];    //"어느 때처럼 평범한 목요일...",
                break;
            case 1:
                narrationBox.SetActive(true);
                narrationText.text = GameManager1.Instance.lines1[1];    //"점심시간이 지난 오후 수업이었다.",
                break;
            case 2:
                speechBox.SetActive(true);
                teacherBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.lines1[2];   //"오늘은 저번 시간에 이어서 태조왕건의 두 번째 정..채..ㄱ..으...", //1
                break;
            case 3:
                teacherBox.SetActive(false);
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.lines1[3];   //"하암(하품) 하.. 졸려 제일 싫어하는 한국사 수업이네.. ",  //2
                break;
            case 4:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.lines1[4];   //"하필 제일 졸린 점심시간 다음이냐.. 어휴 아픈척하고 잠이나 자야지", //3
                break;
            case 5:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.lines1[5];   //"야 샹크스 너 필기한 거 나중에 보여주라 난 잔다.", //4
                break;
            case 6:
                speechBox.SetActive(true);
                tigerBox.SetActive(false);
                sharkBox.SetActive(true);
                speechText.text = GameManager1.Instance.lines1[6];   //"그만 좀 베껴라. 에휴",  //5
                break;
            case 7:
                narrationBox.SetActive(true);
                narrationText.text = GameManager1.Instance.earthquake[0];
                break;
            case 8:
                speechBox.SetActive(true);
                teacherBox.SetActive(true);
                speechText.text = GameManager1.Instance.lines1[7];
                break;
            case 9:
                break;
            case 10:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.selectableLines1[selectNumber];    //선택한 텍스트 출력
                break;
            case 11:
                break;
            case 12:
                if (selectNumber == 0)
                {
                    speechBox.SetActive(true);
                    tigerBox.SetActive(false);
                    sharkBox.SetActive(true);
                    speechText.text = GameManager1.Instance.lines1[8];
                }
                    if (selectNumber == 1) {
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    sharkBox.SetActive(false);
                    speechText.text = GameManager1.Instance.resultLines3_1;
                }
                else if (selectNumber == 2)
                {
                    speechBox.SetActive(true);
                    tigerBox.SetActive(true);
                    sharkBox.SetActive(false);
                    speechText.text = GameManager1.Instance.WrongScream[0];
                }


               
                break;
            case 13:
              
                if(selectNumber == 1 ) {
                    sTeacherBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = GameManager1.Instance.resultLines3_2;    //두친구는 하늘나라로..
                }
                else if(
                       selectNumber == 2)
                    {
                        sTeacherBox.SetActive(false);
                        narrationBox.SetActive(true);
                        narrationText.text = GameManager1.Instance.lines3[0];    //두친구는 하늘나라로..
                    }
                break;
            case 14:
                speechBox.SetActive(true);
                tigerBox.SetActive(false);
                sharkBox.SetActive(false);
                teacherBox.SetActive(true);

                speechText.text = GameManager1.Instance.selectableLines2[selectNumber];
                break;
            case 15:
                if (selectNumber == 1)
                {
                    sTeacherBox.SetActive(false);
                    teacherBox.SetActive(false);
                }
                    break;

          
            case 16:
                if(selectNumber == 0) { 
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                teacherBox.SetActive(false);
                speechText.text = GameManager1.Instance.WrongScream[0];
                }
                break;
            case 17:
                sTeacherBox.SetActive(false);
                teacherBox.SetActive(false);
                if (selectNumber == 0)
                {
                    sTeacherBox.SetActive(false);

                    narrationBox.SetActive(true);
                    narrationText.text = GameManager1.Instance.lines3[0];
                }



                if ( selectNumber == 1)
                {
                    sTeacherBox.SetActive(false);
                    teacherBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = GameManager1.Instance.resultLines3_2;
                }
            
                if(selectNumber == 2) {
                    sTigerBox.SetActive(false);
                    tigerBox.SetActive(false);
                    teacherBox.SetActive(false);
                    speechBox.SetActive(true);
                  sharkBox.SetActive(true);
               
                   
                
                }
              
               
                break;
            case 18:
                speechBox.SetActive(true);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                teacherBox.SetActive(false);
                break;
            case 19:
               
                break;
            case 20:
                speechBox.SetActive(true);
                teacherBox.SetActive(true);
                tigerBox.SetActive(false);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.selectableLines3[selectNumber];   
                
                break;
            case 21:
            
                break;
            case 22:
                if (selectNumber == 0)
                {
                speechBox.SetActive(true);
                teacherBox.SetActive(false);
                tigerBox.SetActive(true);
                sharkBox.SetActive(false);
                speechText.text = GameManager1.Instance.WrongScream[1];
                }
                if(selectNumber == 1)
                {
                    narrationBox.SetActive(true);
                    narrationText.text = GameManager1.Instance.lines5[2];    // 잘 탈출
                    break;
                }

                if (selectNumber == 2)
                {
                    speechBox.SetActive(true);
                    teacherBox.SetActive(false);
                    tigerBox.SetActive(true);
                    sharkBox.SetActive(false);
                    speechText.text = GameManager1.Instance.WrongScream[2];
                }
                break;
            case 23:
                if (selectNumber == 0 || selectNumber == 2)
                {
                    sTeacherBox.SetActive(false);
                    narrationBox.SetActive(true);
                    narrationText.text = GameManager1.Instance.resultLines3_2;

                }
                break;
        }
         nextButton.SetActive(true);
        GameManager1.Instance.inputAllowed = true;
        _statusCompleted = true;
    }
    public void InputButton()
    {
        if (GameManager1.Instance.inputAllowed == false)
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

    IEnumerator IntroCut() //어느 때처럼 평범한 목요일...
    {
        GameManager1.Instance.inputAllowed = false;
        yield return new WaitForSeconds(1f);
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(GameManager1.Instance.lines1[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.
        GameManager1.Instance.inputAllowed = true;
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
    }
    IEnumerator IntroCut2() //점심시간이 지난 오후 수업이었다.
    {
        NarrationStartSet();    //나레이션 상자를 비워준다.
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(GameManager1.Instance.lines1[1], 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.
      
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
    }


    IEnumerator Speech1()   //루트 a가 b이면 c는..
    {
        StartCoroutine(SpeechStartSet(teacherBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[2], 2f).SetEase(Ease.Linear).SetId("remove");
      
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
    }
    IEnumerator Speech2()   //으아 저게 뭔소리여..
    {
        StartCoroutine(SpeechStartSet(tigerBox));

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[3], 2f).SetEase(Ease.Linear).SetId("remove");
      
        StartCoroutine(SpeechEndSet());
    }
    IEnumerator Speech3()   //수학은 너무 어려운것
    {
        SpeechRepeatSet(tigerBox);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[4], 2f).SetEase(Ease.Linear).SetId("remove");
      
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SpeechEndSet());
    }
    IEnumerator Speech4()   //축구봤냐
    {
        SpeechRepeatSet(tigerBox);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[5], 2f).SetEase(Ease.Linear).SetId("remove");
     
        yield return new WaitForSeconds(2.1f);

        StartCoroutine(SpeechEndSet());
    }
    IEnumerator Speech5()   //봤지 리버풀이 이김
    {
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[6], 1f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SpeechEndSet());
    }
    IEnumerator earthquake()   //지진
    {
        NarrationStartSet();    //나레이션 상자를 비워준다.

        cnt = 15;
        objects[0].transform.DOMove(new Vector3(-60.1f, 35.9f, 88.264f), 1.5f).SetEase(Ease.Linear);
        objects[2].transform.DORotate(new Vector3(45f, 0f, 0f), 0.4f).SetEase(Ease.Linear);
        objects[2].transform.DOMove(new Vector3(40.7f, 47.9f, 92.9f), 0.5f).SetEase(Ease.Linear);
        SoundManager._instance.Play_BGM("earthquake_1");
        StartCoroutine(SoundManager._instance.Play_SE("object_fall"));
        narrationText.DOText(GameManager1.Instance.earthquake[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.         
        yield return new WaitForSeconds(1.6f);
       
        StartCoroutine(NarrationEndSet());
    }
    IEnumerator Speech6()   //지진인가봐요
    {
        StartCoroutine(SpeechStartSet(teacherBox));
        
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        StartCoroutine(SoundManager._instance.Play_SE("object_fall"));
        speechText.DOText(GameManager1.Instance.lines1[7], 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.         
        yield return new WaitForSeconds(1.6f);
       
        StartCoroutine(SpeechEndSet());
    }
    
    IEnumerator Speech7()   //      선생님 이제 어케요?
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(sharkBox));

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[8], 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.         
        yield return new WaitForSeconds(1.6f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);

    }
    IEnumerator Speech8()               //교실에 있으면 큰일날뻔
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[9], 2f).SetEase(Ease.Linear).SetId("remove");

        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech9()           //어디로가지?
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[11], 2f).SetEase(Ease.Linear).SetId("remove");

        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator Speech10()           //너무 무서웠어 호빵아ㅠ
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(sharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.lines1[12], 2f).SetEase(Ease.Linear).SetId("remove");

        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }


    IEnumerator select01()  //선택하는 박스가 일단 등장.(텍스도 다 있음)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        teacherBox.SetActive(false);
        //다른 것들 다 비활성화를 시켜준다.

        sTeacherBox.SetActive(true);
        sTigerBox.SetActive(false);
        sSharkBox.SetActive(false);
        GameManager1.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));
        StartCoroutine(SoundManager._instance.Play_SE("object_fall"));
        selectableBox.SetActive(true);
        lastSpeechText.text = GameManager1.Instance.lines1[9];
        selectBox[0].text = GameManager1.Instance.selectableLines1[0];
        selectBox[1].text = GameManager1.Instance.selectableLines1[1];
        selectBox[2].text = GameManager1.Instance.selectableLines1[2];

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
        teacherBox.SetActive(false);
        //다른 것들 다 비활성화를 시켜준다.

        sTeacherBox.SetActive(true);
        sSharkBox.SetActive(false);
        sTigerBox.SetActive(false);
        GameManager1.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));
        selectableBox.SetActive(true);
        lastSpeechText.text = GameManager1.Instance.lines1[9];
        selectBox[0].text = GameManager1.Instance.selectableLines2[0];
        selectBox[1].text = GameManager1.Instance.selectableLines2[1];
        selectBox[2].text = GameManager1.Instance.selectableLines2[2];

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
        teacherBox.SetActive(false);
        //다른 것들 다 비활성화를 시켜준다.

        sTeacherBox.SetActive(true);
        sSharkBox.SetActive(false);
        sTigerBox.SetActive(false);
        GameManager1.Instance.inputAllowed = false;
        StartCoroutine(SoundManager._instance.Play_SE("question_01"));
        selectableBox.SetActive(true);
        lastSpeechText.text = GameManager1.Instance.lines1[9];
        selectBox[0].text = GameManager1.Instance.selectableLines3[0];
        selectBox[1].text = GameManager1.Instance.selectableLines3[1];
        selectBox[2].text = GameManager1.Instance.selectableLines3[2];

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
        StartCoroutine(SpeechStartSet(tigerBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        speechText.DOText(GameManager1.Instance.selectableLines1[selectNumber], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }

    IEnumerator SelectSpeech2(int selectNumber) //선택한 말이 노출된다.
    {
        button.SetActive(false);
        selectNumber = this.selectNumber;
        StartCoroutine(SpeechStartSet(teacherBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        speechText.DOText(GameManager1.Instance.selectableLines2[selectNumber], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }

    IEnumerator SelectSpeech3(int selectNumber) //선택한 말이 노출된다.
    {
        button.SetActive(false);
        selectNumber = this.selectNumber;
        StartCoroutine(SpeechStartSet(teacherBox));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("question"));
        speechText.DOText(GameManager1.Instance.selectableLines3[selectNumber], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(SpeechEndSet()); //대화가 다 나왔을때 실행된다.
        button.SetActive(true);
        //DOTweenPath.
    }

    IEnumerator GoodAct01() //책상에 밑으로
    {
        button.SetActive(false);
        //characters[0].SetBool("actJump", true);
        characters[0].transform.DORotate(new Vector3(0,-150.0f,0), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f);
        characters[1].SetBool("actJump", true);
        characters[2].SetBool("actJump", true);
        StartCoroutine(SoundManager._instance.Play_SE("hidden"));
        characters[0].transform.DOMove(new Vector3(3.8f, 0.2f, 70.2f), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(-25.88059f, 0.5f, -5.3f), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DOMove(new Vector3(27.7f, 2.1f,32.4f), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.3f);
        characters[0].SetBool("actHide", true);
        characters[1].SetBool("actJump", false);
        characters[2].SetBool("actJump", false);
        yield return new WaitForSeconds(0.3f);
        characters[1].SetBool("actRest", true);
        characters[2].SetBool("actRest", true);

        button.SetActive(true);

        status++;
        PlayStory(status);
    }
    IEnumerator GoodAct02() 
    {
        button.SetActive(false);
        characters[0].SetBool("actHide", false);
        characters[1].SetBool("actRest", false);
        characters[2].SetBool("actRest", false);
        yield return new WaitForSeconds(0.3f);
        characters[1].transform.DORotate(new Vector3(0f, -80f, 0f), 0.3f).SetEase(Ease.Linear);
        characters[2].transform.DORotate(new Vector3(0f, 80f, 0f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        characters[0].transform.DOMove(new Vector3(2f, 6.5f, 79.8f), 0.3f).SetEase(Ease.Linear);
        characters[1].transform.DOMove(new Vector3(26.9f, 22.2f, 28.92f), 0.3f).SetEase(Ease.Linear);
        characters[2].transform.DOMove(new Vector3(-27.5f, 11.8f, -8.08f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);

        characters[0].SetBool("actPick", true);
        characters[1].SetBool("actPick", true);
        characters[2].SetBool("actPick", true);
        yield return new WaitForSeconds(0.1f);
        characters[0].SetBool("actRun", true);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);
        objects[17].transform.DOMove(new Vector3(1.7f, 40.8f, 77.4f),0.2f).SetEase(Ease.Linear);
        objects[18].transform.DOMove(new Vector3(27.3f, 38f, 30.4f), 0.2f).SetEase(Ease.Linear);
        objects[19].transform.DOMove(new Vector3(-27.2f, 29.2f, -7.026f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        characters[0].SetBool("actPick", false);
        characters[1].SetBool("actPick", false);
        characters[2].SetBool("actPick", false);
        characters[0].transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f).SetEase(Ease.Linear);
        characters[1].transform.DORotate(new Vector3(0f, 0f, 0f), 0.3f).SetEase(Ease.Linear);
        characters[2].transform.DORotate(new Vector3(0f, 0f, 0f), 0.3f).SetEase(Ease.Linear);
        characters[0].SetBool("actRun", false);
        characters[1].SetBool("actRun", false);
        characters[2].SetBool("actRun", false);
        yield return new WaitForSeconds(0.5f);
        characters[0].SetBool("actRun", true);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);
        yield return new WaitForSeconds(0.2f);
        characters[0].transform.DOMove(new Vector3(59.4f, 6.7f, 81.6f), 2.3f).SetEase(Ease.Linear);
        characters[1].transform.DOMove(new Vector3(62.8f, 6.4f, 70.7f), 2.3f).SetEase(Ease.Linear);
        characters[2].transform.DOMove(new Vector3(50.3f, 6.4f, 68.1f), 2.3f).SetEase(Ease.Linear);
        objects[17].transform.DOMove(new Vector3(65.4f, 37.7f, 81.6f), 2.3f).SetEase(Ease.Linear);
        objects[18].transform.DOMove(new Vector3(62.8f, 30.0f, 70.7f), 2.3f).SetEase(Ease.Linear);
        objects[19].transform.DOMove(new Vector3(50.3f, 30.4f, 68.1f), 2.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        objects[20].transform.DOMove(new Vector3(79.76f, 0.009f, 61.9f), 0.6f).SetEase(Ease.Linear);

        StartCoroutine(ToHallway());
        yield return new WaitForSeconds(1.5f);
        characters[0].SetBool("actRun", false);
        characters[1].SetBool("actRun", false);
        characters[2].SetBool("actRun", false);
        yield return new WaitForSeconds(0.5f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }

    IEnumerator GoodAct03()
    {
        button.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        characters[0].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[0].SetBool("actRun", true);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);
        yield return new WaitForSeconds(0.5f);
        characters[0].transform.DOMove(new Vector3(58.03f, 6.5f, -76.5f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DOMove(new Vector3(66.8f, 6.5f, -82.7f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(59.3f, 8.1f, -82.1f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[17].transform.DOMove(new Vector3(58.03f, 40.5f, -76.5f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[18].transform.DOMove(new Vector3(66.8f, 30.4f, -82.7f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[19].transform.DOMove(new Vector3(59.3f, 30.1f, -82.1f), 3.0f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(2.0f);
        characters[0].transform.DORotate(new Vector3(0f, -90f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DORotate(new Vector3(0f, -90f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, -90f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(1.5f);
        characters[0].transform.DOMove(new Vector3(-23f, 6.5f, -86.5f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DOMove(new Vector3(-22.1f, 6.5f, -82.7f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(-24.8f, 6.5f, -85.1f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[17].transform.DOMove(new Vector3(-23f, 40.5f, -86.5f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[18].transform.DOMove(new Vector3(-22.1f, 30.4f, -82.7f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[19].transform.DOMove(new Vector3(-24.8f, 30.1f, -85.1f), 4.3f).SetEase(Ease.Linear).SetAutoKill(true);
        button.SetActive(true);
    }


        IEnumerator Wrong01()
    {
        button.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);

        characters[1].transform.DORotate(new Vector3(0f, -80f, 0f), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, 80f, 0f), 0.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.3f);
        characters[1].transform.DOMove(new Vector3(9.1f, 6.7f, 24.4f), 2.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(-3.5f, 6.8f, -12.7f), 2.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.3f);
        characters[1].transform.DORotate(new Vector3(0f, -179f, 0f), 0.6f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, 179f, 0f), 0.6f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f);
        characters[1].transform.DOMove(new Vector3(9.1f, 6.7f, -67.1f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(-3.5f, 6.8f, -64f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f);
        characters[1].transform.DORotate(new Vector3(0f, 89f, 0f), 0.7f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, 89f, 0f), 0.7f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f);
        characters[1].transform.DOMove(new Vector3(58.3f, 6.7f, -67.1f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(58.3f, 6.8f, -64f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);

        button.SetActive(true);

        status++;
        PlayStory(status);

    }
    IEnumerator Wrong01_2()
    {
        button.SetActive(false);

        objects[0].transform.DOMove(new Vector3(-28.4f,16.8f,-7.6f),0.8f).SetEase(Ease.Linear);
       
       // objects[9].transform.DOMove(new Vector3(26.4f, 0.277f, 19.4f), 0.8f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }
    IEnumerator Wrong02_1()
    {
        button.SetActive(false);
        characters[0].SetBool("actHide", false);
        characters[1].SetBool("actRest", false);
        characters[2].SetBool("actRest", false);
        characters[0].transform.DOMove(new Vector3(2.1f, 11.8f, 77.6f), 0.8f).SetEase(Ease.Linear);
        characters[2].transform.DOMove(new Vector3(-27.1f, 11.2f, -1.72f), 0.8f).SetEase(Ease.Linear);
        characters[1].transform.DOMove(new Vector3(30.2f, 11.2f, 26.9f), 0.8f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.0f);
        objects[0].transform.DOMove(new Vector3(-28.4f, 16.8f, -7.6f), 0.8f).SetEase(Ease.Linear);

       
        yield return new WaitForSeconds(0.5f);
        button.SetActive(true);

        status++;
        PlayStory(status);
    }

    IEnumerator Wrong03()
    {
        button.SetActive(false);
        characters[0].SetBool("actRun", true);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);
        yield return new WaitForSeconds(0.5f);
        characters[0].transform.DORotate(new Vector3(0f, -50.4f, 0f), 0.8f).SetEase(Ease.Linear);
        characters[2].transform.DORotate(new Vector3(0f, 8.1f, 0f), 0.8f).SetEase(Ease.Linear);
        characters[1].transform.DORotate(new Vector3(0f, 8.3f, 0f), 0.8f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.8f);
        characters[0].transform.DOMove(new Vector3(-18.4f, 8.4f, 115.9f), 2.8f).SetEase(Ease.Linear);
        characters[2].transform.DOMove(new Vector3(-27.0878f, 6.1f, 112.5f), 2.8f).SetEase(Ease.Linear);
        characters[1].transform.DOMove(new Vector3(-1.4f, 6.3f, 119f), 2.8f).SetEase(Ease.Linear);
        objects[17].transform.DOMove(new Vector3(-18.4f, 40.4f, 115.9f), 2.8f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[19].transform.DOMove(new Vector3(-27.0878f, 30.1f, 112.5f), 2.8f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[18].transform.DOMove(new Vector3(-1.4f, 30.3f, 119f), 2.8f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(2.2f);
        characters[0].SetBool("actRun", false);
        characters[1].SetBool("actRun", false);
        characters[2].SetBool("actRun", false);
        yield return new WaitForSeconds(0.2f);
    
        characters[0].SetBool("actDamage", true);
        characters[1].SetBool("actDamage", true);
        characters[2].SetBool("actDamage", true);
        yield return new WaitForSeconds(2.0f);

        button.SetActive(true);



        status++;
        PlayStory(status);
    }

    IEnumerator Wrong03_2()
    {
        button.SetActive(false);
        characters[0].SetBool("actRun", true);
        characters[1].SetBool("actRun", true);
        characters[2].SetBool("actRun", true);
        yield return new WaitForSeconds(0.2f);
        characters[0].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(1.3f);
        characters[0].transform.DOMove(new Vector3(53.53f, 6.5f, -121.5f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DOMove(new Vector3(56.8f, 6.4f, -112.7f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(61.3f, 6.5f, -118.1f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[17].transform.DOMove(new Vector3(53.53f, 40.5f, -121.5f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[18].transform.DOMove(new Vector3(56.8f, 30.4f, -112.7f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[19].transform.DOMove(new Vector3(61.3f, 30.1f, -118.1f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(1.5f);
        characters[0].transform.DORotate(new Vector3(0f, -88f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DORotate(new Vector3(0f, -88f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DORotate(new Vector3(0f, -88f, 0f), 1.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(1.5f);
        characters[0].transform.DOMove(new Vector3(-60.5f, 30.5f, -121.5f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[1].transform.DOMove(new Vector3(-60.7f, 30.4f, -112.7f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        characters[2].transform.DOMove(new Vector3(-62.3f, 30.1f, -119.1f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[17].transform.DOMove(new Vector3(-60.5f,63.5f, -121.5f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[18].transform.DOMove(new Vector3(-60.7f, 55.4f, -112.7f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        objects[19].transform.DOMove(new Vector3(-62.3f, 55.1f, -119.1f), 3.3f).SetEase(Ease.Linear).SetAutoKill(true);
        yield return new WaitForSeconds(2.5f);
        characters[0].SetBool("actRun", false);
        characters[1].SetBool("actRun", false);
        characters[2].SetBool("actRun", false);
        yield return new WaitForSeconds(0.1f);
        characters[0].SetBool("actDamage", true);
        characters[1].SetBool("actDamage", true);
        characters[2].SetBool("actDamage", true);
        yield return new WaitForSeconds(2.1f);
        button.SetActive(true);
        status++;
        PlayStory(status);
    }

    IEnumerator WrongSpeech01()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));

        yield return new WaitForSeconds(0.5f);
        speechText.DOText(GameManager1.Instance.resultLines3_1, 1.5f).SetEase(Ease.Linear).SetId("remove");
        // 나레이션 상자에 대화 내용을 넣어 준다.   
        yield return new WaitForSeconds(0.3f);
        characters[1].SetBool("actRun", false);
        characters[2].SetBool("actRun", false);
        objects[15].transform.DORotate(new Vector3(90.0f, 0, 0), 1.0f).SetEase(Ease.Linear);
        objects[16].transform.DORotate(new Vector3(90.0f, 0, 0), 1.0f).SetEase(Ease.Linear);
        
        objects[15].transform.DOMove(new Vector3(50.86f, 8.8f, -102.3f), 2.0f).SetEase(Ease.Linear);
        objects[16].transform.DOMove(new Vector3(40.4f, 8.7f, -102.3f), 2.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
        StartCoroutine(SoundManager._instance.Play_SE("struggle_01"));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(SoundManager._instance.Play_SE("struggle"));
        characters[1].SetBool("actDie", true);
        characters[2].SetBool("actDie", true);
        yield return new WaitForSeconds(0.3f);


        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }

    IEnumerator GoodEnd()  // "그렇게 두 친구와 모든 학급 친구들이 무사히 건물밖으로 안전하게 나왔습니다." };
    {
        endBox = true;
        NarrationStartSet();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(GameManager1.Instance.lines5[2], 1.5f).SetEase(Ease.Linear).SetId("remove");
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missioncomplete",false));
        StartCoroutine(NarrationEndSet()); //대화가 다 나왔을때 실행된다.}
    }


    IEnumerator Wrongend01()
    {
        endBox = true;
        sTeacherBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(GameManager1.Instance.resultLines3_2, 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.6f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure",false));
        StartCoroutine(NarrationEndSet());
       // SceneManager.LoadScene("classroomOnEarthquake");
       
    }

    IEnumerator Wrongend02()
    {
        endBox = true;
        sTeacherBox.SetActive(false);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(GameManager1.Instance.lines3[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.6f);
        SoundManager._instance.StopBGM();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("missionfailure", false));
        StartCoroutine(NarrationEndSet());
        // SceneManager.LoadScene("classroomOnEarthquake");

    }

    IEnumerator WrongSpeech01_2()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        StartCoroutine(SoundManager._instance.Play_SE("struggle_01"));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("struggle"));
        speechText.DOText(GameManager1.Instance.WrongScream[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.2f);
     //   characters[1].SetBool("actDie", true);
        characters[2].SetBool("actDie", true);
        yield return new WaitForSeconds(1.6f);
        
        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator WrongSpeech02_1()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        StartCoroutine(SoundManager._instance.Play_SE("struggle_01"));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("struggle"));
        speechText.DOText(GameManager1.Instance.WrongScream[0], 1.5f).SetEase(Ease.Linear).SetId("remove");
        yield return new WaitForSeconds(0.2f);
       // characters[1].SetBool("actDie", true);
        characters[2].SetBool("actDie", true);

        yield return new WaitForSeconds(1.6f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator WrongSpeech03_1()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("object_fall"));
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(GameManager1.Instance.WrongScream[1], 1.5f).SetEase(Ease.Linear).SetId("remove");


        yield return new WaitForSeconds(1.6f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }
    IEnumerator WrongSpeech03_2()
    {
        button.SetActive(false);
        StartCoroutine(SpeechStartSet(tigerBox));
        StartCoroutine(SoundManager._instance.Play_SE("object_fall"));
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        yield return new WaitForSeconds(0.5f);
        speechText.DOText(GameManager1.Instance.WrongScream[2], 1.5f).SetEase(Ease.Linear).SetId("remove");


        yield return new WaitForSeconds(1.6f);

        StartCoroutine(SpeechEndSet());
        button.SetActive(true);
    }





    IEnumerator SpeechEndSet()
    {
       // _statusCompleted = true;
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);
       
    }
       
    void NarrationStartSet()
    {
        teacherBox.SetActive(false);
        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        selectableBox.SetActive(false);
        // fireSpeechBox.SetActive(false);
        sTeacherBox.SetActive(false);

        narrationBox.SetActive(true);
        narrationText.text = "";
    }
    
    void FireStartSet()
    {
    }
    void FireRepeatSet()
    {
       
    }

    IEnumerator NarrationEndSet()
    {
       // _statusCompleted = true;    //대화가 다 나온상태라는 것.
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);
    }

    IEnumerator SpeechStartSet(GameObject characterBox)
    {
        narrationBox.SetActive(false);

        speechBox.SetActive(false);
        tigerBox.SetActive(false);
        sharkBox.SetActive(false);
        teacherBox.SetActive(false);
        selectableBox.SetActive(false);
       // fireSpeechBox.SetActive(false);

        GameManager1.Instance.inputAllowed = false;

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
        GameManager1.Instance.inputAllowed = true;
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
    SceneManager.LoadScene("classroomOnEarthquake");  //씬에서 나갔다 다시 오면 초기화되있음.
}

/*void FromHereScene() //여기부터
{
    status = status - 5;
}*/


IEnumerator ChangePlace()   //복도로 장소를 바꾼다.
{
        button.SetActive(false);
        fade.DOFade(1.0f, 0.5f).SetId("remove");  //fadeout    
        yield return new WaitForSeconds(0.5f);
        classroom.SetActive(false);
        SceneManager.LoadScene(1);
    }

    IEnumerator ToPhone()
    {
        speechBox.SetActive(false);
        sharkBox.SetActive(false);
        fade.DOFade(1.0f, 0.5f);    //어두워짐
        yield return new WaitForSeconds(0.5f);
        IPhone.SetActive(true);
        IPhoneFader.SetActive(true);
        IPhoneFaderAlpha.color = new Color(0, 0, 0, 1.0f);
        ClassroomSet.SetActive(false);
        IPhoneFaderAlpha.DOFade(0.0f, 0.5f);    //밝아짐.
        yield return new WaitForSeconds(0.5f);
        IPhoneFader.SetActive(false);
    }


    IEnumerator FinishScene()
{
    fade.DOFade(1.0f, 1.0f);
    yield return new WaitForSeconds(1.0f);//어두워짐
    SceneManager.LoadScene("GoodJobScreen_Fire");
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


    public void objects_move1()
    {
        objects[3].transform.DOMove(new Vector3(51.9f, 7.0f, 45.90574f), 1.2f).SetEase(Ease.Linear);
        objects[4].transform.DOMove(new Vector3(54.6f, 7.2f, 5.1f), 1.2f).SetEase(Ease.Linear);
        objects[5].transform.DOMove(new Vector3(54.6f, 7.2f, -41.7f), 1.2f).SetEase(Ease.Linear);
        objects[7].transform.DOMove(new Vector3(13.2f, 7.2f, 1.105f), 1.2f).SetEase(Ease.Linear);
        objects[8].transform.DOMove(new Vector3(28.1f, 7.8f, -48.7f), 1.2f).SetEase(Ease.Linear);
        objects[9].transform.DOMove(new Vector3(-22.8f, 7.2f, 39.1f), 1.2f).SetEase(Ease.Linear);
        objects[11].transform.DOMove(new Vector3(-18.4f, 7.2f, -49.1f), 1.2f).SetEase(Ease.Linear);
        objects[12].transform.DOMove(new Vector3(-71f, 7.2f, 44.2f), 1.2f).SetEase(Ease.Linear);
        objects[13].transform.DOMove(new Vector3(-47.7f, 7.2f, -12.7f), 1.2f).SetEase(Ease.Linear);
        objects[14].transform.DOMove(new Vector3(-67.3f, 7.2f, -68f), 1.2f).SetEase(Ease.Linear);
    }

    public void objects_move2()
    {
        objects[3].transform.DOMove(new Vector3(54.4f, 1.4f, 35.90574f), 1.2f).SetEase(Ease.Linear);
        objects[4].transform.DOMove(new Vector3(54.3f, 1.2f, 0.2f), 1.2f).SetEase(Ease.Linear);
        objects[5].transform.DOMove(new Vector3(54.5f, 1.2f, -39.7f), 1.2f).SetEase(Ease.Linear);
        objects[7].transform.DOMove(new Vector3(27.7f, 1.8f, 1.105f), 1.2f).SetEase(Ease.Linear);
        objects[8].transform.DOMove(new Vector3(28.7f, 1.2f, -39.7f), 1.2f).SetEase(Ease.Linear);
        objects[9].transform.DOMove(new Vector3(-25.9f, 1.2f, 39.4f), 1.2f).SetEase(Ease.Linear);
        objects[11].transform.DOMove(new Vector3(-25.4f, 1.2f, -36.1f), 1.2f).SetEase(Ease.Linear);
        objects[12].transform.DOMove(new Vector3(-57.9f, 1.2f, 36.4f), 1.2f).SetEase(Ease.Linear);
        objects[13].transform.DOMove(new Vector3(-57.7f, 1.2f, 0.7f), 1.2f).SetEase(Ease.Linear);
        objects[14].transform.DOMove(new Vector3(-57.3f, 1.9f, -45.7f), 1.2f).SetEase(Ease.Linear);
    }

    IEnumerator ToHallway()
    {
        //상어
        button.SetActive(false);
        fade.DOFade(1.0f, 0.5f).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        classroom.SetActive(false);
        outside.SetActive(true);
        fade.DOFade(0.0f, 0.5f).SetId("remove");
        yield return new WaitForSeconds(0.5f);
        button.SetActive(true);
        

    }
}
