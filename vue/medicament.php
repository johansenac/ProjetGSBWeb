<!DOCTYPE html>
<html>
<head>
    <title>GSB - Médicament</title>
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

            $parts = explode(";", $medicament);

            echo "<h1><b>$parts[1]</b></h1>";
            echo "<br>";
            echo "<img src='assets/medicaments/$parts[0].jpg' class='imgb' width=350 height=250/>";
            echo "<br>";
            echo "<br>";
            echo "<p>$parts[2]</p>";

            echo "<p><u>Effet(s) thérapeutique(s):</u></p>";

            if(is_array($effetsThera))
            {
                if(sizeof($effetsThera) > 1)
                {
                    foreach($effetsThera as $effetThera)
                    {
                        $parts2 = explode(";", $effetThera);
                        echo "<li> $parts2[1]";
                    }
                }
            }else
            {
                $parts2 = explode(";", $effetsThera);
                echo "<li> $parts2[1]";
            }

            echo "<br><br>";
            echo "<p><u>Effet(s) secondaire(s):</u></p>";

            if(is_array($effetsSeconds))
            {
                if(sizeof($effetsSeconds) > 1)
                {
                    foreach($effetsSeconds as $effetSec)
                    {
                        $parts2 = explode(";", $effetSec);
                        echo "<li> $parts2[1]";
                    }
                }
            }else
            {
                $parts2 = explode(";", $effetsSeconds);
                echo "<li> $parts2[1]";
            }

            echo "<br><br>";
            echo "<p><u>Interaction(s) connue(s):</u></p>";

            if(is_array($interactions))
            {
                if(sizeof($interactions) > 1)
                {
                    foreach($interactions as $interaction)
                    {
                        $parts2 = explode(";", $interaction);
                        echo "<li><a href='index.php?action=MED&id=$parts2[0]'> $parts2[1]</a>";
                    }
                }
            }else
            {
                $parts2 = explode(";", $interactions);
                echo "<li><a href='index.php?action=MED&id=$parts2[0]'> $parts2[1]</a>";
            }

            ?>
    </div>
</body>

<?php
    include_once "footer.php";
?>
</html>
