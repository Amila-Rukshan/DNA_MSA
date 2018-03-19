using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LevelTest {
    
    [Test]
    public void InitialLevelTest()
    {
        Assert.AreEqual(1, BuildAncestorAndScore.level);
    }


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator LevelTestWithEnumeratorPasses() {
        InitialLevelTest();
        yield return null;
	}
}
