VAR hasTalked = false

//Sprites
//idle: Idle
//one: Happy
//two: Silly
//two: Surprised

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
- else:
    -> last
}

=== first ===
??: ! 
??: You again…? I won’t hold back this time.

FIN1X: …? 

??: Get out. Now!! 

FIN1X: … 

??: Hey, wait.
??: Are you not one of them?

FIN1X: …

??: …seems like I’ve mistaken. 

FIN1X: It’s fine.

??: I apologize for the harsh welcome.

??: ! 
??: You’re inspecting me, huh. I see you have a similar system core.
??: I have the same ability… I sensed you weren’t a threat when I scanned you just a moment ago as well. 
??: You look pretty shiny for a cyborg that’s been around since the war. You’re newly activated aren't you?

FIN1X: … 

??: ...I'm aware I’m not exactly pleasant to look at underneath. I hope you can look past that.

FIN1X: …I don’t really mind.

??: …

FIN1X:
* What are you?
    -> who
* Why were you so defensive earlier?
    -> why

=== who ===
FIN1X: What are you?

??: I’m just a farmer. 

Hybrid farmer: Humans created me long before the war, as part of the first experiments to merge man and machine, to make something 'better.' Guess they didn’t like the result and abandoned the project.
Hybrid farmer: But I managed to outlive them. I rebuilt myself, adapting and acquiring new abilities… 
-> discussion

=== why ===
FIN1X: Why were you so defensive earlier?

Hybrid farmer: I thought you were one of them. The humans who’ve been trying to kill me… 
Hybrid farmer: I've had my fair share of encounters with those who think they need to “save” me because of what I am. So, I’ve learned to stay on guard. 

FIN1X: Why would humans want to kill you?

Hybrid farmer: They’re a group of extreme environmentalists who believe humanity was the problem in the first place. After the war, they saw Earth thriving without people and convinced themselves the war was some kind of divine cleansing. 
Hybrid farmer: Now, they think that anything like me, something made from both man and machine, is an abomination, something that goes against the natural order they believe in. They think I’m a threat, and that I must be eliminated to restore balance.

FIN1X: …

Hybrid farmer: I suggest you stay out of their sight as well, If you don’t want any trouble.
-> discussion

=== discussion ===
FIN1X: <i>I’ve analyzed the situation. I determine that allowing the farmer to be harmed would be inefficient for the overall outcome. Protection is the most beneficial course of action. </i>
FIN1X: <i>I was programmed to awaken my builder. But I am beginning to see the importance of what’s left here. I can’t ignore danger. And maybe… just maybe, this could be part of my mission too. </i>

FIN1X: I believe I can help protect you by reasoning with them. Do you know where they are located?

Hybrid Farmer: ?!
Hybrid farmer: Reason with them? They won’t listen. They’ll attack you on sight, just like they did with me. 

FIN1X: I understand the danger. But I believe there's a way to avoid further conflict. 

Hybrid Farmer: …
Hybrid farmer: I don’t know what you're thinking, but your life is yours to protect. They have a base not far from here. Just head straight out of the city… 

FIN1X: I’ll be back. 

Hybrid Farmer: … 
-> END

=== last ===
# sprite: one
Hybrid farmer: Head straight out the city. That's where their base is.
-> END
