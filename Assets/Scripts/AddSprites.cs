using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSprites : MonoBehaviour {

	[SerializeField]
	private Transform panel;

    private static Transform panel2;

    static public List<Image> blocks = new List<Image>();

	[SerializeField]
	private  Image prefab;

    private static Image prefab2;

    public static Sprite[] puzzles;

    public static List<List<Image>> puzzlesInRows = new List<List<Image>>();

    private static string[] tags =new string[]{ "A","B","C","D","E","F","G","H"};

    public string selection = "blocks_1";

    public void SetSelection(string selection)
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/" + selection);
        BuildAncestorAndScore.buildAncestor();
    }

    void Awake(){
        prefab2 = prefab;
        panel2 = panel;
        //puzzles = Resources.LoadAll<Sprite>("Sprites/" + selection);
    }
    //0427 1356
    public List<Image> GenerateSequence(string[] seq,int startX, int startY, int seqN) {

        List <Image> L = new List<Image>();
        for (int i = 0; i < seq.Length; i++)
        {
            if (seq[i] == "A")
            {
                Image newImage = Instantiate(prefab2);
                newImage.name = "DNA " + seqN + " " + i;
                newImage.tag = tags[0];
                newImage.sprite = puzzles[0];
                L.Add(newImage);
                blocks.Add(newImage);
                newImage.transform.localPosition = new Vector3(startX + 152 * i, startY, 0);
                newImage.transform.SetParent(panel2, false);
            }
            else if (seq[i] == "B")
            {
                Image newImage = Instantiate(prefab2);
                newImage.name = "DNA " + seqN + " " + i;
                newImage.tag = tags[1];
                newImage.sprite = puzzles[1];
                L.Add(newImage);
                blocks.Add(newImage);
                newImage.transform.localPosition = new Vector3(startX + 152 * i, startY, 0);
                newImage.transform.SetParent(panel2, false);
            }
            else if (seq[i] == "C")
            {
                Image newImage = Instantiate(prefab2);
                newImage.name = "DNA " + seqN + " " + i;
                newImage.tag = tags[2];
                newImage.sprite = puzzles[2];
                L.Add(newImage);
                blocks.Add(newImage);
                newImage.transform.localPosition = new Vector3(startX + 152 * i, startY, 0);
                newImage.transform.SetParent(panel2, false);
            }
            else if (seq[i] == "D")
            {
                Image newImage = Instantiate(prefab2);
                newImage.name = "DNA " + seqN + " " + i;
                newImage.tag = tags[3];
                newImage.sprite = puzzles[3];
                L.Add(newImage);
                blocks.Add(newImage);
                newImage.transform.localPosition = new Vector3(startX + 152 * i, startY, 0);
                newImage.transform.SetParent(panel2, false);
            }
            
        }
        return L;
    }
}
