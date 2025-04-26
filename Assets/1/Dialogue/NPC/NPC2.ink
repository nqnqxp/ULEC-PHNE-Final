VAR hasTalked = false

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
- else:
    -> last
}

=== first ===
NPC: Hello!
Player: Hi!
NPC: I have a problem...

Player:
* Oh...
    -> help
* I see...
    -> help

=== help ===
NPC: Can you help me?

Player:
* Yes!
    -> answerOne
* No!
    -> answerTwo

=== answerOne ===
NPC: I love you!
-> END

=== answerTwo ===
NPC: I hate you!
-> END

=== last ===
NPC: I never want to see you again!
-> END
