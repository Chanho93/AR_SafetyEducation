using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    public string teacher = "선생님";
    public string tiger = "호돌이";
    public string shark = "아기상어";

    public string[] lines1 = new string[]{
                                          "화창한 봄날 5교시..",
                                          "수업시간중..",
                                          "루트 a가 b라면..c는 무엇인가?", //1
                                          "으아 저게 뭔소리여..",  //2
                                          "수학은 너무 어려웡", //3
                                          "야 어제 축구 봤냐?", //4
                                          "봤지 리버풀이 이겼다!",  //5

                                          "여러분 지진인가봐요!  저번에 배운 행동대피 요령대로 행동해요!",  //6
                                          "선생님 이제 어떻게 해요?",   //7
                                          "어디로 가지?!",
                                          "엄마ㅠ나죽어ㅠㅜㅜ잘지내ㅜ",
                                          "교실에 있으면 위험할 뻔 했다.",
                                          "너무 무서워 호빵아ㅠㅠ",
                                          "지진이 났다!!"



    };   //8


    public string[] earthquake = new string[] { "쿠쿵쿵쿵"

                        };

    public string[] WrongScream = new string[] {
                                                    };


    public string[] selectableLines1 = new string[] {
                                                    };

    public string resultLines2_1 = "책상밑으로 숨는다.";
    public string resultLines3_1 = "어..어어!! 쿵";
    public string resultLines3_2 = "그렇게 두 친구는 하늘나라로 가게되었습니다.";

    public string[] lines2 = {  "내 핸드폰..핸드폰 어딨지??..",
                                "침착해 상어야 이럴때 일수록 침착해야해!!",
                                "알겠어.. 여기있다!! 1(삑) 1(삑) 9(삑)",
                                "네 119입니다. 무엇을 도와드릴까요??"};

    public string[] selectableLines2 = new string[] {
                                                     };

    public string resultLines4_1 = "이제 바로 밖으로 나가자!";


    public string resultLines4_2 = "부모님께 마지막으로 전화드려!";
    public string resultLines4_3 = "머리를 보호할 만 물건을 찾아서 나가자!";

    public string[] lines3 = {  "그렇게 호빵이는 물건에 맞아 죽고 말았습니다.",
                                "그렇게 호빵이는 물건에 맞아 죽고 말았습니다."};

    public string[] selectableLines3 = { "진동이 덜 한 다른반으로 대피한다.",
                                         "건물 밖 운동장으로 대피한다.",
                                         "옥상으로 대피한다.",};

    public string resultLines5_1 = "나는 순수건이 없으니깐 옷소매에 물을 적셔서 코와 입을 막고 쭈그려서 나갈께.";
    public string[] resultLines5_2 = { "눈 가리고 나가는 중에 발이 걸려 넘어졌어요.",
                                "그렇게 두 친구는 건물에 갇혀 하늘나라로 가게 되었습니다." };
    public string[] resultLines5_3 = { "불이 났을때 창문을 열면 옆으로 금방 번지기 때문에 건물 밖으로 나올때 문을 닫고 나와야 되요.",
                                       "두 친구는 문을 열어 다른 교실까지 불을 옮기게 했어요. 그렇게 다른 학급 친구들과 다 같이 하늘나라에 가게되었어요." };

    public string lines4 = "우리 다른 친구들에게도 알려야 되는데 어떻게 알리지??!!";

    public string[] selectableLines4 ={ "같이 방송실에 가서 안내 방송을 하자.",
                                        "아니야 괜찮아 다른 학급들은 이미 눈치 채서 나가고 있을꺼야, 그냥 빠르게 나가자.",
                                        "" };
    public string resultLines6_1 = "비상벨 누르러 가는 중..";
    public string[] resultLines6_2 = { "방송실이 몇층이였지?? 3층이였나?? 얼른 올라가자!! ",
                                      "." };
    public string[] resultLines6_3 = { "빨리 학교 건물밖으로 나가자",
        "두 친구는 안전하게 나갔지만 다른 학급 친구들이 하늘나라에 가게 되었어요." };

    public string[] lines5 = { "",
                               "다들 건물 밖으로 나가요!!",
                               "그렇게 두 친구와 모든 학급 친구들이 무사히 건물밖으로 안전하게 나왔습니다." };

    //끝
    public bool inputAllowed = true;


    public static GameManager1 Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager1 instance = null;

    void Awake () {
        Application.targetFrameRate = 60;

        // --------------------------------- 싱글턴 -------------------------------------
        // 씬에 이미 인스턴스가 존재하는지 검사한다
        // 존재하는 경우 이 인스턴스는 소멸시킨다
        if (instance)
        {
            DestroyImmediate(gameObject);

            return; // return은 메소드 중간에 호출되어 메소드를 종결시킨다.. 따라서 Awake()를 완전히 빠져나온다.
        }

        // 이 인스턴스를 유효한 유일 오브젝트로 만든다
        instance = this;

        // 게임 매니저가 지속되도록 한다
        //DontDestroyOnLoad(gameObject);
        //--------------------------------------------------------------------------------
    }

    // Update is called once per frame
}
