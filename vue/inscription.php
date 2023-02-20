<!DOCTYPE html>
<html>
<head>
    <title>GSB - S'inscrire à une activité</title>
    <meta charset="utf-8"/>
</head>
<header>
    <?php
        include_once "navbar.php";
    ?>
    <link href="style/style.css" rel="stylesheet">
</header>
<body>
    <div class="container">
        <br>
            <?php

            $parts = explode(";", $activite);

            echo "<h1><b>S'inscrire à l'activité : $parts[1]</b></h1>";
            echo "<br>";
            echo "<p><u>Description de l'évènement</u></p>";
            echo "<p>$parts[2]</p>";
            echo "<br>";
            echo "<p><u>Date et heure de l'évènement:</u></p>";
            echo "<p>$parts[3]</p>";
            echo "<p><u>Informations sur l'animateur:</u>";
            echo "<br>";
            echo "<p>$parts[6] $parts[5]</p>";
            echo "<p>Numéro : $parts[7]</p>";
            echo "<br>";
            echo "<p><u>Formulaire d'inscription :</u>";
            echo "<br>";
            echo "<form method='post' action='index.php?action=ACT&id=$parts[0]'><p><label for='inom'>Nom</label><br/><input type='text' name='nom' id='nom' pattern='[A-Z]+' title='NOM tout en majuscules.'/>";
            echo "<br>";
            echo "<p><label for='iprenom'>Prenom</label><br/><input type='text' name='prenom' id='prenom' pattern='[A-Z][a-z]+' title='Prénom avec une majuscule.'/>";
            echo "<br>";
            echo "<p><label for='imail'>Mail</label><br/><input type='text' name='mail' id='mail' pattern='[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\.(com|fr|org)' title='Email en .com, .fr ou .org'/>";
            echo "<br>";
            echo "<br>";
            echo "<input type='hidden' name='id' id='id' value='$parts[0]'>";
            echo "<input type='submit' value='Valider' class='btn btn-primary' style='background-color: #329E9D; border: unset;'>";
            echo " </form>";
            echo "<a href='index.php?action=ACT&id=$parts[0]' class='btn btn-primary' style='background-color: #329E9D; border: unset;'>Annuler</a>";

            echo "<br>";
            echo "<br>";
            echo "<a href='' data-bs-toggle='offcanvas' data-bs-target='#offcanvasRight' aria-controls='offcanvasRight'>En cliquant sur Valider, j'accepte la politique d'utilisation des données de GSB.</a>";
            
            echo "<div class='offcanvas offcanvas-end' tabindex='-1' id='offcanvasRight' aria-labelledby='offcanvasRightLabel'>";
            echo "<div class='offcanvas-header'>";
            echo "<h5 id='offcanvasRightLabel'><b>Politique d'utilisation des données</b></h5>";
            echo "<button type='button' class='btn-close text-reset' data-bs-dismiss='offcanvas' aria-label='Close'></button>";
            echo "</div>";
            echo "<div class='offcanvas-body'>";
            echo "<p>Les informations recueillies sur ce formulaire sont enregistrées dans un fichier informatisé par M. Jean DUBOIS, délégué à la protection des données de Galaxy Swiss Bourdin, pour un ajout dans notre base de données d'inscrits aux activités et l'envoi d'un questionnaire de satisfaction post-activité. La base légale du traitement est le consentement.</p>";
            echo "<br>";
            echo "<p>Les données collectées seront uniquement communiquées à Galaxy Swiss Bourdin.</p>";
            echo "<br>";
            echo "<p>Les données sont conservées pendant une durée de 3 mois.</p>";
            echo "<br>";
            echo "<p>Vous pouvez accéder aux données vous concernant, les rectifier, demander leur effacement ou exercer votre droit à la limitation du traitement de vos données. Vous pouvez retirer à tout moment votre consentement au traitement de vos données.</p>";
            echo "<br>";
            echo "<p>Consultez le site <a href='https://cnil.fr/'>cnil.fr</a> pour plus d’informations sur vos droits.</p>";
            echo "<br>";
            echo "<p>Pour exercer ces droits ou pour toute question sur le traitement de vos données dans ce dispositif, vous pouvez contacter notre délégué à la protection des données : <a href='mailto:dubois.jean@gsb.fr'>dubois.jean@gsb.fr</a></p>";
            echo "<br>";
            echo "<p>Si vous estimez, après nous avoir contactés, que vos droits « Informatique et Libertés » ne sont pas respectés, vous pouvez adresser une réclamation à la CNIL.</p>";
            echo "</div>";
            echo "</div>";
            ?>


            
    </div>
</body>

<?php
    include_once "footer.php";
?>
</html>
