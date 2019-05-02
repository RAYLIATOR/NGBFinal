using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    public Text subtitleText;
    public Font playerFont;
    public Font memoryFont;
    public Font BossFont;

    void Start ()
    {
        StartCoroutine("S1Intro");
	}

    public void PlaySubtitle(string name)
    {
        StartCoroutine(name);
    }
    void Pause()
    {
        if (PlayerMove.isGrounded)
        {
            PlayerLook.freezeLook = true;
            PlayerMove.freezeMove = true;
        }
        else
        {
            Invoke("Pause", 0.1f);
        }
    }

    void UnPause()
    {
        PlayerLook.freezeLook = false;
        PlayerMove.freezeMove = false;
    }

    IEnumerator S1Intro()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Wha...Where am I? What is this place? Argh...My head.  How did I get here? I can’t remember anything...except...the ship...was sinking...and ";
        yield return new WaitForSeconds(4);
        //subtitleText.text = "";
        //yield return new WaitForSeconds(1);
        subtitleText.text = "I...was drowning. I guess I washed ashore...I guess...I..I survived! Hah! Yes! I survived! Heh...And now...Now I’m stranded on a random island. ";
        yield return new WaitForSeconds(4);
        subtitleText.text = "Great. How am I gonna get outta here? This island seems like it’s in the middle of nowhere. Now that I think about it, maybe drowning would have ";
        yield return new WaitForSeconds(4);
        subtitleText.text = "been better...Better than being stuck here forever. I should get some height...get a view around this place. The top of those rocks...Yeah, that ";
        yield return new WaitForSeconds(4);
        subtitleText.text = "looks like a good vantage point. I need to get up there.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1MidRocks()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Just a little bit higher.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1TopRocks()
    {
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(3);
        subtitleText.text = "Wait, is that… A...A ship! It’s a ship! Yes! Haha! Wooooo! That’s my way off this island! That’s...my way..home...I need to get to that ship.";
        yield return new WaitForSeconds(5);
        subtitleText.text = "";
    }

    IEnumerator S1JumpOverRocks()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "I’m gonna have to jump over these rocks.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator S1BeforeAxe1()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Ahh, I can’t wait to get back to...to...to get off this island.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1BeforeAxe2()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Looks like there’s something on the ground ahead, I should check it out.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1Axe()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "An axe! Where did that come from? I guess somebody from the ship must’ve left it here. I should pick it up...Might come in handy.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator S1Beautiful()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "This place is beautiful. Maybe being stuck here forever wouldn’t be such a bad thing...Hah. Gotta keep moving towards that ship.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator S1Fork()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Hmm. Which way should I go? The ship should be towards the left, but...either path could lead to a dead end...I can’t afford to waste time, I might lose the ship.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "I need to move, quickly.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1ShipFar()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "No...No! The ship’s too far away. I can’t get to it. I’m not making it off this island! No...No I can’t give up! That ship is my only hope. Ahhh, what do I do?";
        yield return new WaitForSeconds(3);
        subtitleText.text = "C’mon, think...A raft! That’s it...Yes...I need to build a raft. I guess I should start by picking a good spot...As close to the ship as possible.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator S1Spot()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "This looks like a good spot for the raft. Okay, now I need to collect logs from these trees...using this....axe. Huh, that’s oddly convenient, it’s almost like";
        yield return new WaitForSeconds(3);
        subtitleText.text = "someone knew I’d need it. What am I talking about? I..I should get started. I think about 7 logs should be enough.";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator S1Almost()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "I’m almost there, gotta keep going.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S1Everyone()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "I’m quite surprised I haven’t found anyone else on this island, they must be on the ship.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    
    IEnumerator Stage2Transition()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "There we go! Now all I need to do is...Wait! What’s happening? Wait, No! Noooo!";
        yield return new WaitForSeconds(3);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    //Stage2Transition

}
