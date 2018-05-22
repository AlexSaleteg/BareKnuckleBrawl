using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : MonoBehaviour {

    public GameObject dial;
    public MeshCustomization playerM;
    public MeshCustomization playerF;
    public PlayerVisualsData data;
    public string choose;
    public string next;
    public string randomize;
    public AudioClip swoosh;
    public AudioClip click;

    private AudioSource audiosource;
    private MeshCustomization player;
    private int skinColor;
    private int moustache;
    private int hair;
    private int moustacheColor;
    private int phase;

    void Start()
    {
        audiosource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        skinColor = PlayerPrefs.GetInt("Player" + playerM.gameObject.name[6] + "SkinColor", 0);
        moustache = PlayerPrefs.GetInt("Player" + playerM.gameObject.name[6] + "Moustache", 1);
        hair = PlayerPrefs.GetInt("Player" + gameObject.name[6] + "Hair", 0);
        moustacheColor = PlayerPrefs.GetInt("Player" + playerM.gameObject.name[6] + "MoustacheColor", 0);
        int bodytype = PlayerPrefs.GetInt("Player" + playerM.gameObject.name[6] + "BodyType", 0);
        if (bodytype == 0)
        {
            player = playerM;
            playerF.gameObject.SetActive(false);
        }
        else if (bodytype == 1)
        {
            player = playerF;
            playerM.gameObject.SetActive(false);
        }
        player.gameObject.SetActive(true);
        data.SetBodyType(bodytype);
    }

    void Update ()
    {
        if (Input.GetKeyDown(randomize))
        {
            audiosource.PlayOneShot(swoosh, 0.7f);
            player.gameObject.SetActive(false);
            if (Random.Range(0, 2) == 0)
            {
                player = playerF;
                data.SetBodyType(1);
            }
            else
            {
                player = playerM;
                data.SetBodyType(0);
            }
            player.gameObject.SetActive(true);
            skinColor = Random.Range(0, player.source.skinColors.Length);
            moustache = Random.Range(1, 6);
            moustacheColor = Random.Range(0, player.source.moustacheColors.Length);
            SaveData();
        }
        else if (Input.GetKeyDown(next))
        {
            phase++;
            audiosource.PlayOneShot(click, 0.5f);
            if (phase > 4)
            {
                phase = 0;
            }
        }
        else if (Input.GetKeyDown(choose))
        {
            audiosource.PlayOneShot(click, 0.5f);
            if (phase == 0)
            {
                player.gameObject.SetActive(false);
                if (player == playerM)
                {
                    player = playerF;
                    data.SetBodyType(1);
                }
                else if(player == playerF)
                {
                    player = playerM;
                    data.SetBodyType(0);
                }
                player.gameObject.SetActive(true);
            }
            else if (phase == 1)
            {
                skinColor++;
                if (skinColor >= player.source.skinColors.Length)
                {
                    skinColor = 0;
                }
            }
            else if (phase == 2)
            {
                moustache++;
                if (moustache > 5)
                {
                    moustache = 1;
                }
            }
            else if (phase == 3)
            {
                hair++;
                if (hair > 5)
                {
                    hair = 1;
                }
            }
            else if (phase == 4)
            {
                moustacheColor++;
                if (moustacheColor >= player.source.moustacheColors.Length)
                {
                    moustacheColor = 0;
                }
            }
            SaveData();

        }
	}

    void SaveData()
    {
        data.SetSkinColor(skinColor);
        data.SetMoustache(moustache);
        data.SetMoustacheColor(moustacheColor);
        player.RecolorSkin(skinColor);
        player.ChangeMoustache(moustache);
        player.RecolorMoustache(moustacheColor);
    }
}
