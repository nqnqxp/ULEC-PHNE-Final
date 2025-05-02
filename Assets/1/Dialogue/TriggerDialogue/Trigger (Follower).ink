VAR hasTalked = false

//idle: w/o cloak
//one: <:3
//two: <:D
//three: <;<
//four: <:{

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
#sprite: idle
FIN1X:
+ Move out of my way.
    -> wrong
+ I'm here to join you.
    -> right

=== wrong ===
#sprite: three
??: Ah! Please don't talk to me like that...
-> choice

=== right ===
#sprite: two
??: Ohh! How wonderful! New followers of our Shepherd are more than welcomed~~!!!  
#sprite: one
??: I do wish I could see your face under that cloak… but no matter–I’m just a follower, after all~
#sprite: two
??: Still, I do have the honor of showing you around and introducing you to our Shepherd~!

#sprite: one
FIN1X: Shepherd..? Must be the one in charge
FIN1X: That would be great.

#sprite: two
Follower of The Shepherd: Just keep going straight till you reach the arch, I’ll meet you there~!
-> END

=== last ===
#sprite: two
Follower of The Shepherd: Just keep going straight till you reach the arch, I’ll meet you there~!
-> END
