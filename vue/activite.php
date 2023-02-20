<!DOCTYPE html>
<html>
<head>
    <title>GSB - Activité</title>
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

            echo "<h1><b>$parts[1]</b></h1>";
            echo "<br>";
            echo "<img src='assets/activites/$parts[0].jpg' class='imgb' width=350 height=250>";
            echo "<br>";
            echo "<br>";
            echo "<p>$parts[2]</p>";
            echo "<br>";
            echo "<p><u>Date et heure de l'évènement:</u></p>";
            echo "<p>$parts[3]</p>";
            echo "<p><u>Informations sur l'animateur:</u>";
            echo "<br>";
            echo "<p>$parts[6] $parts[5]</p>";
            echo "<p>Numéro : $parts[7]</p>";
            echo "<br>";
            echo "<p><u>Liste des inscrits :</u>";

            if(is_array($utilisateurs))
            {
                if(sizeof($utilisateurs) > 1)
                {
                    foreach($utilisateurs as $utilisateur)
                    {
                        $parts2 = explode(";", $utilisateur);
                        echo "<li> $parts2[1]";
                    }
                }
            }else
            {
                $parts2 = explode(";", $utilisateurs);
                echo "<li> $parts2[1]";
            }

            echo "<br>";
            echo "<br>";
            echo "<a href='index.php?action=INS&id=$parts[0]' class='btn btn-primary' style='background-color: #329E9D; border: unset;'>Inscription</a>";
            ?>
    </div>
</body>

<?php
    include_once "footer.php";
?>
</html>
