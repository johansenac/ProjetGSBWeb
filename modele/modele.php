<?php

function setup()
{
    $url = 'https://localhost:44300/WebService1.asmx?WSDL';
    $options = array(
        'cache_wsd1' => 0,
        'trace' => 1,
        'stream_context' => stream_context_create(array(
            'ssl' => array(
                'verify_peer' => false,
                'verify_peer_name' => false,
                'allow_self_signed' => true
            )
            )));
    $client = new SoapClient($url, $options);
    return $client;
}


function getMedicaments()
{
    $res = setup()->SelectMedicaments();
    $medicaments = $res->selectMedicamentsResult->string;
    return $medicaments;
}

function getActivites()
{
    $res = setup()->SelectActivitesAnimateurs();
    $activites = $res->selectActivitesAnimateursResult->string;
    return $activites;
}

function getMedicament($id)
{
    $parameters = array('idMedicament' => $id);
    $res = setup()->SelectMedicament($parameters);
    $med = $res->selectMedicamentResult;
    return $med;
}

function getEffetsT($id)
{
    $parameters = array('idMedicament' => $id);
    $res = setup()->SelectEffetsTherapeutiques($parameters);
    $effetsT = $res->selectEffetsTherapeutiquesResult->string;
    return $effetsT;
}

function getEffetsS($id)
{
  $parameters = array('idMedicament' => $id);
  $res = setup()->SelectEffetsSecondaires($parameters);
  $effetsS = $res->selectEffetsSecondairesResult->string;
  return $effetsS;
}

function getRelations($id)
{
    $parameters = array('idMedicament' => $id);
    $res = setup()->SelectRelationMedicaments($parameters);
    $interactions = $res->selectRelationMedicamentsResult->string;
    return $interactions;
}

function getActivite($id)
{
  $parameters = array('idActivite' => $id);
  $res = setup()->SelectActiviteAnimateur($parameters);
  $activite = $res->selectActiviteAnimateurResult;
  return $activite;
}

function getUtilisateurs($id)
{
  $parameters = array('idActivite' => $id);
  $res = setup()->SelectUtilisateursActivite($parameters);
  $utilisateurs = $res->selectUtilisateursActiviteResult->string;
  return $utilisateurs;
}

function insertInscription($id, $prenomUser, $nomUser, $mailUser)
{
  $parameters = array('nomUser' => $nomUser,
                      'prenomUser' => $prenomUser,
                      'mailUser' => $mailUser,
                      'idActivite' => $id);
  $res = setup()->InsertActivite($parameters);
}


?>
