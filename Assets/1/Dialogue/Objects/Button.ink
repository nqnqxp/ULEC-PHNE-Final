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
FIN1X: Final protocol engaged. Initiating pod access. 
FIN1X: …
FIN1X: No turning back now.


*Press the button-initiate sequence 
    -> button
*Do not press the button-abort sequence  
    -> no
    
=== button ===
~pressButton = true
-> END

=== no ===
~pressButton = false
->END

=== last ===
{pressButton:
    -> revive
- else:
    -> stay
}

=== revive ===
Cryo-pod access confirmed. 
Biological stasis suspended.
Subject revival initiated.
Protocol complete.

<i>The sky overhead is still blue. The soil is still warm. There is still time.</i>

<i>But will the past repeat itself… or begin again?</i>

-> END

=== stay ===
…
….
…..

<i>FIN1X walks away, leaving behind the last remnants of a world that had its chance. The Earth breathes again, quiet and untamed. Life–not as it was, but as it is–flourishes without interruption. </i>

-> END
