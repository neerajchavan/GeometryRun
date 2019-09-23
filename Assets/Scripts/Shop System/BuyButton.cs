using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public int runnerID;
    public TextMeshProUGUI buttonText;

    public void BuyRunner()
    {
        if(runnerID == 0)
        {
            Debug.Log("Runner ID not set!");
            return;
        }

        for(int i=0; i < RunnerShop.runnerShop.runnerList.Count; i++)
        {
            if(RunnerShop.runnerShop.runnerList[i].runnerID == runnerID && !RunnerShop.runnerShop.runnerList[i].bought && MainMenuManager.mainMenuManager.RequestMoney(RunnerShop.runnerShop.runnerList[i].runnerPrice))
            {
                //BUY RUNNER
                RunnerShop.runnerShop.runnerList[i].bought = true;
                MainMenuManager.mainMenuManager.ReduceMoney(RunnerShop.runnerShop.runnerList[i].runnerPrice);
                //Set Runner ID
                MainMenuManager.mainMenuManager.CurrentRunnerID = runnerID;
                UpdateBuyButton();
            }

            else if(RunnerShop.runnerShop.runnerList[i].runnerID == runnerID && !RunnerShop.runnerShop.runnerList[i].bought && !MainMenuManager.mainMenuManager.RequestMoney(RunnerShop.runnerShop.runnerList[i].runnerPrice))
            {
                Debug.Log("Not enough Money!!");
                StartCoroutine(RunnerShop.runnerShop.showWarning());
            }

            else if(RunnerShop.runnerShop.runnerList[i].runnerID == runnerID && RunnerShop.runnerShop.runnerList[i].bought)
            {
                Debug.Log("Has been bougth already!! ");
                MainMenuManager.mainMenuManager.CurrentRunnerID = runnerID;
                UpdateBuyButton();

            }
        }

       //RunnerShop.runnerShop.UpdateSprite(runnerID);

    }

    void UpdateBuyButton()
    {
        /*buttonText.text = "Selected";
        //Chnage the runner,Depending upon ID. 
        for(int i=0; i<RunnerShop.runnerShop.buyButtonList.Count; i++)
        {
            BuyButton buyButtonScript = RunnerShop.runnerShop.buyButtonList[i].GetComponent<BuyButton>();
            for(int j=0; j<RunnerShop.runnerShop.runnerList.Count; j++)
            {
                //Has Baught
                if (RunnerShop.runnerShop.runnerList[j].runnerID == buyButtonScript.runnerID && RunnerShop.runnerShop.runnerList[j].bought && RunnerShop.runnerShop.runnerList[j].runnerID!= runnerID) 
                {
                    buyButtonScript.buttonText.text = "Select";
                }
            }
        }*/
        RunnerShop.runnerShop.UpdateBuyButtons(); 
        RunnerShop.runnerShop.UpdateSprite(runnerID);
    }
}
