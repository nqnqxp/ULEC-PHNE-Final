VAR hasTalked = false
VAR staySilent = false

//Sprites
//idle: Idle
//one: Happy
//two: Silly
//two: Surprised

-> start

=== start ===
{hasTalked == false:
    { staySilent == false:
        -> first
    - else:
        -> beginning
    }
- else:
    -> last
}

=== first ===
# sprite: three
??: Whoa.. you’re–wait, what are you? You look like us, but newer. Cleaner. Definitely not war-ruse like me. Been a long time since I’ve seen anyone like that. I didn't know I had company around so close. 

# sprite: one
??: I thought I was all alone.

# sprite: idle
FIN1X: ...

# sprite: one
??: Not much of a talker? That’s okay.

# sprite: two
??: Not many left to talk to, anyway.

# sprite: idle
FIN1X:
* Engage
    -> engage
* Stay silent
    -> silent

=== engage ===
# sprite: idle
FIN1X: I just woke up.

# sprite: one
??: Ah, I knew it. You’ve got that look- fresh systems, still intact. 

# sprite: three
??: So what are you doing out here?
-> discussion

=== silent ===
FIN1X: ...

# sprite: two
??: Well, you can always come back to me if you wanna talk!
~ staySilent = true
-> END

=== beginning===
# sprite: one
??: Hey!
-> discussion

=== discussion ===
# sprite: idle
FIN1X: I have a mission. I am programmed to fulfill it.

# sprite: three
??: Programmed, huh? 

# sprite: one
??: I was programmed too. For the war. A soldier, just like many others. 

# sprite: idle
FIN1X: …

# sprite: three
Broken Cyborg Soldier: Do you know about the war?

# sprite: idle
FIN1X: War…?

# sprite: one
Broken Cyborg Soldier: It was humanity’s final act. A war fought over resources, over power. In the end, it destroyed and wiped out most of them… 

# sprite: two
Broken Cyborg Soldier: Those of us who made it though are left with the wreckage. Nothing’s the same now. The world’s unrecognizable… but I guess that doesn’t mean much to you. You’ve never seen what it used to be. 

# sprite: idle
FIN1X: …

# sprite: two
Broken Cyborg Soldier: As you can see, I’m still here, but... stuck. My legs didn’t make it through the war.

# sprite: idle
FIN1X: Humanity… gone… 

# sprite: three
Broken Cyborg Soldier: Not all of it. I know where you can find some! 

# sprite: idle
FIN1X: …! <i>could it be the cryo pods?</i>

# sprite: one
Broken Cyborg Soldier: I can’t exactly lead you there, seeing as my feet are well, gone.

# sprite: two
Broken Cyborg Soldier: Hehe!

# sprite: one
Broken Cyborg Soldier: But I can give you directions-you can input those, right? 

Broken Cyborg Soldier: Head north, and you’ll come across a playground soon. There should be a few humans there! 

# sprite: idle
FIN1X: Okay.

# sprite: two
Broken Cyborg Soldier: See you around! 
~ hasTalked = true
-> END

=== last ===
# sprite: one
Broken Cyborg Soldier: You'll find some humans at the playground! 
-> END
