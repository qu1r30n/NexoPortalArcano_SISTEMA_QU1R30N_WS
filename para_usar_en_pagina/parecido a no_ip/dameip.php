<?php
/*
 Los proxys van añadiendo al final de la cabecera
 las direcciones ip que van "ocultando".
  
 Para localizar la ip real del usuario se comienza 
 a mirar por el principio hasta encontrar una 
 dirección ip que no sea del rango privado.
  
 En caso de no encontrarse ninguna se toma como valor el REMOTE_ADDR
*/
if($_GET["user"]=="user" && $_GET["pass"]=="1234"){
	
	if( $_SERVER['HTTP_X_FORWARDED_FOR'] != '' ){
		$client_ip =( !empty($_SERVER['REMOTE_ADDR']) ) ? $_SERVER['REMOTE_ADDR'] : ( ( !empty($_ENV['REMOTE_ADDR']) ) ? $_ENV['REMOTE_ADDR'] :"unknown" );
		$entries = explode('[, ]', $_SERVER['HTTP_X_FORWARDED_FOR']);
		reset($entries);
		foreach ($entries as $entry){
			$entry = trim($entry);
			if ( preg_match("/^([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)/",$entry,$ip_list) ){
				$private_ip = array(
					'/^0\./',
					'/^127\.0\.0\.1/',
					'/^192\.168\..*/',
					'/^172\.(1[69]|2[0-9]|3[01])\..*/',
					'/^10\..*/');
				$found_ip = preg_replace($private_ip, $client_ip, $ip_list[1]);
				if ($client_ip != $found_ip){
					$client_ip = $found_ip;
					break;
				}
			}
		}
	}else{
		$client_ip =( !empty($_SERVER['REMOTE_ADDR']) ) ? $_SERVER['REMOTE_ADDR']:( ( !empty($_ENV['REMOTE_ADDR']) ) ? $_ENV['REMOTE_ADDR']:"unknown" );
	}
	
	// Apertura para sólo escritura; coloca el puntero al principio del fichero
	$fp = fopen('ip.txt', "w"); 
	fwrite ($fp,$client_ip); 
	fclose($fp);
}
?>
