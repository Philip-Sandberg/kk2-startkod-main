# Felrapport
## Fel 1: Krasch vid inläsning (IndexOutOfRangeException)
**Vad hände:** Systemet kraschade direkt vid start med ett felmeddelande om IndexOutOfRangeException  
**Varför:** Save() avslutar varje rad med radbrytning, även den sista. `Split('\n')` ger en tom sträng sist i arrayen. `Split(';')` ger en array med ett element, så parts[1] finns inte och kraschar därför programmet  
**Lösning:** Lade till en if sats som gör att load() hoppar över tomma rader

## Fel 2: Varor skrevs inte ut och sök funktionen fungerade inte
**Vad hände:** När jag sökte på en vara som finns i items.txt, till exempel "Mjölk", fick jag svaret "Varan finns inte i listan" och listan skrev inte heller ut varorna i konsolen.
**Varför:** Load() delar texten med `Split('\n')`, så `\n` försvinner men `\r` blir kvar sist på raden. Namnet i minnet blev därför `"Mjölk\r"`.
**Lösning:** Jag anropar `Trim()` på raden innan den delas upp (`line.Trim().Split(';')`), så att `\r` tas bort från namnet.

## Fel 3: Totalen av priserna stämmer inte
**Vad hände:** Totalen räknade inte med första varans pris
**Varför:** Total():s for-loop började med att i = 1 men första platsen i items listan är 0
**Lösning:** Ändra i:s startvärde i for-loopen i Total() från 1 till 0