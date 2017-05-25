﻿using System.Collections;
using UnityEngine.TestTools;
using PullString;
using PullStringTests;

public class Convo
{
    [UnityTest]
    public IEnumerator Test_Conversation()
    {
        yield return new MonoBehaviourTest<ConvoTest>();
    }

    public class ConvoTest : TestBase
    {
        override protected void Run(Response response, int step)
        {
            switch (step)
            {
                case 0:
                    conversation.SendActivity("wizard");
                    break;
                case 1:
                    conversation.SendText("wizard");
                    break;
                case 2:
                    TestUtils.TextShouldMatch(response, new[] { "Talk to the dwarf" });
                    conversation.SendText("dwarf");
                    break;
                case 3:
                    TestUtils.TextShouldMatch(response, new[] { "Here's my axe" });
                    conversation.SendText("dwarf");
                    break;
                case 4:
                    TestUtils.TextShouldMatch(response, new[] { "You already have my axe" });
                    conversation.SendText("wizard");
                    break;
                case 5:
                    TestUtils.TextShouldMatch(response, new[] { "Here's my spell" });
                    conversation.SendText("wizard");
                    break;
                case 6:
                    TestUtils.TextShouldMatch(response, new[] { "You already have my spell" });
                    IsTestFinished = true;
                    break;
                default:
                    TestUtils.ShouldntBeHere();
                    break;
            }
        }
    }
}