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
    GameObject canvas;
    public static int enemies;
    Tutorial tutorial;

    void Start ()
    {
        tutorial = FindObjectOfType<Tutorial>();
        enemies = 1;
        canvas = FindObjectOfType<Canvas>().gameObject;
        if(canvas.tag == "1")
        {
            StartCoroutine("S1Intro");
        }
        else if(canvas.tag == "2")
        {
            StartCoroutine("S2Intro");
        }
        else if (canvas.tag == "3")
        {
            StartCoroutine("S3Intro");
        }
        else if (canvas.tag == "4")
        {
            StartCoroutine("End");
        }
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
    //Stage 1
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
        tutorial.IntroTutorial();
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
        tutorial.ShowTutorial("Press E to pick up axe");
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

    IEnumerator S1Log()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Now I just gotta place this down on the spot.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S1OneDown()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "One down, six more to go.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S1FourDown()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Just three more logs, Come on.";
        yield return new WaitForSeconds(2);
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
        subtitleText.text = "Hmm. Which way should I go? The ship should be towards the left, but...either path could lead to a dead end...I can’t afford to waste time,";
        yield return new WaitForSeconds(3);
        subtitleText.text = "I might lose the ship. I need to move, quickly.";
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
        tutorial.ShowTutorial("Find a spot near the edge of the water.");
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
        tutorial.ShowTutorial("Press E to mark location");
        yield return new WaitForSeconds(3.5f);
        tutorial.ShowTutorial("Press E to collect logs from trees");
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

    //Stage 2
    IEnumerator S2Intro()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Wha...Where am I? Argh, my head hurts. What is...Wait a second, this place looks familiar...But...I’ve never been here before. What’s going on?";
        yield return new WaitForSeconds(4);
        //subtitleText.text = "";
        //yield return new WaitForSeconds(1);
        subtitleText.text = "Am I losing my mind? What am I doing here? I can’t remember anything! All I know is that I need to...get...to...the ship. The ship. The Ship! Yes!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "I remember the ship. But where was it? What if its gone? No, I need get up those rocks and look for the ship. It’ll be there. It has to be there.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S2MidRocks()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Just a little bit...higher.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    IEnumerator S2TopRocks()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "There it is! Yes! Haha! It’s still there! But...how do I know that? What’s happening to me? None of this makes sense. I need to calm down.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "I need to stay focused. I need to get off this island.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S2JumpOverRocks()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "I’m gonna have to jump over these rocks...again. What am I saying? I haven’t been here before. I’ve just washed ashore on this island.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "My...My mind’s just messing with me, heh. That’s all.";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Transition()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "What’s happening? No! No! Not again!";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S2Weapon()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "What’s this? All this...This can’t be real. It...it...must be a nightmare! Yes! It’s just a nightmare! Haha! I just need to make it to the end!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "And then I’ll wake up back in...with my...I’ll be back home. I’ll remember everything.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
        tutorial.ShowTutorial("Press E to take weapon");
    }

    IEnumerator S2Memory1()
    {
        //PlayerFocus.barsIn = true;
        //Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Wha..What’s happening? This isn’t real.";
        yield return new WaitForSeconds(2);
        
        subtitleText.font = memoryFont;

        subtitleText.text = "Why do you deny your reality?";
        yield return new WaitForSeconds(2);

        subtitleText.font = playerFont;

        subtitleText.text = "Argh! What is going on? What was that thing? I think it was all in my head. I need to get to that ship.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S2Memory2()
    {
        //PlayerFocus.barsIn = true;
        //Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "No...Not another one. This is not happening to me.";
        yield return new WaitForSeconds(2);

        subtitleText.font = memoryFont;

        subtitleText.text = "You cannot escape this!";
        yield return new WaitForSeconds(2);

        subtitleText.font = playerFont;

        subtitleText.text = "Argh! Why does it feel so real? It doesn’t matter. It’s not real. It must be the cold. I need to stay focused.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S2Memory3()
    {
        //PlayerFocus.barsIn = true;
        //Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Hehe, you’re not real. You’re just in my head!";
        yield return new WaitForSeconds(2);

        subtitleText.font = memoryFont;

        subtitleText.text = "You lie to yourself. Liar!";
        yield return new WaitForSeconds(2);

        subtitleText.font = playerFont;

        subtitleText.text = "Argh! I’m not lying to myself. I’m not...lying...to myself. I’m just...losing it. Haha! I’m just losing my mind! No, no no. Snap out of it! Must make it to the ship. Now!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S2Memory4()
    {
        //PlayerFocus.barsIn = true;
        //Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "No, No, No. What do you want from me?";
        yield return new WaitForSeconds(2);

        subtitleText.font = memoryFont;

        subtitleText.text = "Embrace the inevitable!";
        yield return new WaitForSeconds(2);

        subtitleText.font = playerFont;

        subtitleText.text = "Argh! Why won’t you just leave me alone! Why is this happening to me?";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S2Memory5()
    {
        //PlayerFocus.barsIn = true;
        //Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Please I just want to go home. Please!";
        yield return new WaitForSeconds(2);

        subtitleText.font = memoryFont;

        subtitleText.text = "This is where you belong!";
        yield return new WaitForSeconds(2);

        subtitleText.font = playerFont;

        subtitleText.text = "Argh! I just want to go home. I want to go back to...to...Argh! Why can’t I remember? Why?";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator End()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Wha...Where am I? What is this place? Argh...My head.  How did I get here? I can’t remember anything...except...Ahhhhhhhh!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }

    //Stage 3

    IEnumerator S3Intro()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Wha...Where am I? What is this place? Argh...My head. Can’t remember much except...Oh no. No No No! This should be over! I should be awake!";
        yield return new WaitForSeconds(4);
        //subtitleText.text = "";
        //yield return new WaitForSeconds(1);
        subtitleText.text = "Awake? What am I talking about? How do I get off this cursed island? How did I get on...this island? I can’t be here forever. I have to return";
        yield return new WaitForSeconds(4);
        subtitleText.text = "to...to...Argh! The ship! Wait, what ship? Yes! Heh, the ship will get me back. I need to see if that ship is still here. The ship will take me home.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Lava()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Is that lava? Woah! That is cool. No...Wait...That’s actually hot, my bad. Hehe. Wait, Lava. Lava! Oh no, I could fall into that! I need to be careful.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3TopRocks()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "There’s the ship! There it is! I’m going home! Ha! All I need to do is get to the ship, again.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3MidRocks()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Just a little...bit...higher?";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon1E()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Ahh! What is that thing? What’s going on?";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon1D()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Was that a demon? Am I in...No. No, that’s not possible. I need to keep moving.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon2E()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = " Another one! No No No! Wait, maybe the nightmare isn’t over yet. Yes! I just need to get to the end, and it will all be over!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon2D()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Okay! 2 down! I just need to keep going.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon3E()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Haha, Hah, Bring it on!";
        yield return new WaitForSeconds(2);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon3D()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "That’s 3. C’mon, keep going and this nightmare will soon be over...And I’ll be back...back...home.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon4E()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Ahh, there you are! I’ve been looking everywhere for you! Haha!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon4D()
    {
        PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "Four down, I’m nearly at the ship. As soon as I get there...This will all be...over...Right? But...how I know about the ship?";
        yield return new WaitForSeconds(4);
        subtitleText.text = "It’s like I’ve done this before. What if it doesn't end there? What if...No, no. Don’t be silly. You gonna be fine. Just get to the ship.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        UnPause();
        PlayerFocus.barsOut = true;
    }
    IEnumerator S3Demon5E()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(1);
        subtitleText.text = "No, no more! I just want to go home! Please! Are you the last one? Huh? Hmm. Only one way to find out.";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
    IEnumerator S3Boss()
    {
        //PlayerFocus.barsIn = true;
        Pause();

        subtitleText.font = playerFont;

        yield return new WaitForSeconds(2);
        subtitleText.text = "Wha...What is happening? No. I don’t wanna go back please. Please. Go back where? I just wanna get on the ship.";
        yield return new WaitForSeconds(4);

        subtitleText.font = BossFont;
        subtitleText.text = "Fool! Why do you try to escape your reality? Don’t you see? You are never leaving! You are doomed to relive this forever!";
        yield return new WaitForSeconds(4);
        subtitleText.text = "";

        //UnPause();
        //PlayerFocus.barsOut = true;
    }
}
