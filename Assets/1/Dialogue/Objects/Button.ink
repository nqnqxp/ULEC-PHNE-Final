VAR hasTalked = false
VAR pressButton = false

-> start

=== start ===
{hasTalked ==  false:
    ~ hasTalked = true
    -> first
}

=== first ===
FIN1X: <i>Final protocol engaged. Initiating pod access.</i>

FIN1X:
* Press the button
    -> button
* Do not press the button
    -> no
    
=== button ===
~pressButton = true
Initiating sequence.
Cryo-pod access confirmed. 
Biological stasis suspended. 
Subject revival initiated. 
Protocol complete.
-> END

=== no ===
Aborting sequence.
~pressButton = false
->END

