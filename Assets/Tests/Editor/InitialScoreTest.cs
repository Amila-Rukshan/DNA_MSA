using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreTest {

	[Test]
	public void InitialTotalScoreTest() {
        Assert.AreEqual(0, BuildAncestorAndScore.score2);
    }

    [Test]
    public void InitialMatchesTest()
    {
        Assert.AreEqual(0, BuildAncestorAndScore.matches2);
    }

    [Test]
    public void InitialMismatchesTest()
    {
        Assert.AreEqual(0, BuildAncestorAndScore.mismatches2);
    }

    [Test]
    public void InitialGapsTest()
    {
        Assert.AreEqual(0, BuildAncestorAndScore.gaps2);
    }

    [Test]
    public void InitialGapExtendsTest()
    {
        Assert.AreEqual(0, BuildAncestorAndScore.extends2);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator ScoreTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
