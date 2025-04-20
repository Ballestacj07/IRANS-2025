<?php

$servername = "localhost";
$username = "root";
$password = "";     
$dbname = "cdmirans";

$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$conn->close();

?>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profile</title>
    <link href="css/home.css" rel="stylesheet" />
</head>
<body>
<div class="top-nav">
    <div class="logo-container">
        <img src="images/logo.png" alt="Logo" class="logo">
        <span class="system-title">CDM INCIDENT REPORTS AND NOTIFICATION SYSTEM</span>
    </div>
    <div class="nav-buttons-container">
        <button class="nav-button" onclick="window.location.href='Home.php'">HOME</button>
        <button class="nav-button" onclick="window.location.href='report.php'">REPORT</button>
        <button class="nav-button" onclick="window.location.href='Notification.php'">NOTIFICATION</button>
        <button class="nav-button" onclick="window.location.href='send_message.php'">MESSAGE</button>
        <button class="nav-button" onclick="window.location.href='profile.php'">PROFILE</button>
        <button class="nav-button" onclick="window.location.href='logout.php'">LOG OUT</button>
    </div>
</div>

</body>
</html>