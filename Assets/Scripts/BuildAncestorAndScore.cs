using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildAncestorAndScore : MonoBehaviour
{

    [SerializeField]
    private Transform panel2;

    private static Transform panel;

    public delegate void changeScore();

    public static event changeScore changescore;

    private static List<List<Image>> puzzlesInRows;
    
    public static int score2;

    public static int  matches2;

    public static int  mismatches2;

    public static int gaps2;

    public static int extends2;

    public static Dictionary<string,List<Image>> generatedSeqs;

    public static Dictionary<string, List<float>> disabledSeqs;

    public static bool ran;


    public static bool isShown;


    public void showAnces_1() {
       
        showAncestor(generatedSeqs["A(1,2)"]);
    }

    public void showAnces_2()
    {
        
        showAncestor(generatedSeqs["A(A12,3)"]);
    }

    public void showAnces_3()
    {

        showAncestor(generatedSeqs["A(4,5)"]);
    }

    public void showAnces_4()
    {
        showAncestor(generatedSeqs["A(A(A12,3),A(4,5))"]);
    }

    void Awake()
    {
        panel = panel2;
        puzzlesInRows = AddSprites.puzzlesInRows;
        generatedSeqs = new Dictionary<string,List<Image>>();
        disabledSeqs = new Dictionary<string, List<float>>();
    }

    public static void showAncestor(List<Image> ancestorSeq) {
        if(isShown==false){ 
            for (int i = 0; i < ancestorSeq.Count; i++)
            {
                ancestorSeq[i].transform.SetParent(panel, false);
            }
            isShown = true;
        }
        else
        { 
            for (int i = 0; i < ancestorSeq.Count; i++)
            {
                ancestorSeq[i].transform.SetParent(null, false);
            }
            isShown = false;
        }
    }

    public static int CalMismatches(List<Image> firstSeq, List<Image> secondSeq) {
        int mismatches = 0;
        int index = 0;

        for (int i = 0; i < firstSeq.Count; i++)
        {
            if (firstSeq[i].color.a == 1 | firstSeq[i].color.a == 255)
            {
                int first = Mathf.RoundToInt(firstSeq[i].transform.localPosition.x);
                for (int j = index; j < secondSeq.Count; j++)
                {
                    if (secondSeq[j].color.a == 1 | secondSeq[j].color.a == 255)
                    {
                        int second = Mathf.RoundToInt(secondSeq[j].transform.localPosition.x);
                        if (second > first)
                        {
                            break;
                        }
                        else
                        {
                            index = j;
                            if (second == first)
                            {
                                if (firstSeq[i].tag != secondSeq[j].tag)
                                {   
                                    if((firstSeq[i].tag=="A")&(secondSeq[j].tag=="C")){
                                        mismatches+=1;
                                    }else if((firstSeq[i].tag=="A")&(secondSeq[j].tag=="C")){
                                        mismatches+=1;
                                    }else if((firstSeq[i].tag=="C")&(secondSeq[j].tag=="A")){
                                        mismatches+=1;
                                    }else if((firstSeq[i].tag=="B")&(secondSeq[j].tag=="D")){
                                        mismatches+=1;
                                    }else if((firstSeq[i].tag=="D")&(secondSeq[j].tag=="B")){
                                        mismatches+=1;
                                    }else{
                                        mismatches+=2;
                                    }
                                    
                                }

                            }
                        }
                    }
                }
            }
        }
        return mismatches;
    }

    public static int CalMatches(List<Image> ancesSeq, List<Image> childseq) {

        int matches = 0;
        int index = 0;
       
        int count = 0;

        string s = "";
        string s1 = "";
        for (int i = 0; i < ancesSeq.Count; i++)
        {
            if (ancesSeq[i].color.a == 1 | ancesSeq[i].color.a == 255)
            {
                s += ancesSeq[i].tag;
            }

        }
        for (int i = 0; i < childseq.Count; i++)
        {
            if (childseq[i].color.a == 1 | childseq[i].color.a == 255)
            {
                s1 += childseq[i].tag;
            }
            
        }
        //Debug.Log(s);
        //Debug.Log(s1);
        //Debug.Log(count+"/"+ ancesSeq.Count);
        for (int i = 0; i < ancesSeq.Count; i++)
        {
            //Debug.Log(ancesSeq[i].color.a );
            if (ancesSeq[i].color.a == 1 | ancesSeq[i].color.a == 255)
            {
                int first = Mathf.RoundToInt(ancesSeq[i].transform.localPosition.x);
                for (int j = index; j < childseq.Count; j++)
                {
                    //Debug.Log(childseq[j].color.a );
                    if (childseq[j].color.a == 1 | childseq[j].color.a == 255)
                    {
                        int second = Mathf.RoundToInt(childseq[j].transform.localPosition.x);
                        if (second > first)
                        {
                            index = j;
                            break;
                        }
                        else
                        {
                            if (second == first)
                            {

                                if (ancesSeq[i].tag.Equals(childseq[j].tag))
                                {
                                    //Debug.Log("1)"+i+" "+ ancesSeq[i].tag+ " "+ ancesSeq[i].transform.localPosition.x+" "+ ancesSeq[i].color.a);
                                    //Debug.Log("2)"+j+" "+ childseq[j].tag + " "+ childseq[j].transform.localPosition.x+" "+ childseq[j].color.a);
                                    matches++;
                                }
                                index = j + 1;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                }

            }
        }

        return matches;
    }

    public static List<int> CalGaps(List<Image> firstSeq, List<Image> secondSeq) {
        List<int> XPositionsOfFirst = new List<int>();
        List<int> XPositionsOfSecond = new List<int>();

        //if one of the input sequences is an ancestor then,
        List<Image> copyOfFirst = new List<Image>();//this is to remove any issue caused by invisible puzzzles in ancestor sequence
        List<Image> copyOfSecond = new List<Image>();//this is to remove any issue caused by invisible puzzzles in ancestor sequence

        BubbleSort(firstSeq);
        BubbleSort(secondSeq);
      
        for (int z = 0; z < firstSeq.Count; z++){
            if (firstSeq[z].color.a == 255 | firstSeq[z].color.a == 1) {
                XPositionsOfFirst.Add(Mathf.RoundToInt(firstSeq[z].transform.localPosition.x));
                copyOfFirst.Add(firstSeq[z]);
            }
        }

        for (int w = 0; w < secondSeq.Count; w++){
            if (secondSeq[w].color.a == 255 | secondSeq[w].color.a == 1)
            {
                XPositionsOfSecond.Add(Mathf.RoundToInt(secondSeq[w].transform.localPosition.x));
                copyOfSecond.Add(secondSeq[w]);
            }
        }

        int gaps = 0;
        int extends = 0;
        //counting gaps in first seq
        for (int i = 1; i < copyOfFirst.Count; i++) {
          // if ((firstSeq[i].color.a == 255 | firstSeq[i].color.a == 1) & (firstSeq[i - 1].color.a == 255 | firstSeq[i - 1].color.a == 1))
           // {
                int ConsecGaps = (Mathf.RoundToInt(copyOfFirst[i].transform.localPosition.x) - Mathf.RoundToInt(copyOfFirst[i - 1].transform.localPosition.x)) / 152;
                ConsecGaps--;
                if (ConsecGaps > 0)
                {
                    int spaces = ConsecGaps;
                    for (int k = 1; k <= spaces; k++)
                    {
                        // Debug.Log((Mathf.RoundToInt(firstSeq[i - 1].transform.localPosition.x) + k * 152));
                        if (!XPositionsOfSecond.Contains(Mathf.RoundToInt(copyOfFirst[i - 1].transform.localPosition.x) + k * 152))
                        {
                            ConsecGaps--;
                        }
                    }
                    //Debug.Log("consec gaps " + ConsecGaps);
                    if (ConsecGaps > 0)
                    {
                        gaps += 1;
                        extends += (ConsecGaps - 1);
                        //Debug.Log(ConsecGaps);
                    }
                }
           // }
        }

        //counting gaps in second seq
          for (int i = 1; i < copyOfSecond.Count; i++)
         {
           // if ((secondSeq[i].color.a == 255 | secondSeq[i].color.a == 1) & (secondSeq[i - 1].color.a == 255 | secondSeq[i - 1].color.a == 1))
            //{
                int ConsecGaps = (Mathf.RoundToInt(copyOfSecond[i].transform.localPosition.x) - Mathf.RoundToInt(copyOfSecond[i - 1].transform.localPosition.x)) / 152;
                ConsecGaps--;
                if (ConsecGaps > 0)
                {
                    int spaces = ConsecGaps;
                    for (int k = 1; k <= spaces; k++)
                    {
                        if (!XPositionsOfFirst.Contains(Mathf.RoundToInt(copyOfSecond[i - 1].transform.localPosition.x) + k * 152))
                        {
                            ConsecGaps--;
                        }
                    }
                    if (ConsecGaps > 0)
                    {
                        gaps += 1;
                        extends += (ConsecGaps - 1);
                        //Debug.Log(ConsecGaps);
                    }
                }
            //}
         }
        List<int> gapsAndExtends = new List<int>();

        gapsAndExtends.Add(gaps);
        gapsAndExtends.Add(extends);
        //Debug.Log(gaps2+" "+ extends2);
        return gapsAndExtends;
    }

    public static List<int> CalScore(List<Image> firstSeq, List<Image> secondSeq, List<Image> ancesSeq) {

        List<int> scoreArr = new List<int>();
        List<int> gapsAndExtends = CalGaps(firstSeq, secondSeq);

        //Debug.Log(CalMatches(generatedSeqs["1 2"], firstSeq)+" "+ CalMatches(generatedSeqs["1 2"], secondSeq));
        int matches = CalMatches(ancesSeq, firstSeq) + CalMatches(ancesSeq, secondSeq);
        int mismatches = CalMismatches(firstSeq, secondSeq);

        scoreArr.Add(matches);
        scoreArr.Add(mismatches);
        scoreArr.Add(gapsAndExtends[0]);
        scoreArr.Add(gapsAndExtends[1]);

        //execute delegates that score is ready to display

        return scoreArr;
    }

    public static void generateAncesSeq(List<Image> firstSeq, List<Image> secondSeq, string id) {

        List<Image> ancestorSeq;
        if (generatedSeqs.ContainsKey(id)) {
            ancestorSeq = generatedSeqs[id];
        }else {
            ancestorSeq = new List<Image>();

            for (int i = 0; i < firstSeq.Count; i++)
            {
                Image img = Instantiate(firstSeq[i]);
                //Debug.Log(img.name);
                img.transform.localPosition = new Vector2(img.transform.localPosition.x, -550);
                ancestorSeq.Add(img);
                //img.color = new Color(255, 255, 255, 255);
                img.GetComponent<Collider2D>().enabled = false;
                img.GetComponent<Draggable>().enabled = false;
                //img.transform.SetParent(panel, false);
            }

            for (int i = 0; i < secondSeq.Count; i++)
            {
                Image img = Instantiate(secondSeq[i]);
                //Debug.Log(img.name);
                img.transform.localPosition = new Vector2(img.transform.localPosition.x, -550);
                ancestorSeq.Add(img);
                //img.color = new Color(255, 255, 255, 255);
                img.GetComponent<Collider2D>().enabled = false;
                img.GetComponent<Draggable>().enabled = false;
                //img.transform.SetParent(panel, false);
            }
        }


        

        int start1 = Mathf.RoundToInt(firstSeq[0].transform.localPosition.x);
        int start2 = Mathf.RoundToInt(secondSeq[0].transform.localPosition.x);
        

        int end1 = Mathf.RoundToInt(firstSeq[firstSeq.Count - 1].transform.localPosition.x);
        int end2 = Mathf.RoundToInt(secondSeq[secondSeq.Count - 1].transform.localPosition.x);
  


        Dictionary<string, int> nameList = new Dictionary<string, int>();

        /////////////////
        List<int> XPositions = new List<int>();
        //List<int> XPositionsOfSecond = new List<int>();

        for (int z = 0; z < firstSeq.Count; z++)
        {
            int currentStart = Mathf.RoundToInt(firstSeq[z].transform.localPosition.x);
            int currentEnd = Mathf.RoundToInt(firstSeq[z].transform.localPosition.x);
            
            if (firstSeq[z].color.a == 1 | firstSeq[z].color.a == 255) {
                //Debug.Log("visible 2");
                if (currentStart < start1)
                {
                    start1 = currentStart;
                }
                if (end1 < currentEnd)
                {
                    end1 = currentEnd;
                }
                XPositions.Add(Mathf.RoundToInt(firstSeq[z].transform.localPosition.x));
            }
        }

        for (int w = 0; w < secondSeq.Count; w++)
        {
            
            int currentStart = Mathf.RoundToInt(secondSeq[w].transform.localPosition.x);
            int currentEnd = Mathf.RoundToInt(secondSeq[w].transform.localPosition.x);

            //Debug.Log(secondSeq[w].color.Equals(new Color(1,1,1,1)) + " "+secondSeq[w].color.r+" " + secondSeq[w].color.g+ " " + secondSeq[w].color.b);
            if (secondSeq[w].color.a == 1 | secondSeq[w].color.a == 255)
            {
               // Debug.Log("visible 1");
                if (currentStart < start2)
                {
                    start2 = currentStart;
                }

                if (end2 < currentEnd)
                {
                    end2 = currentEnd;
                }
                if (!XPositions.Contains(Mathf.RoundToInt(secondSeq[w].transform.localPosition.x))) {
                    //Debug.Log("sdg");
                    XPositions.Add(Mathf.RoundToInt(secondSeq[w].transform.localPosition.x));
                }
                
            }
        }

        //have the ancestor's fisrt and end x position
        int start = Mathf.Min(start1, start2);
        int end = Mathf.Max(end1, end2);
        ////////////////

        for (int i = start; i <= end; i = i + 152)
        {
            if (XPositions.Contains(i))
            {
                bool found = false;
                for (int t = 0; t < firstSeq.Count; t++)
                {
                    if (Mathf.RoundToInt(firstSeq[t].transform.localPosition.x) == i)
                    {
                        if (firstSeq[t].color.a == 1 | firstSeq[t].color.a == 255)
                        {
                            nameList.Add(firstSeq[t].name + "(Clone)", i);
                            found = true;
                        }
                    }
                }
                if (!found) { 
                for (int t = 0; t < secondSeq.Count; t++)
                    {
                        if (Mathf.RoundToInt(secondSeq[t].transform.localPosition.x) == i)
                        {
                            if (secondSeq[t].color.a == 1 | secondSeq[t].color.a == 255)
                            {
                                nameList.Add(secondSeq[t].name + "(Clone)", i);
                            }
                        }
                    }
                }
            }
        }

        for (int q = 0; q < ancestorSeq.Count; q++)
        {
            if (nameList.ContainsKey(ancestorSeq[q].name))
            {
                //success!
                ancestorSeq[q].transform.localPosition = new Vector2(nameList[ancestorSeq[q].name], ancestorSeq[q].transform.localPosition.y);
                ancestorSeq[q].color = new Color(255, 255, 255, 255);
            }
            else
            {
                ancestorSeq[q].color = new Color(255, 255, 255, 0);
                //failure!
            }
        }



        //ancestorSeq = ancestorSeq.Sort((e1, e2) => Mathf.RoundToInt(e1.transform.localPosition.x).CompareTo(Mathf.RoundToInt(e2.transform.localPosition.x)));
        //bubble sort the ancestor sequence
        BubbleSort(ancestorSeq);


        if (!generatedSeqs.ContainsKey(id))
        {
            generatedSeqs.Add(id, ancestorSeq);
        }
    }

    public static void buildAncestor()
    {
        matches2 = 0;
        score2 = 0;
        mismatches2 = 0;
        extends2 = 0;
        gaps2 = 0;

        //instead of below line check whether the sequence is in generatedSeqs
        if (!generatedSeqs.ContainsKey("1") | !generatedSeqs.ContainsKey("2"))
        {
            List<Image> firstSeq = new AddSprites().GenerateSequence(new string[] { "A","S", "B", "B", "B", "C", "B", "C", "S", "B", "D", "C","C","A","A","C","A" }, -1858, 304, 1);//ABBBCBCBDCCAACA
            BuildAncestorAndScore.generatedSeqs.Add("1", firstSeq);
            List<Image>  secondSeq = new AddSprites().GenerateSequence(new string[] { "A", "B",  "B", "B", "C", "S", "B", "C",  "B", "D","C","C","A","A","C","A" }, -1858, 152, 2);//CBBBCBCCCCCAACA
            BuildAncestorAndScore.generatedSeqs.Add("2", secondSeq);
            BuildAncestorAndScore.generateAncesSeq(firstSeq, secondSeq, "A(1,2)");
            List<int> fullScoreArr = CalScore(BuildAncestorAndScore.generatedSeqs["1"], BuildAncestorAndScore.generatedSeqs["2"], BuildAncestorAndScore.generatedSeqs["A(1,2)"]);
            matches2 += fullScoreArr[0];
            mismatches2 += fullScoreArr[1];
            gaps2 += fullScoreArr[2];
            extends2 += fullScoreArr[3];
            //Debug.Log("1 & 2 "+ matches2);
        }
        else {
            generateAncesSeq(BuildAncestorAndScore.generatedSeqs["1"], BuildAncestorAndScore.generatedSeqs["2"], "A(1,2)");
            List<int> fullScoreArr = CalScore(BuildAncestorAndScore.generatedSeqs["1"], BuildAncestorAndScore.generatedSeqs["2"], BuildAncestorAndScore.generatedSeqs["A(1,2)"]);
            matches2 += fullScoreArr[0];
            mismatches2 += fullScoreArr[1];
            gaps2 += fullScoreArr[2];
            extends2 += fullScoreArr[3];
            //Debug.Log("1 & 2 " + matches2);
        }


       
        if (generatedSeqs.ContainsKey("A(1,2)") & generatedSeqs.ContainsKey("3"))
        {   
            generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(1,2)"], BuildAncestorAndScore.generatedSeqs["3"], "A(A12,3)");
            List<int> fullScoreArr = CalScore(BuildAncestorAndScore.generatedSeqs["A(1,2)"], BuildAncestorAndScore.generatedSeqs["3"], BuildAncestorAndScore.generatedSeqs["A(A12,3)"]);
            matches2 += fullScoreArr[0];
            mismatches2 += fullScoreArr[1];
            gaps2 += fullScoreArr[2];
            extends2 += fullScoreArr[3];
            //Debug.Log("12 & 3 " + matches2);
        }

         if (generatedSeqs.ContainsKey("4") & generatedSeqs.ContainsKey("5"))
        {
            generateAncesSeq(BuildAncestorAndScore.generatedSeqs["4"], BuildAncestorAndScore.generatedSeqs["5"], "A(4,5)");
            List<int> fullScoreArr = CalScore(BuildAncestorAndScore.generatedSeqs["4"], BuildAncestorAndScore.generatedSeqs["5"], BuildAncestorAndScore.generatedSeqs["A(4,5)"]);
            matches2 += fullScoreArr[0];
            mismatches2 += fullScoreArr[1];
            gaps2 += fullScoreArr[2];
            extends2 += fullScoreArr[3];
           // Debug.Log("4 & 5 " + matches2);
        }


        
          if (generatedSeqs.ContainsKey("A(A(A12,3),A(4,5))"))
          {
              generateAncesSeq(BuildAncestorAndScore.generatedSeqs["A(A12,3)"], BuildAncestorAndScore.generatedSeqs["A(4,5)"], "A(A(A12,3),A(4,5))");
              List<int> fullScoreArr = CalScore(BuildAncestorAndScore.generatedSeqs["A(4,5)"], BuildAncestorAndScore.generatedSeqs["A(A12,3)"], BuildAncestorAndScore.generatedSeqs["A(A(A12,3),A(4,5))"]);
              matches2 += fullScoreArr[0];
              mismatches2 += fullScoreArr[1];
              gaps2 += fullScoreArr[2];
              extends2 += fullScoreArr[3];
              //Debug.Log("45 & 12 3 " + matches2+  " generatedSeqs.ContainsKey(\"A(A12, 3)\") " + generatedSeqs.ContainsKey("A(A12,3)"));
        }
          


        score2 = matches2 - mismatches2 + gaps2 * (-4) + extends2 * (-1);
        if (changescore != null)
        {
            changescore();
        }
        //Debug.Log(ancestorSeq.Count);


        //Debug.Log("done");
        //showAncestor();
    }

    public static void DisableSequence(string key) {

        List<Image> imgSeq = generatedSeqs[key];
        List<float> visibilitySeq = new List<float>();
        for (int i = 0; i < imgSeq.Count; i++)
        {
            visibilitySeq.Add(imgSeq[i].color.a);
            imgSeq[i].color = new Color(1, 1, 1, 0.5f);
            imgSeq[i].GetComponent<Collider2D>().enabled = false;
            imgSeq[i].GetComponent<Draggable>().enabled = false;
        }

        disabledSeqs[key] = visibilitySeq;
        
    }

    public static void EnableSequence(string key)
    {
        List<Image> imgSeq = generatedSeqs[key];
        List<float> visibilitySeq = disabledSeqs[key];
        for (int i = 0; i < imgSeq.Count; i++)
        {
            imgSeq[i].color = new Color(1,1,1, visibilitySeq[i]);
            imgSeq[i].GetComponent<Collider2D>().enabled = true;
            imgSeq[i].GetComponent<Draggable>().enabled = true;
        }

        disabledSeqs.Remove(key);



    }

    public static void BubbleSort(List<Image> list) {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j].transform.localPosition.x > list[j + 1].transform.localPosition.x)
                {
                    Image temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }


}
