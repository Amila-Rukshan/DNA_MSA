using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CountingMatchesTest : MonoBehaviour
{

	[Test]
	public void CountingMatchesTestSampleSamePositionAndSameTag() {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");
        Image s1 = Instantiate(img);
        s1.tag = "A";
        s1.transform.position = new Vector2(0,0);
        Image s2 = Instantiate(img);
        s2.tag = "A";
        s2.transform.position = new Vector2(0, 1);
        //create first sequence 
        List<Image> seq1 = new List<Image>();
        //create second sequence
        List<Image> seq2 = new List<Image>();
        seq1.Add(s1);
        seq2.Add(s2);
        //there should be only 1 match
        //seq1: A
        //seq2: A
        Assert.AreEqual(1, BuildAncestorAndScore.CalMatches(seq1, seq2));
	}

    [Test]
    public void CountingMatchesTestSampleSamePositionAndDifferentTags()
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
        //there should be only no match
        //seq1: A
        //seq2: B
        Assert.AreEqual(0, BuildAncestorAndScore.CalMatches(seq1, seq2));
    }

    [Test]
    public void CountingMatchesTestSampleDifferntPositionsAndDifferentTags()
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
        //there should be only 1 match
        //seq1: A-
        //seq2: -B
        Assert.AreEqual(0, BuildAncestorAndScore.CalMatches(seq1, seq2));
    }

    [Test]
    public void CountingMatchesTestSampleDifferntPositionsAndSameTag()
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
        //there should be only 1 match
        //seq1: A-
        //seq2: -A
        Assert.AreEqual(0, BuildAncestorAndScore.CalMatches(seq1, seq2));
    }

    [Test]
    public void CountingMatchesIntegrationTestSample()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "A";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(1, 1);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(0, 0);

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
        //there should be only 1 match
        //seq1: AA
        //seq2: AB
        Assert.AreEqual(1, BuildAncestorAndScore.CalMatches(seq1, seq2));
    }

    public void CountingMatchesIntegrationTestSample2()
    {
        // Use the Assert class to test conditions.
        Image img = Resources.Load<Image>("Prefabs/BlockTest");

        Image s1i1 = Instantiate(img);
        s1i1.tag = "B";
        s1i1.transform.position = new Vector2(0, 0);

        Image s1i2 = Instantiate(img);
        s1i2.tag = "A";
        s1i2.transform.position = new Vector2(1, 1);

        Image s2i1 = Instantiate(img);
        s2i1.tag = "A";
        s2i1.transform.position = new Vector2(0, 0);

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
        //there should be only 1 match
        //seq1: BA
        //seq2: AB
        Assert.AreEqual(0, BuildAncestorAndScore.CalMatches(seq1, seq2));
    }


}
