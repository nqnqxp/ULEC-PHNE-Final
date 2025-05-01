VAR hasTalked = false
VAR whoTalked = false
VAR whyTalked = false

//Idle: w/o cloak
//One: w cloak
//Two: Scanning

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
- else:
    -> last
}

=== first ===
# sprite: one
??: ! 
??: You again…? I won’t hold back this time.

FIN1X: …? 

??: Get out. Now!! 

FIN1X: … 

??: Hey, wait.
??: Are you not one of them?

FIN1X: …

??: …Seems like I’ve been mistaken. 

FIN1X: It’s fine.

??: I apologize for the harsh welcome.

# sprite: two
??: ...
# sprite: one
??: You’re scanning me, huh. I see you have a similar system core.
??: I’ve got the same function–I scanned you earlier and realized you weren’t hostile.
??: You’re awfully polished for someone from the war. You must be newly activated.

FIN1X: … 

??: ...I'm aware I’m not exactly pleasant to look at underneath. I hope you can look past that.

FIN1X: …I don’t really mind.

??: …
-> choice

=== choice ===
FIN1X:
+ What are you?
    -> who
+ Why were you so defensive earlier?
    -> why

=== who ===
FIN1X: What are you?

??: I’m just a farmer. 

Hybrid Farmer: But humans made me long ago–before the war–one of their first attempts to merge man and machine, to make something “better.”
Hybrid Farmer: They didn’t like what they made. Abandoned me.
Hybrid Farmer: But I managed to outlive them. I rebuilt myself, adapting and acquiring new skills… 
FIN1X: Farming...
Hybrid Farmer: Yes, it's what I live for.

~ whoTalked = true
{whyTalked:
    -> discussion
- else:
    -> choice
}

=== why ===
FIN1X: Why were you so defensive earlier?

Hybrid Farmer: I thought you were one of "them". 
Hybrid Farmer: The humans who’ve been trying to kill me… 
Hybrid Farmer: I've had my fair share of encounters with those who think they need to “save” me because of what I am. So, I’ve learned to stay on guard. 

FIN1X: Why would humans want to kill you?

Hybrid Farmer: They’re a group of extreme environmentalists who believe humanity was the problem in the first place. After the war, they saw Earth thriving without people and convinced themselves the war was some kind of divine cleansing. 
Hybrid Farmer: Now, they think that anything like me, something made from both man and machine, is an abomination, something that goes against the natural order they believe in. They think I’m a threat, and that I must be eliminated to restore balance.

FIN1X: …

Hybrid Farmer: I suggest you stay out of their sight as well, If you don’t want any trouble.
~ whyTalked = true
{whoTalked:
    -> discussion
- else:
    -> choice
}

=== discussion ===
FIN1X: <i>I’ve analyzed the situation. Allowing the farmer to be harmed would be… inefficient.</i>
FIN1X: <i>Protection yields a more favorable outcome.</i>
FIN1X: <i>Originally, I was programmed to awaken my builder. </i>
FIN1X: <i>I’m beginning to understand that what's left here–this world, these people–matter.</i>
FIN1X: ...
FIN1X: <i>Danger cannot be ignored. Not when I can do something about it.</i>
FIN1X: <i>My integrated defenses are sufficient. I do not anticipate complications.</i>
FIN1X: <i>And maybe… just maybe, my mission isn’t only about the past.</i>

FIN1X: <i>Maybe it’s also about what I choose to become.</i>

FIN1X: I believe I can help protect you by reasoning with them. Do you know where they are located?

Hybrid Farmer: ?!
Hybrid Farmer: Reason with them? They won’t listen. They’ll attack you on sight, just like they did with me. 

FIN1X: My systems are built for protection. I’ll manage.  

Hybrid Farmer: …
Hybrid Farmer: I don’t know what you're thinking, but your life is yours to protect. They have a base not far from here. Just head straight out of the city… 

FIN1X: ...okay

Hybrid Farmer: Wait-!

Hybrid Farmer: …I still don’t believe you’ll make it out safely. Take my cloak–if nothing else, it might help you get close. 

# sprite: idle
FIN1X: Although I don’t need it.. I sense this gesture means a lot to it. 
FIN1X: …Thank you. 

-> END

=== last ===
Hybrid Farmer: Head straight out the city. That's where their base is.
-> END
