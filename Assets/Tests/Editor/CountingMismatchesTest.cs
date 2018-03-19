using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CountingMismatchesTest: MonoBehaviour
{

    [Test]
    public void CountingMismatchesTestSampleSamePositionAndSameTag()
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
        //there should be no mistches
        //seq1: A
        //seq2: A
        Assert.AreEqual(0, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }

    [Test]
    public void CountingMismatchesTestSampleSamePositionAndDifferentTags()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0, 0);
        Image s2 = Instantiate(img);
        s2.tag = "B";
        s2.transform.position = new Vector2(0, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be only one mismatch
        //seq1: A
        //seq2: B
        Assert.AreEqual(2, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }

    [Test]
    public void CountingMismatchesTestSampleDifferntPositionsAndDifferentTags()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0, 0);
        Image s2 = Instantiate(img);
        s2.tag = "B";
        s2.transform.position = new Vector2(1, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be no mismatch
        //seq1: A-
        //seq2: -B
        Assert.AreEqual(0, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }

    [Test]
    public void CountingMismatchesTestSampleDifferntPositionsAndSameTag()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0, 0);
        Image s2 = Instantiate(img);
        s2.tag = "A";
        s2.transform.position = new Vector2(1, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be no mismatch
        //seq1: A-
        //seq2: -A
        Assert.AreEqual(0, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }

    [Test]
    public void CountingMismatchesIntegrationTestSample()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "A";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(1, 0);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(0, 1);

        Image s2i2 = Instantiate(img);
        s2i2.tag = "B";
        s2i2.transform.position = new Vector2(1, 1);

        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1i1);
        seq1.Add(s1i2);

        seq2.Add(s2i1);
        seq2.Add(s2i2);
        //there should be only 1 mismatch
        //seq1: AA
        //seq2: AB
        Assert.AreEqual(2, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }

    public void CountingMismatchesIntegrationTestSample2()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "B";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(1, 0);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(0, 1);

        Image s2i2 = Instantiate(img);
        s2i2.tag = "B";
        s2i2.transform.position = new Vector2(1, 1);

        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1i1);
        seq1.Add(s1i2);

        seq2.Add(s2i1);
        seq2.Add(s2i2);
        //there should be 2 mismatches
        //seq1: BA
        //seq2: AB
        Assert.AreEqual(2, BuildAncestorAndScore.CalMismatches(seq1, seq2));
    }
}
