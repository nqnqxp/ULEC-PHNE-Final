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
* Press button
    -> button
* Don't press the button
    -> no

=== button ===
~pressButton = true
-> END

=== no ===
~pressButton = false
-> END


=== last ===
{pressButton:
    -> revive
- else:
    -> stay
}

=== revive ===
Scientist's came back. Another nuclear war occured.

-> END

=== stay ===
Animals are thriving.
Happy ever after.
-> END
