using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration_Script : MonoBehaviour {
    public string Teddy = "포돌이";
    public string TeddyDaddy = "샤크";
    public string Police = "경찰";

    //대사//
    
    public string Narration1 = "";
    public string Narration2 = "";
    public string Narration3 = "";
    public string Narration4 = "";
    public string Narration5 = "";
    public string Narration6 = "";
    public string Narration7 = "";
    public string Narration8 = "";
    public string Narration9 = "";
    public string Narration10 = "";
    public string Narration11 = "";
    public string Narration12 = "";
    public string Narration13 = "";
    public string Narration14 = "";
    public string Narration15 = "";
    public string Narration16 = "";
    public string Narration17 = "";
    public string Narration18 = "";
    public string Narration19 = "";
    public string Narration20 = "";
    public string Narration21 = "";
    public string Narration22 = "";
    public string Narration23 = "";
    public string Narration24 = "";
    public string Narration25 = "";
    public string Narration26 = "";
    public string Narration27 = "";
    public string Narration28 = "";
    public string Narration29 = "";
    public string Narration30 = "";
    public string Narration_Police = "";
    public string Narration_End1 = "";
    public string Narration_End2 = "";
    public string Narration_End3 = "";
    public string Narration_End4 = "";
    public string Narration_Event = "";
    public string Narration_Event2 = "";
    public string Narration_Event3 = "";
    public string Narration_Event4 = "";
    public string Narration_Event5 = "";
    public string Narration_Event6 = "";
    public string Narration_Event7 = "";
    public string Narration_Event8 = "";
    public string Narration_Event9 = "";
    public string Narration_Event10 = "";
    
    public string[] narration;
    public string[] Quest;
    public string[] Alarm;
    public string[] ship;
    public string[] shipFail;

    public bool inputAllowed = true;
    public bool handtower = false;
    public int fireOff = 0;

    //! ToolBar
    [HideInInspector]
    public int toolbarTab, toolbarTab2;
    [HideInInspector]
    public string currentTab;


    //-----------------------------------------------------------------------------------------
    // 싱글턴 인스턴스에 접근하기 위한 C# 프로퍼티
    // get 접근자만 가지는 읽기 전용의 프로퍼티
    public static Narration_Script Instance
    {
        // private 변수 instance의 참조를 반환한다
        get
        {
            return instance;
        }
    }
    //------------------------------------------------------------------------------------------
    private static Narration_Script instance = null;
    //------------------------------------------------------------------------------------------

    void Awake()
    {
        //Application.targetFrameRate = 60;

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
}
