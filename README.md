# Felrapport
## Fel 1: Krasch vid inläsning (IndexOutOfRangeException)
**Vad hände:** Systemet kraschade direkt vid start med ett felmeddelande om IndexOutOfRangeException  
**Varför:** Save() avslutar varje rad med radbrytning, även den sista. `Split('\n')` ger en tom sträng sist i arrayen. `Split(';')` ger en array med ett element, så parts[1] finns inte och kraschar därför programmet  
**Lösning:** Lade till en if sats som gör att load() hoppar över tomma rader