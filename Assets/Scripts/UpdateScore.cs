using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

    public GameObject levelLoader;

    public GameObject FirebaseController;

    public ScrollRect gamePanel;

    public RectTransform panelL2;

    public RectTransform panelL1;

    public GameObject copy_panelL2;

    public GameObject copy_panelL1;

    public GameObject levelCompletedScreen;

    private static int par= 30;
	// Use this for initialization
	void Awake () {
		BuildAncestorAndScore.changescore += UpdateScoreBoard;
            
    }
    public static int level = 1;
    private static int stage = 0;

    // Update is called once per frame
    public void UpdateScoreBoard () {
        GetComponent<Text>().color = new Color(0.9254f, 0.7176f, 0.1647f, 1);//giving yellow collor to the score label
        switch (level) {
            case 1:
                switch (stage)
                {
                    case 0:
                        GetComponentsInChildren<Image>()[10].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[14].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[18].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[19].color = new Color(255, 255, 255, 255);
                        stage = 1;
                        break;
                    case 1:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            GetComponentsInChildren<Image>()[11].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[15].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[20].color = new Color(255, 255, 255, 255);


                            List<Image> nextSeq = new AddSprites().GenerateSequence(new string[] { "S", "C", "B", "B", "B", "C", "B", "C", "C", "C", "C", "S", "C", "A", "A", "C", "A" }, -1858, 0, 3);
                            BuildAncestorAndScore.generatedSeqs.Add("3", nextSeq);
                            BuildAncestorAndScore.generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(1,2)"], BuildAncestorAndScore.generatedSeqs["3"], "A(A12,3)");
                            //BuildAncestorAndScore.buildAncestor();
                            stage = 2;
                            par = 52;
                            levelLoader.SetActive(true);
                            //BuildAncestorAndScore.buildAncestor();


                        }
                        break;
                    case 2:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            GetComponentsInChildren<Image>()[12].color = new Color(255, 255, 255, 255);  //tree branches image
                            GetComponentsInChildren<Image>()[16].color = new Color(255, 255, 255, 255);  // middle button
                            GetComponentsInChildren<Image>()[21].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[22].color = new Color(255, 255, 255, 255);
                            List<Image> nextSeq1 = new AddSprites().GenerateSequence(new string[] { "A", "B", "B", "A", "B", "B", "B", "C", "S", "D", "C", "C", "C", "C", "B", "D", "A", "C", "C", "A" }, -1858, -152, 4);
                            BuildAncestorAndScore.generatedSeqs.Add("4", nextSeq1);
                            List<Image> nextSeq2 = new AddSprites().GenerateSequence(new string[] { "B", "B", "B", "C", "A", "S", "B", "B", "C", "C", "B", "B", "S", "C", "C", "C", "A", "A", "C", "A", "D", "A" }, -1858, -304, 5);
                            BuildAncestorAndScore.generatedSeqs.Add("5", nextSeq2);//BBBCABBCCBBCCCAACADA
                            BuildAncestorAndScore.generateAncesSeq(nextSeq1, nextSeq2, "A(4,5)");
                            //BuildAncestorAndScore.buildAncestor();
                            stage = 3;
                            par = 11;

                            //GetComponentsInChildren<Button>()[0].interactable = false;
                            //GetComponentsInChildren<Button>()[1].interactable = false;
                            foreach (string key in BuildAncestorAndScore.generatedSeqs.Keys)
                            {
                                if (key != "4" & key != "5" & key != "A(4,5)" & key.Length == 1)
                                {
                                    BuildAncestorAndScore.DisableSequence(key);
                                }

                            }
                            levelLoader.SetActive(true);
                            //BuildAncestorAndScore.buildAncestor();
                        }
                        break;
                    case 3:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponentsInChildren<Image>()[13].color = new Color(255, 255, 255, 255);  //tree branches image
                            GetComponentsInChildren<Image>()[17].color = new Color(255, 255, 255, 255);  // middle button
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            BuildAncestorAndScore.generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(A12,3)"], BuildAncestorAndScore.generatedSeqs["A(4,5)"], "A(A(A12,3),A(4,5))");
                            Debug.Log(BuildAncestorAndScore.generatedSeqs["A(A(A12,3),A(4,5))"]);
                            foreach (string key in BuildAncestorAndScore.generatedSeqs.Keys)
                            {
                                if (key != "4" & key != "5" & key != "A(4,5)" & key.Length == 1)
                                {
                                    BuildAncestorAndScore.EnableSequence(key);

                                }

                            }
                            
                            stage = 4;
                            par = 76;
                            levelLoader.SetActive(true);
                        }

                        break;
                    case 4:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            levelCompletedScreen.SetActive(true);
                            BuildAncestorAndScore.level = 2;
                            level = 2;
                            stage = 0;
                            FirebaseConnection.SaveLevelDetails();
                        }

                        break;
                    default:
                        break;
                }
                break;

            case 2:
                switch (stage) {
                    case 0:
                        //int x = 23;
                        List<Transform> imgList = new List<Transform>();
                        for (int i = 11; i < 23; i++)
                        {
                            imgList.Add(GetComponentsInChildren<Transform>()[i]);
                            GetComponentsInChildren<Image>()[i].color = new Color(255, 255, 255, 0);
                            //GetComponentsInChildren<Transform>()[i].parent = null;
                           
                        }//Remove level 1 tree structure
                        foreach (Transform img in imgList)
                        {
                            Debug.Log(img.name);
                            img.parent = null;
                        }//Remove level 1 tree structure

                        foreach (string key in BuildAncestorAndScore.generatedSeqs.Keys)
                        {
                            foreach (Image img in BuildAncestorAndScore.generatedSeqs[key])
                            {
                                img.transform.SetParent(null,false);
                                img.color = new Color(255, 255, 255, 0);
                                //Destroy(img);
                            }
                        }

                        AddSprites.setPanel(panelL2.transform);
                        BuildAncestorAndScore.panel = panelL2.transform;
                        copy_panelL1.SetActive(false);
                        copy_panelL2.SetActive(true);

                        gamePanel.content = panelL2;
                      

                        //gamePanel.content = panelL2;

                        BuildAncestorAndScore.disabledSeqs = new Dictionary<string, List<float>>();
                        BuildAncestorAndScore.generatedSeqs = new Dictionary<string, List<Image>>();
                        GetComponentsInChildren<Image>()[0].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[3].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[6].color = new Color(255, 255, 255, 255);
                        GetComponentsInChildren<Image>()[7].color = new Color(255, 255, 255, 255);
                        par = 30;
                        stage = 1;
                        Debug.Log("Level 2");
                        break;
                    case 1:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            GetComponentsInChildren<Image>()[1].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[4].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[8].color = new Color(255, 255, 255, 255);


                            List<Image> nextSeq = new AddSprites().GenerateSequence(new string[] { "S", "C", "B", "B", "B", "C", "B", "C", "C", "C", "C", "S", "C", "A", "A", "C", "A" }, -1858, 0, 3);
                            BuildAncestorAndScore.generatedSeqs.Add("3", nextSeq);
                            BuildAncestorAndScore.generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(1,2)"], BuildAncestorAndScore.generatedSeqs["3"], "A(A12,3)");
                            //BuildAncestorAndScore.buildAncestor();
                            stage = 2;
                            par = 52;
                            levelLoader.SetActive(true);
                            //BuildAncestorAndScore.buildAncestor();


                        }
                        break;
                    case 2:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            GetComponentsInChildren<Image>()[2].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[5].color = new Color(255, 255, 255, 255);
                            GetComponentsInChildren<Image>()[9].color = new Color(255, 255, 255, 255);

                            List<Image> nextSeq1 = new AddSprites().GenerateSequence(new string[] { "A", "B", "B", "A", "B", "B", "B", "C", "S", "D", "C", "C", "C", "C", "B", "D", "A", "C", "C", "A" }, -1858, -152, 4);
                            BuildAncestorAndScore.generatedSeqs.Add("4", nextSeq1);
                            BuildAncestorAndScore.generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(A12,3)"], BuildAncestorAndScore.generatedSeqs["4"], "A(A(A12,3),4)");
                            //BuildAncestorAndScore.buildAncestor();
                            stage = 3;
                            par = 64;
                            levelLoader.SetActive(true);
                        }
                        break;
                    case 3:
                        if (BuildAncestorAndScore.score2 >= par)
                        {
                            GetComponent<Text>().color = new Color(0, 1, 0, 1);
                            levelCompletedScreen.SetActive(true);
                            BuildAncestorAndScore.level = 3;
                            level = 3;
                            stage = 0;
                            FirebaseConnection.SaveLevelDetails();
                        }
                        break;
                    default:
                        break;

                }
                break;
            case (3):
                switch (stage) {
                    case 0: break;
                    default: break;
                }
                break;
        }
        

        GetComponent<Text>().text = "Score: "+BuildAncestorAndScore.score2;

    }
}
