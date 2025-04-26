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
# sprite: two
NPC: Hi!
Player: Hello. How are you?
# sprite: one
NPC: Good.
-> END

=== last ===
# sprite: three
NPC: Go over there
-> END
