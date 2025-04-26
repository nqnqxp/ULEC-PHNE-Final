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
NPC: Go away!
Player: No!
NPC: I hate you!
-> END

=== last ===
NPC: I never want to see you again!
-> END
