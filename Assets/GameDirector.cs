using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 鋼球獣 績匂闘研 背醤 廃陥. UI淫恵
using UnityEngine.SceneManagement; //政艦銅 scene聖 災君神奄 是背 紫遂

public class GameDirector : MonoBehaviour
{// 姶偽 什滴験闘 
    //UI研 飴重
    GameObject gCar;  //GameObject莫 痕呪 識情
    GameObject gFlag; // 陳匂獲闘研 眼聖 朔 雌切研 幻窮 依引 旭陥.
    GameObject gDitance;
    GameObject gScoreUI;
    GameObject gChance;
    GameObject gBtnRE;


    
    float fLength = 0.0f;
    float fDelta = 0.0f; //廃 覗傾績拭 杏軒澗 獣娃聖 眼聖 痕呪
    int nScore = 0; // 繊呪
    bool isSucceed = false;

    public void ReStart(){ //獄動聖 喚袈聖凶 叔楳鞠澗 敗呪

        nScore = 0; //繊呪 段奄鉢        
       
        SceneManager.LoadScene("GameScene"); // LoadScene 五社球研 紫遂馬食 段奄拭 煽舌吉
                                             // GameSene研 災君紳陥 

    }

    void ReposCar() //託 是帖 段奄鉢 敗呪
    {
        fDelta += Time.deltaTime; // 廃 覗傾績拭 杏軒澗 獣娃聖 眼澗陥.
        if (fDelta >= 1.0f) //幻鉦 fDelta亜 1段 戚雌戚 鞠檎
        {
            fDelta = 0.0f; //段奄鉢
            this.gCar.transform.position = CarController.vRePos; //託疑託税 是帖研 坦製生稽 宜鍵陥.   
            if (isSucceed == true) { //失因戚檎 
                this.nScore += 10; //繊呪 装亜
                isSucceed = false; //陥獣 叔鳶稽 段奄鉢
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gCar = GameObject.Find("car"); // UnityEngine拭辞 薦因馬澗 Find五社球
        this.gFlag = GameObject.Find("flag"); // 政艦銅 樟税 神崎詮闘研 昔呪葵生稽 達焼 
        this.gDitance = GameObject.Find("Distance"); // GameObject税 痕呪人 尻衣背 爽澗 庚舌戚陥.
        this.gScoreUI = GameObject.Find("ScoreUI");
        this.gChance = GameObject.Find("Chance");
        this.gBtnRE = GameObject.Find("BtnRe");
    }

    // Update is called once per frame
    void Update()
    {
        gBtnRE.SetActive(false);
        
        fLength = this.gFlag.transform.position.x - this.gCar.transform.position.x;
        //                     炎降税 疎妊              -      切疑託税 疎妊 
        //                    = 鯉妊走繊猿走税 害精 暗軒


        //肉闘 紫戚綜人 事雌 段奄鉢
        this.gDitance.GetComponent<Text>().color = Color.black; //事雌 痕井 color澗 unityengine
                                                                //革績什凪戚什拭 匂敗
        this.gDitance.GetComponent<Text>().fontSize = 64;   //肉闘 紫戚綜
        
        this.gDitance.GetComponent<Text>().text = "鯉妊走繊猿走" + fLength.ToString("F2") + "m";
        this.gChance.GetComponent<Text>().text = "害精 奄噺: " + CarController.nCount.ToString("D2");
        this.gScoreUI.GetComponent<Text>().text = "繊呪 : " + nScore.ToString();
        // text陳匂獲闘研 紫遂馬食 distance神崎詮闘税 努什闘 痕井
        // fLength(害精暗軒)
        //ToString() 五社球澗 葵聖 庚切伸稽 痕発背 層陥.
        //昔呪 葵生稽 F2澗 F(壱舛 社呪繊莫).2(切軒呪)   => 聡 叔呪莫 葵聖 社呪繊 却 属 切軒猿走
        //                                               庚切伸稽 痕発 (舛呪莫精D戚陥.)

        if (CarController.fSpeed <= 0.001f) //託税 紗亀亜 0.001引 旭暗蟹 拙陥檎
        {

            CarController.fSpeed = 0.0f; // 紗亀澗 0戚鞠走 省奄拭 陥獣 段奄鉢背醤 誇秩陥.


            if (CarController.nCount <= 0) //判呪亜 0戚檎
            {
                this.gDitance.GetComponent<Text>().text = "惟績 魁!";
                this.gScoreUI.GetComponent<Text>().text = "繊呪 : " + ToString();
                this.gChance.GetComponent<Text>().text = "害精 奄噺: " + CarController.nCount.ToString("D2");
                gBtnRE.SetActive(true); //段奄鉢 獄動聖 醗失鉢
            }

        

            if (fLength > 1.5 && gCar.transform.position.x != CarController.vRePos.x) // 炎降拭 亀含馬走 公馬心聖凶
            {
                this.gDitance.GetComponent<Text>().fontSize = 180;// 肉闘 紫戚綜 痕井
                this.gDitance.GetComponent<Text>().color = Color.red; //事雌 痕井 color澗 unityengine
                                                                      //革績什凪戚什拭 匂敗
                this.gDitance.GetComponent<Text>().text = "ぞ..";


                ReposCar(); //託 是帖 段奄鉢
            }
            else if (fLength >= -1.5 && fLength <= 1.5)
            { //害精 暗軒亜 1 戚馬 -1 戚雌 戚虞檎



                this.gDitance.GetComponent<Text>().fontSize = 180;
                this.gDitance.GetComponent<Text>().color = Color.yellow; //事雌 痕井 color澗 unityengine
                                                                         //革績什凪戚什拭 匂敗
                this.gDitance.GetComponent<Text>().text = "失因!";
                isSucceed = true; //失因
                ReposCar(); //託 是帖 段奄鉢+繊呪 装亜
            }
            else if (fLength < -1.5f)
            { // 走蟹帖檎  

                this.gDitance.GetComponent<Text>().fontSize = 180;//肉闘 紫戚綜 痕井

                this.gDitance.GetComponent<Text>().color = Color.red; //事雌 痕井 color澗 unityengine
                                                                      //革績什凪戚什拭 匂敗
                this.gDitance.GetComponent<Text>().text = "せせせせせせせせせせせ";

                ReposCar(); //託 是帖 段奄鉢
            }
            
        }

     }
    
 }


/*
     陳匂獲闘 : 神崎詮闘亜 亜走壱 赤澗 竺舛切戟稽 左昔陥. 神崎詮闘税 推社?
                曽嫌稽澗 Text, Transform, AudioSource, Ragidbody(弘軒旋生稽 崇送績)去戚 赤陥.
       
    莫縦 :    Game神崎詮闘虞澗 朔 雌切拭 陳匂獲闘研 蓄亜馬壱 GetComponent 五社球研 紫遂馬食
              <>鴬取 照拭 据馬澗 陳匂獲闘研 隔嬢 紫遂廃陥.
                
                *鴬取 照拭級嬢亜澗 陳匂獲闘澗 適掘什 莫縦生稽 鞠嬢 赤澗暗 旭焼 左食 鴬取 及拭
                 据馬澗 五社球研 硲窒馬食 紫遂拝 呪 赤澗 依 坦軍 左昔陥.
                 GetComponent<AudioSource>().Play();

                ps. GetComponent五社球澗 
                    UnityEngin 税 NameSpace -> GameObject class 税 五社球戚陥.
                
                    namespace澗 敗呪蟹 姥繕端 箸精 痕呪 戚硯 去税 社紗 (姥繕端 暁澗 敗呪税 
                        戚硯戚 旭焼 中宜馬澗 依聖 号走)

 */