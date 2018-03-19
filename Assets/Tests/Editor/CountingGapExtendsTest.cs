using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CountingGapExtendsTest: MonoBehaviour
{

    [Test]
    public void CountingGapExtendsTestSample1()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0, 0);
        Image s2 = Instantiate(img);
        s2.tag = "A";
        s2.transform.position = new Vector2(0, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be no gap extends
        //seq1: A
        //seq2: A
        Assert.AreEqual(0, BuildAncestorAndScore.CalGaps(seq1, seq2)[1]);
    }

    [Test]
    public void CountingGapExtendsTestSample2()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0, 0);
        Image s2 = Instantiate(img);
        s2.tag = "B";
        s2.transform.position = new Vector2(152, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be only no gap extends
        //seq1: A-
        //seq2: -B
        Assert.AreEqual(0, BuildAncestorAndScore.CalGaps(seq1, seq2)[1]);
    }

    [Test]
    public void CountingGapExtendsTestSample3()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(152, 0);
        Image s2 = Instantiate(img);
        s2.tag = "B";
        s2.transform.position = new Vector2(152, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be no gap extends
        //seq1: -A
        //seq2: -B
        Assert.AreEqual(0, BuildAncestorAndScore.CalGaps(seq1, seq2)[1]);
    }


    [Test]
    public void CountingGapExtendsTestSample4()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "A";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(456, 0);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(152, 1);

        Image s2i2 = Instantiate(img);
        s2i2.tag = "B";
        s2i2.transform.position = new Vector2(456, 1);

        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1i1);
        seq1.Add(s1i2);

        seq2.Add(s2i1);
        seq2.Add(s2i2);
        //there should be 2 gap extends
        //seq1: AggA-
        //seq2: -AgB
        Assert.AreEqual(0, BuildAncestorAndScore.CalGaps(seq1, seq2)[1]);
    }

    public void CountingGapExtendsTestSample5()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "B";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(608, 0);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(304, 1);

        Image s2i2 = Instantiate(img);
        s2i2.tag = "B";
        s2i2.transform.position = new Vector2(456, 1);

        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1i1);
        seq1.Add(s1i2);

        seq2.Add(s2i1);
        seq2.Add(s2i2);
        //there should be no gaps
        //seq1: B---A
        //seq2: --AB-
        Assert.AreEqual(1, BuildAncestorAndScore.CalGaps(seq1, seq2)[1]);
    }
}
