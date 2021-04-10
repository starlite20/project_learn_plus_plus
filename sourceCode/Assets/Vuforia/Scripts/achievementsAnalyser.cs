using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

//A Class to handle the Gamification functionality of Project Learn++
public class achievementsAnalyser : MonoBehaviour
{
    /*  
        ACHIEVEMENTS SLOT REFERENCES
        SLOT 0 = AHLAAN
        SLOT 1 = DOCTOR
        SLOT 2 = WEATHER
        SLOT 3 = CRYPTKING
        SLOT 4 = COVID
        SLOT 5 = EXPERT LEARNER
        SLOT 6 = STUDIOUS
        SLOT 7 = STEADY LEARNER
        SLOT 8 = GAMECHAMP
        SLOT 9 = TRUE AR LEARNER
    */

    int[] achievementsDataArray = new int[10];
    public GameObject achievementsCounter;
    int achievementsCount = 0;
    int currentAchievement;
    Scene currentScene;
    int scene_status = 0;

    public Slider progressSlider;
    float achievementProgress = 0.5f;
    public GameObject progressValueObj, progressTextObj, quoteObject;
    int remainingProgress=0;

    string quotesMerged;
    int randomQuote = -1;


    public void loadAchievements ()
    {
        achievementsDataArray = monitorActivity.getAchievementsArray();
        //Debug.Log("loader achievementsUnlocker");
    }

    //Sets the Achievements as Unlocked if it is active
    public void achievementsUnlocker (Text ach0, Text ach1, Text ach2, Text ach3, Text ach4, Text ach5, Text ach6, Text ach7, Text ach8, Text ach9)
    {
        //Debug.Log("in achievementsUnlocker");

        if(achievementsDataArray[0] == 1)
        {
            achievementUnlocker(ach0);
        }
        
        if(achievementsDataArray[1] == 1)
        {
            achievementUnlocker(ach1);
        }

        if(achievementsDataArray[2] == 1)
        {
            achievementUnlocker(ach2);
        }

        if(achievementsDataArray[3] == 1)
        {
            achievementUnlocker(ach3);
        }

        if(achievementsDataArray[4] == 1)
        {
            achievementUnlocker(ach4);
        }

        if(achievementsDataArray[5] == 1)
        {
            achievementUnlocker(ach5);
        }

        if(achievementsDataArray[6] == 1)
        {
            achievementUnlocker(ach6);
        }

        if(achievementsDataArray[7] == 1)
        {
            achievementUnlocker(ach7);
        }

        if(achievementsDataArray[8] == 1)
        {
            achievementUnlocker(ach8);
        }

        if(achievementsDataArray[9] == 1)
        {
            achievementUnlocker(ach9);
        }
    }

    //Resets the Achievements as Locked for initialising.
    public void resetAchievements(Text ach0, Text ach1, Text ach2, Text ach3, Text ach4, Text ach5, Text ach6, Text ach7, Text ach8, Text ach9)
    {
        achievementLocker(ach0);
        achievementLocker(ach1);
        achievementLocker(ach2);
        achievementLocker(ach3);
        achievementLocker(ach4);

        achievementLocker(ach5);
        achievementLocker(ach6);
        achievementLocker(ach7);
        achievementLocker(ach8);
        achievementLocker(ach9);
    }

    void achievementLocker(Text currentAchievement)
    {
        currentAchievement.text = "LOCKED!";
        currentAchievement.color = Color.red;
    }

    void achievementUnlocker(Text currentAchievement)
    {
        currentAchievement.text = "UNLOCKED!";
        currentAchievement.color = Color.green;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("open profile");
        scene_status = 1;
        achievementsCount = 0;
        remainingProgress=0;
        achievementProgress=0.0f;
        randomQuote = -1;
        
        string quotesFile = "motivationalquotes";
        TextAsset quotesAsset = (TextAsset)Resources.Load(quotesFile);
        calculateProgress();
        quoteGenerator(quotesAsset);

        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "profileScene")
            scene_status = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(scene_status == 1)
        {
            achievementsDataArray = monitorActivity.getAchievementsArray();

            for( currentAchievement=0; currentAchievement<9; currentAchievement++)
            {
                achievementsCount += achievementsDataArray[currentAchievement];
            }

            achievementsCounter.GetComponent<Text>().text = achievementsCount.ToString();
            scene_status = 2;
            Debug.Log("ach updater done");
        }
    }

    void calculateProgress()
    {
        loadAchievements();

        for(currentAchievement=0;currentAchievement<10;currentAchievement++)
        {
            achievementProgress += achievementsDataArray[currentAchievement];
        }

        achievementProgress /= 10;
        remainingProgress = (int)(100-(achievementProgress * 100));

        progressSlider.value = achievementProgress;
    
        if(achievementProgress <= 0.4f)
        {
            progressTextObj.GetComponent<Text>().text = ("YOUR PROGRESS");
            progressValueObj.GetComponent<Text>().text = (remainingProgress + " XP MORE TO GO");
        }

        else if( (0.41 <= achievementProgress) && (achievementProgress <= 0.9f) )
        {
            progressTextObj.GetComponent<Text>().text = ("GREAT GOING");
            progressValueObj.GetComponent<Text>().text = (remainingProgress + " XP MORE TO GO");
        }

        else
        {
            progressTextObj.GetComponent<Text>().text = ("YOU ARE AMAZING");
            progressValueObj.GetComponent<Text>().text = ("MORE CHAPTERS WILL BE COMING UP");
        }

        Debug.Log("progress calculated");
    }

    //Selects a Random Quote to be displayed
    void quoteGenerator(TextAsset quotesAsset)
    {
        quotesMerged = quotesAsset.text;

        //Splits the string into an array of strings
        string[] quotes = quotesMerged.Split('@');

        if (randomQuote == -1)
        {
            randomQuote = (Random.Range( 0, (quotes.Length - 1) ));
            quoteObject.GetComponent<Text>().text = quotes[randomQuote];
        }
    }
}
