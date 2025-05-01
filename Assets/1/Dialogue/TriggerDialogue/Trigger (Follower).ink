VAR hasTalked = false

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
??: Excuse me!
??: Hello~!

FIN1X: A human… must be one of the ones the farmer spoke of. How should I approach this situation…
-> choice

=== choice ===
FIN1X:
+ Move out of my way.
    -> wrong
+ I'm here to join you.
    -> right

=== wrong ===
??: Ah! Please don't talk to me like that...
-> choice

=== right ===
??: Ohh! How wonderful! New followers of our Shepherd are more than welcomed~~!!!  
??: I do wish I could see your face under that cloak… but no matter–I’m just a follower, after all~
??: Still, I do have the honor of showing you around and introducing you to our Shepherd~!

FIN1X: Shepherd..? Must be the one in charge
That would be great.

Follower of The Shepherd: Just keep going straight till you reach the arch, I’ll meet you there~!
-> END

=== last ===
Follower of The Shepherd: Just keep going straight till you reach the arch, I’ll meet you there~!
-> END
