using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerShop : MonoBehaviour
{
    public static RunnerShop runnerShop;
    public List<Runner> runnerList = new List<Runner>();
    private List<GameObject> itemHolderList = new List<GameObject>();
    public List<GameObject> buyButtonList = new List<GameObject>();
    public GameObject itemHolderPrefab;
    public Transform grid;
    public GameObject NoMoneyPanel;
    private bool NoMoneyActive = false;


    // Start is called before the first frame update
    void Start()
    {
        NoMoneyPanel.SetActive(false);
        runnerShop = this;
        FillList(); 
    }

   void FillList()
    {
        for (int i = 0; i < runnerList.Count; i++)
        {
            GameObject holder = Instantiate(itemHolderPrefab, grid, false);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>();

            holderScript.itemName.text = runnerList[i].runnerName;
            holderScript.itemPrice.text = runnerList[i].runnerPrice.ToString("0");
            holderScript.itemID = runnerList[i].runnerID;

            //Buy Button
            holderScript.buyButton.GetComponent<BuyButton>().runnerID = runnerList[i].runnerID;

            //Handle List
            itemHolderList.Add(holder);
            buyButtonList.Add(holderScript.buyButton);

            if (runnerList[i].bought == true)
            {
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + runnerList[i].SpriteName);
            }
            else
            {
                holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + runnerList[i].SpriteName + "_black");
            }
        }
    }

    public void UpdateSprite(int runnerID)
    {
        for(int i=0; i<itemHolderList.Count; i++)
        {
           ItemHolder holderScript =  itemHolderList[i].GetComponent<ItemHolder>();
            if(holderScript.itemID == runnerID)
            {
                for(int j =0; j<runnerList.Count; j++)
                {
                    if(runnerList[j].runnerID == runnerID)
                    {
                        if (runnerList[j].bought == true)
                        {
                            holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + runnerList[i].SpriteName);
                            holderScript.itemPrice.text = "Bought!";
                        }
                        else
                        {
                            holderScript.itemImage.sprite = Resources.Load<Sprite>("Sprites/" + runnerList[i].SpriteName + "_black");
                        }
                    }
                }
            }
        }
    }

    public void UpdateBuyButtons()
    {
        int currenrRunnerID = MainMenuManager.mainMenuManager.CurrentRunnerID;
        for(int i=0; i<buyButtonList.Count; i++)
        {
            BuyButton buyButtonScript = buyButtonList[i].GetComponent<BuyButton>();
            for(int j=0; j<runnerList.Count; j++)
            {
                if(runnerList[j].runnerID == buyButtonScript.runnerID && runnerList[j].bought && runnerList[j].runnerID != currenrRunnerID)
                {
                    buyButtonScript.buttonText.text = "Select";
                }
                else if(runnerList[j].runnerID == buyButtonScript.runnerID && runnerList[j].bought && runnerList[j].runnerID == currenrRunnerID)
                {
                    buyButtonScript.buttonText.text = "Selected";

                }
            }
        }
    }

    public IEnumerator showWarning()
    {
        if(NoMoneyActive)
        {
            yield break;
        }

        NoMoneyActive = true;

        NoMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(1.4f);

        NoMoneyPanel.SetActive(false);
        NoMoneyActive = false;
    }

}
