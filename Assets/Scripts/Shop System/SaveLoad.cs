using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public List<Runner> shopList = new List<Runner>();
        public int money, hiScore;
        public int currentRunnnerID;
    }

    void Start()
    {
        Loading();  
    }

    public void Saving()
    {
        SaveData data = new SaveData();
        data.money = MainMenuManager.mainMenuManager.GetMoneyInfo();
        data.currentRunnnerID = MainMenuManager.mainMenuManager.CurrentRunnerID;
        //Add all the runners from RunnerList.
        for(int i=0; i<RunnerShop.runnerShop.runnerList.Count; i++)
        { 
           data.shopList.Add(RunnerShop.runnerShop.runnerList[i]);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/engineer.fun",FileMode.Create);

        bf.Serialize(stream, data);
        stream.Close();
        print("Saved!");
    }

    public void Loading()
    {
        if(File.Exists(Application.persistentDataPath + "/engineer.fun"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/engineer.fun",FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(stream);
            MainMenuManager.mainMenuManager.SetMoneyInfro(data.money);
            MainMenuManager.mainMenuManager.CurrentRunnerID = data.currentRunnnerID;
            stream.Close();

            for(int i=0; i< data.shopList.Count; i++)
            {
                //Update Shop
                RunnerShop.runnerShop.runnerList[i] = data.shopList[i];
                //Update All Sprites
                RunnerShop.runnerShop.UpdateSprite(RunnerShop.runnerShop.runnerList[i].runnerID);
                //Update All Buttons
                RunnerShop.runnerShop.UpdateBuyButtons();
            }
        }
       else
        {
            Debug.Log("File Not Found!");
        }
    }

    public void DeleteFile()
    {
        if(File.Exists(Application.persistentDataPath + "/engineer.fun"))
        {
            File.Delete(Application.persistentDataPath + "/engineer.fun");
            Debug.Log("File Deleted!");
        }
    }
}
