<!DOCTYPE html>
<html>
<head>
    <title>GSB - Nos médicaments</title>
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
        <center>
            <h1>Nos médicaments</h1>
            <p>Vous retrouverez ici la liste de tout nos médicaments. Cliquez sur l'un d'eux pour plus de détails (usages, effets et interactions).</p>
            <br>
            <div class="row">
            <?php       
                foreach ($medicaments as $medicament)
                {
                    $parts = explode(";", $medicament);
                    echo "<div class='card' style='width: 18rem; border: unset;'><img class='card-img-top' src='assets/medicaments/$parts[0].jpg' width='130' height='180' style='border-bottom: 1px solid lightgray;'><div class='card-body'><h5 class='card-title'><b>$parts[1]</b></h5><p class='card-text'>$parts[2]</p><a href='index.php?action=MED&id=$parts[0]' class='btn btn-primary' style='background-color: #329E9D; border: unset;'>Plus de détails</a></div></div>";
                }
            ?>

            </div>
            
        </center>
    </div>
</body>

<?php
    include_once "footer.php";
?>
</html>