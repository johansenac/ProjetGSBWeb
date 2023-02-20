<!DOCTYPE html>
<html>
<head>
    <title>GSB - Nos activités</title>
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
            <h1>Nos activités</h1>
            <p>Vous retrouverez ici les activités que nous proposons. Cliquez sur l'une d'elle pour plus de détails et pour pouvoir vous y inscrire.</p>
            <br>
            <div class="row">
            <?php
                foreach ($activites as $activite)
                {
                    $parts = explode(";", $activite);
                    echo "<div class='card' style='width: 18rem; border: unset;'><img class='card-img-top' src='assets/activites/$parts[0].jpg' width='150' height='200' style='border-bottom: 1px solid lightgray;'><div class='card-body'><h5 class='card-title'><b>$parts[1]</b></h5><p class='card-text'>$parts[2]</p><a href='index.php?action=ACT&id=$parts[0]' class='btn btn-primary' style='background-color: #329E9D; border: unset;'>Plus de détails</a></div></div>";
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
