using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class ResourceConfig : MonoBehaviour
{
    private Button ATK1;
    private Button ATK2;
    private Button Skill1;
    private Button Skill2;
    private Button Show;
    private Button Random;

    private Text HeroId;
    private Text HeroName;
    private Text FileName;

    private void Awake()
    {
        ATK1 = transform.Find("ModelControl/animationPanel/ATK1").GetComponent<Button>();
        ATK2 = transform.Find("ModelControl/animationPanel/ATK2").GetComponent<Button>();
        Skill1 = transform.Find("ModelControl/animationPanel/Skill1").GetComponent<Button>();
        Skill2 = transform.Find("ModelControl/animationPanel/Skill2").GetComponent<Button>();
        Show = transform.Find("ModelControl/animationPanel/Show").GetComponent<Button>();
        Random = transform.Find("ModelControl/animationPanel/Random").GetComponent<Button>();
        FileName = transform.Find("ModelBG/FileName").GetComponent<Text>();
        HeroId = transform.Find("HeroId/Text").GetComponent<Text>();
        HeroName = transform.Find("Name/Text").GetComponent<Text>();


    }

    void Start()
    {
        Init();
    }
    private int target = 0;
    public Dictionary<int, Animator> AnimList = new Dictionary<int, Animator>();

    void Init ()
    {
        Transform AnimPlan = transform.Find("ModelBG/AnimPlan");
        Animator[] anims = AnimPlan.GetComponentsInChildren<Animator>();
        for (int i = 0; i < anims.Length;i++)
        {
            AnimList.Add(AnimList.Count,anims[i]);
            anims[i].gameObject.SetActive(false);
        }
        FileName.text = "文件名:" + AnimList[target].gameObject.name;
        AnimList[target].gameObject.SetActive(true);


        ATK1.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("ATK1");
        });
        ATK2.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("ATK2");
        });
        Skill1.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("Skill1");
        });
        Skill2.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("Skill2");
        });
        Show.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("Show");
        });
        Random.onClick.AddListener(delegate {
            AnimList[target].SetTrigger("Random");
        });
    }

    private void Update()
    {
        OnTouch();
    }

    void OnTouch()
    {
        if(Input.GetMouseButton(0))
            AnimList[target].transform.eulerAngles = new Vector3(AnimList[target].transform.eulerAngles.x, AnimList[target].transform.eulerAngles.y - Input.GetAxis("Mouse X")*3, AnimList[target].transform.eulerAngles.z);
    }

    public void InitHero(int Id)
    {
        HeroId.text = Id.ToString();
        for (int i = 0;i<DataManage.BasicInfoJsonData.Count;i++)
        {
            print("ID】=" + DataManage.BasicInfoJsonData[i]["HeroId"].ToString());
            if(HeroId.text == DataManage.BasicInfoJsonData[i]["HeroId"].ToString())
            {
                HeroName.text = DataManage.BasicInfoJsonData[i]["Name"].ToString();
                print("名字"+DataManage.BasicInfoJsonData[i]["Name"].ToString());
                break;
            }
            else
            {
                HeroName.text = "名字没有";
            }

        }

        
    }

    public void ChengModel(int direction)
    {
        AnimList[target].gameObject.SetActive(false);
        if (direction == 0)
        {
            if (target <= 0)
            {
                target = AnimList.Count - 1;
            }else
            {
                target -= 1;
            }
        }
        else
        {
            if(target>=AnimList.Count-1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
        AnimList[target].gameObject.SetActive(true);
        AnimList[target].transform.eulerAngles = new Vector3(0, 180, 0);
        FileName.text = "文件名:" + AnimList[target].gameObject.name;
    }

}
