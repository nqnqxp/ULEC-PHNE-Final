VAR hasTalked = false
VAR pressButton = false

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
- else:
    -> last
}

=== first ===
FIN1X: <i>Should I press the button or not?</i>

FIN1X:
* Press the button
    -> button
* Don't press the button
    -> no
    
=== button ===
FIN1X: Yeah, this is the right choice.
FIN1X: We need humans back.
~pressButton = true
-> END

=== no ===
FIN1X: No, the Earth is good as it is now.
FIN1X: I shouldn't bring back the humans.
~pressButton = false
->END

=== last ===
{pressButton:
    -> revive
- else:
    -> stay
}

=== revive ===
Scientist's came back. Another nuclear war occured.

The End
-> END

=== stay ===
Animals are thriving.
Happy ever after.

The End
-> END
