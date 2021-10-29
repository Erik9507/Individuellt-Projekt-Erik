# Individuellt-Projekt-Erik
Projekt Bank
Detta program ska symbolisera en internet-bank med olika funktioner, skapat i syfte för ett skolprojekt inom utveckling med C#.
Det finns 5 stycken förinlaggda användare med olika bankkonton med olika saldon för varje konto.
Användare kan ha 1, 2 eller 3 bankkonton.
Man kan skapa en ny användare och välja användarnamn, lösenord och saldo för bankkonton.
De olika funktionerna i programmet är:
Se saldo för Bankkonton.
Överföring av pengar mellan bankkonton.
Ta ut pengar från bankkonton.
Sätta in pengar från bankkonton.
programmet säger till om man matar in ogiltliga alternativ och stänger ner om man skriver in fel lösenord 3 gånger i rad.



Reflektion:
Detta var ett spännande och väldigt utmanande projekt.
Jag testade en hel del lösningar på olika problem innan jag kom fram till den lösning jag slutligen använde mig av.
För De olika användarkontona valde jag att använda en array. Denna lösning är inte optimal då varje användare ska ha olika antal bankkonton.
Jag lösde det genom att deklarera 3 bankkonton till varje användare och ge vissa ett nollvärde som då inte visas.
Nackdelen med detta är att om man tömmer ett konto på pengar så försvinner det kontot.
Man hade kunnat använda sig att listor eller en annan struktur på arrayen.
Resten av metoderna tycker jag Funkar bra och är hyfsat felfria.
programmet uppfyller kraven med ett fåtal små buggar. 
men i det stora hela är jag mycket nöjd med slutresultatet.
