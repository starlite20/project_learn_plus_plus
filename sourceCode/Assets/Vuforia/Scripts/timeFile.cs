using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The timeFile helps in bringing simplified data regarding
//the achievements and data regarding time spent during the learning
//process.

//This file is updated in a frequent manner to create a more
//accurate gamification process.

[System.Serializable]
public class timeFile 
{
    int[] achievementsArray_sav = new int[10];
    int[] chaptersReadCount_sav = new int[10];
    float[] totalTimeLearning_sav = new float[10];

    public timeFile (monitorActivity MA)
    {
        totalTimeLearning_sav = monitorActivity.getTotalTimeOfLearning();
        chaptersReadCount_sav = monitorActivity.getChaptersReadCount();
        achievementsArray_sav = monitorActivity.getAchievementsArray();
    }

    public int[] getChaptersReadCount_sav()
    {
        return chaptersReadCount_sav;
    }

    public int[] getAchievementsArray_sav()
    {
        return achievementsArray_sav;
    }

    public float[] getTotalTimeLearning_sav()
    {
        return totalTimeLearning_sav;
    }
}
