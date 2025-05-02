VAR hasTalked = false
VAR pressButton = false

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
}

=== first ===
FIN1X: Final protocol engaged. Initiating pod access. 
FIN1X: …
FIN1X: No turning back now.


*Press the button
    -> button
*Do not press the button
    -> no
    
=== button ===
Initiating sequence.
~pressButton = true
Cryo-pod access confirmed. 
Biological stasis suspended.
Subject revival initiated.
Protocol complete.
-> END

=== no ===
Aborting sequence
~pressButton = false
-> END
