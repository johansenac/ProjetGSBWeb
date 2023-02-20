<?php

require_once "modele/modele.php";

require_once "controleur/controleurs.php";

if(empty($_GET["action"]))
{
    showAccueil();
}
else if ($_GET["action"] == 'MEDS')
{
    showMedicaments();
}
else if ($_GET["action"] == 'ACTS')
{
    showActivites();
}
else if($_GET["action"] == 'MEN')
{
    showMentionsLegales();
}
else if ($_GET["action"] == 'MED' && isset($_GET["id"]))
{
    showMedicament(htmlspecialchars($_GET["id"]));
}
else if ($_GET["action"] == 'ACT' && isset($_GET["id"]) && !isset($_POST["nom"]))
{
    showActivite(htmlspecialchars($_GET["id"]));
}
else if ($_GET["action"] == 'INS' && isset($_GET["id"]))
{
    showInscription(htmlspecialchars($_GET["id"]));
}
else if ($_GET["action"] == 'ACT' && isset($_GET["id"]) && isset($_POST["nom"]) && isset($_POST["prenom"]) && isset($_POST["mail"]))
{
    showActiviteAfterInscription(htmlspecialchars($_GET["id"]), htmlspecialchars($_POST["nom"]), htmlspecialchars($_POST["prenom"]), htmlspecialchars($_POST["mail"]));
}
else
{
    showAccueil();
}
?>
