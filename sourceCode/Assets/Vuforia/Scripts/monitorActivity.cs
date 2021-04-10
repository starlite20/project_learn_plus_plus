using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monitorActivity : MonoBehaviour
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
    public static int[] achievementsArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; //10 var

    /*  
        CHAPTER SLOT REFERENCES
        SLOT 0 = WATERCYCLE
        SLOT 1 = HEART
        SLOT 2 = CAESER
        SLOT 4 = COVID
        (currently ony 4 chapters active)
    */
    public static int[] chaptersReadCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};  //10 var
    
    static float startTimeOfLearning, elapsedTimeOfLearning = 0.0f;
    public static float[] totalTimeOfLearning = new float []{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
    public Text ach0, ach1, ach2, ach3, ach4, ach5, ach6, ach7, ach8, ach9;
    
    int currentItem, trueLearnerFlag;
    float sumTime = 0.0f;

    achievementsAnalyser achievementsObject = new achievementsAnalyser();

    void Start() 
    {
        sumTime = 0.0f;
        currentItem = 0;
        trueLearnerFlag = 0;
        achievementsObject.resetAchievements(ach0, ach1, ach2, ach3, ach4, ach5, ach6, ach7, ach8, ach9);

        //Checks whether file exists and loads the file. Else creates a new blank file. 
        if( saveSystemTwo.loadFileTwo() == null )
        {
            //create initial blank file
            saveSystemTwo.saveFileTwo(this);
            Debug.Log("No time file detected");
            sumTime = 0.0f;
            startTimeOfLearning = elapsedTimeOfLearning = 0.0f;
        }
        else
        {
            //open old file
            Debug.Log("Time file detected");
            timeFile data = saveSystemTwo.loadFileTwo();

            totalTimeOfLearning = data.getTotalTimeLearning_sav();
            chaptersReadCount = data.getChaptersReadCount_sav();

            achievementsArray = data.getAchievementsArray_sav();
        }
    }

    public static void userLearnCounter(string chapterName)
    {
        //Tracks the number of times the particular chapter is learnt
        startTimeOfLearning = Time.time;

        if(chapterName == "HRT")  //SLOT 1
        {
            chaptersReadCount[1] += 1;
        }

        else if(chapterName == "WC")  //SLOT 2
        {
            chaptersReadCount[2] += 1;
        }

        else if(chapterName == "CSR") // SLOT 3
        {
            chaptersReadCount[3] += 1;
        }

        else if(chapterName == "CVD") // SLOT 4
        {
            chaptersReadCount[4] += 1;
        }

        else
        {
            Debug.Log(chapterName + " chapter not available");
        }
    }

    public static void userLearnTimeCalc(string chapterName)
    {
        //Tracks the amount of time the person is studying
        elapsedTimeOfLearning = Time.time - startTimeOfLearning;

        if(chapterName == "WC")  //SLOT 2
        {
            totalTimeOfLearning[2] += elapsedTimeOfLearning;
            Debug.Log("TIME TOT = " + totalTimeOfLearning[2]);
        }

        else if(chapterName == "HRT")  //SLOT 1
        {
            totalTimeOfLearning[1] += elapsedTimeOfLearning;
            Debug.Log("TIME TOT = " + totalTimeOfLearning[1]);
        }
        
        else if(chapterName == "CSR") // SLOT 3
        {
            totalTimeOfLearning[3] += elapsedTimeOfLearning;
            Debug.Log("TIME TOT = " + totalTimeOfLearning[3]);
        }

        else if(chapterName == "CVD") // SLOT 4
        {
            totalTimeOfLearning[4] += elapsedTimeOfLearning;
            Debug.Log("TIME TOT = " + totalTimeOfLearning[4]);
        }
    }

    public void onClickAchievementsButton()
    {
        timeFile data = saveSystemTwo.loadFileTwo();

        totalTimeOfLearning = data.getTotalTimeLearning_sav();
        chaptersReadCount = data.getChaptersReadCount_sav();

        achievementsObject.loadAchievements();
        Debug.Log("File loaded!");

        achievementsObject.achievementsUnlocker(ach0, ach1, ach2, ach3, ach4, ach5, ach6, ach7, ach8, ach9);
    }

    public void achievementDetector()
    {
        Debug.Log("in ACHIEVEMENT calc" + achievementsArray[0]);
        
        //ACHIEVEMENT SLOT 0 = AHLAAN
        if(achievementsArray[0] == 0)
        {
            achievementsArray[0] = 1;
        }
        
        //ACHIEVEMENT SLOT 1 = DOCTOR
        if( (chaptersReadCount[1] > 0) && (achievementsArray[1] == 0) )
        {
            achievementsArray[1] = 1;
        }

        //ACHIEVEMENT SLOT 2 = WEATHER
        if((chaptersReadCount[2] > 0) && (achievementsArray[2] == 0) )
        {
            achievementsArray[2] = 1;
        }
        
        //ACHIEVEMENT SLOT 3 = CAESER
        if( (chaptersReadCount[3] > 0) && (achievementsArray[3] == 0) && (totalTimeOfLearning[3] > 3.0f) )
        {   
            achievementsArray[3] = 1; 
        }

        //ACHIEVEMENT SLOT 4 = COVID
        if( (chaptersReadCount[4] > 0) && (achievementsArray[4] == 0) )
        {   
            achievementsArray[4] = 1; 
        }

        //ACHIEVEMENT SLOT 5 = STEADY LEARNER
        if( (achievementsArray[5] == 0) )
        {
            sumTime = 0.0f;
            for(currentItem=0;currentItem<10;currentItem++)
            {
                sumTime += totalTimeOfLearning[currentItem];
            }   
            if(sumTime > 45.0f)
                achievementsArray[5] = 1;
        }   

        //ACHIEVEMENT SLOT 6 = STUDIOUS HEAD
        if( (achievementsArray[6] == 0) )
        {
            sumTime = 0.0f;
            for(currentItem=0;currentItem<10;currentItem++)
            {
                sumTime += chaptersReadCount[currentItem];
            }   
            if(sumTime > 15.0f)
                achievementsArray[6] = 1;
        }  

        //ACHIEVEMENT SLOT 7 = STEADY LEARNER
        if( (achievementsArray[7] == 0) && (achievementsArray[5] == 1) && (achievementsArray[6] == 1) )
        {
            achievementsArray[7] = 1;
        }

        //ACHIEVEMENT SLOT 9  = TRUE AR LEARNER
        if( (achievementsArray[9] == 0) )
        {
            trueLearnerFlag = 0;
            for(currentItem=0;currentItem<8;currentItem++)
            {
                if(achievementsArray[currentItem] == 0)
                {
                    trueLearnerFlag = 1;
                    break;
                }
            }

            if(trueLearnerFlag == 0)
                achievementsArray[9] = 1;
        }

        Debug.Log("out ACHIEVEMENT calc");
    }

    public void onClickMenuButton()
    {
        //Achievement Detection
        achievementDetector();

        //Saves currentItem details generated during runtime
        saveSystemTwo.saveFileTwo(this);
        Debug.Log("Save completed");
    }

    public static float[] getTotalTimeOfLearning()
    {
        return totalTimeOfLearning;
    }

    public static int[] getChaptersReadCount()
    {
        return chaptersReadCount;
    }

    public static int[] getAchievementsArray()
    {
        return achievementsArray;
    }

    public void eraseAchievementsData()
    {
        currentItem = trueLearnerFlag = 0;
        sumTime = startTimeOfLearning = elapsedTimeOfLearning = 0.0f;

        for( currentItem=0 ; currentItem<10 ; currentItem++ )
        {
            achievementsArray[currentItem] = 0;
            chaptersReadCount[currentItem] = 0;
            totalTimeOfLearning[currentItem] = 0.0f;
        }

        saveSystemTwo.wipeFileTwo(); 
    }
    
}
