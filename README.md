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

## Fel 4: Programmet kraschade vid fel inmatning
**Vad hände:** Skrev man något annat än en siffra kraschade programmet  
**Varför:** Programmet hade en int.parse för att ta emot användarens siffra men skriver man bokstäver eller andra tecken kraschar programmet  
**Lösning:** Jag gjorde om alla int.parse till int.tryparse för att programmet skulle sluta krascha  

## Fel 5: Programmet kraschar när items.txt saknas
**Vad hände:** Jag döpte om items.txt, körde programmet och det kraschade direkt med FileNotFoundException  
**Varför:** Load() anropar File.ReadAllText(path) fast filen inte finns  
**Lösning:** Lade in en try catch i Load() för att kunna köra programmet ändå fast med en lista utan några varor i  

## Fel 6: Programmet kraschar när man tar bort en obefintlig vara
**Vad hände:** programmet kraschade när man valde att ta bort en siffra utanför listan  
**Varför:** Programmet försökte ta bort en vara som inte fanns  
**Lösning:** Sätta ett intervall för vilka siffror som var okej att välja mellan och annars få felmeddelande

## Fel 7: Tom catch i Save
**Vad hände:** Ifall listan skulle misslyckas att sparas så sa programmet ändå att listan var sparad  
**Varför:** Catch i save() var tom och gav inget meddelande ifall try skulle misslyckas  
**Lösning:** Lade till ett felmeddelande i catch och lade in "listan är sparad" i try så att den inte säger att listan är sparad ifall den inte är det  

