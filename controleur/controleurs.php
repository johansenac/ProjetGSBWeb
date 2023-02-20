<?php

function showAccueil()
{
    require_once "vue/accueil.php";
}
function showMedicaments()
{
    $medicaments = getMedicaments();
    require_once "vue/medicaments.php";
}

function showActivites()
{
    $activites = getActivites();
    require_once "vue/activites.php";
}

function showMentionsLegales()
{
    require_once "vue/mentions.php";
}

function showMedicament($id)
{
    $medicament = getMedicament($id);
    $effetsThera = getEffetsT($id);
    $effetsSeconds = getEffetsS($id);
    $interactions = getRelations($id);
    require_once "vue/medicament.php";
}

function showActivite($id)
{
    $activite = getActivite($id);
    $utilisateurs = getUtilisateurs($id);
    require_once "vue/activite.php";
}

function showInscription($id)
{
    $activite = getActivite($id);
    require_once "vue/inscription.php";
}

function showActiviteAfterInscription($id,$nom,$prenom,$mail)
{
    insertInscription($id,$nom,$prenom,$mail);
    showActivite($id);
}

?>
