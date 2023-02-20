<!DOCTYPE html>
<html>
<head>
    <title>GSB - Accueil</title>
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
            <img src="assets/logo-gsb-c.png" width="25%" height="25%"/>
            <h1><b>Bienvenue sur le site officiel de Galaxy Swiss Bourdin!</h1></b>
            <p>Le laboratoire Galaxy Swiss Bourdin (GSB) est issu de la fusion entre le géant américain Galaxy (spécialisé dans le secteur des maladies virales dont le SIDA et les hépatites) et le conglomérat européen Swiss Bourdin (travaillant sur des médicaments plus conventionnels)</p>
            <a class="btn" href="index.php?action=MEDS" role="button">Nos médicaments</a>
            <a class="btn" href="index.php?action=ACTS" role="button">Nos activités</a>
            <br>
            <br>
            <img class="imgb" src="assets/slide1.jpg" alt="Locaux GSB">
        </center>
    </div>
</body>

<?php
    include_once "footer.php";
?>

</html>
