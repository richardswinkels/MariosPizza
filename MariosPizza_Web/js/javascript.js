function BtInloggen_Click() {
    //Haal waarden op uit de HTML en zet het in variabelen
    var gebruikersnaam = document.getElementById("tbGebruikersnaam").value;
    var wachtwoord = document.getElementById("tbWachtwoord").value;

    //Als gebruikersnaam gelijk is aan "medewerker" en wachtwoord gelijk is aan "pizzaszijnlekker"
    if (gebruikersnaam == "medewerker" && wachtwoord == "pizzaszijnlekker") {
        //Link door naar de personeelspagina
        window.location.href = "personeelspagina.html";
    }
    else {
        //Geef melding
        alert("Onjuiste logingegevens!");
        //Reset de inlogvelden
        document.getElementById("tbGebruikersnaam").value = "";
        document.getElementById("tbWachtwoord").value = "";
    }
}

function berekenKostprijs() {
    //Maak variabele met waarde 0 aan voor de totaalprijzen
    var kostprijsTotaalKlein = 0;
    var kostprijsTotaalGroot = 0;

    //Voer de loop acht keer uit
    for (var i = 1; i < 9; i++) {
        //Haal de waarde op uit de HTML
        var ingredient = document.getElementById("tbIngredient" + i).value;
        var prijsPerKg = document.getElementById("tbPrijsKg" + i).value;
        var hoeveelheidNodig = document.getElementById("tbNodig" + i).value;

        //Als ingredient een waarde heeft
        if (ingredient) {
            //Als prijsPerKg of hoeveelheidNodig geen waarde heeft
            if (!prijsPerKg) {
                //Laat melding zien
                alert("Uw invoer van \"Prijs per kilo\" voor ingrediënt " + ingredient + " op rij " + i + " is niet compleet!");
            }
            if (!hoeveelheidNodig) {
                //Laat melding zien
                alert("Uw invoer van \"Nodig\" voor ingrediënt " + ingredient + " op rij " + i + " is niet compleet!");
            }
            //Als prijsPerKg of hoeveelheidNodig niet uit getallen bestaat
            if (isNaN(prijsPerKg) || isNaN(hoeveelheidNodig)) {
                //Laat melding zien
                alert("Uw invoer bestaat niet uit getallen!");
            }
            //Anders als prijsPerKg een waarde heeft, hoeveelheidNodig een waarde heeft en beide variabele WEL nummers zijn
            else if (prijsPerKg && hoeveelheidNodig && !isNaN(prijsPerKg) && !isNaN(hoeveelheidNodig)) {
                //Doe de berekening 
                var kostprijsIngredientKlein = parseFloat(prijsPerKg) / 1000 * parseFloat(hoeveelheidNodig);
                var kostprijsIngredientGroot = parseFloat(kostprijsIngredientKlein) * 1.96;

                //Zet de berekende waardes in de tekstboxen en rond het bedrag af op 2 decimalen
                document.getElementById("tbPizzaKlein" + i).value = "\u20AC" + kostprijsIngredientKlein.toFixed(2);
                document.getElementById("tbPizzaGroot" + i).value = "\u20AC" + kostprijsIngredientGroot.toFixed(2);

                //Verhoog totaalprijs met prijs van het ingrediënt
                kostprijsTotaalKlein += kostprijsIngredientKlein;
                kostprijsTotaalGroot += kostprijsIngredientGroot;
            }
        }

        //Als de kostprijsTotaalKlein en kostprijsTotaalGroot groter zijn dan 0
        if (kostprijsTotaalKlein > 0 && kostprijsTotaalGroot > 0) {
        //Zet de totale prijs in de textbox en rond af op 2 decimalen
        document.getElementById("tbKostprijsKlein").value = "\u20AC" + kostprijsTotaalKlein.toFixed(2);
        document.getElementById("tbKostprijsGroot").value = "\u20AC" + kostprijsTotaalGroot.toFixed(2);
        }
    }
}

function btBereken_Click() {
    berekenKostprijs();
}

