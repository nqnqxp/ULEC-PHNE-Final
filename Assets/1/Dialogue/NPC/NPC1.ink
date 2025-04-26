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
NPC: Hi!
Player: Hello. How are you?
NPC: Good.
-> END

=== last ===
NPC: Go over there
-> END
