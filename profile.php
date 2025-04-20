<?php
session_start();

if (!isset($_SESSION['student_no'])) {
    header("Location: login.php");
    exit();
}


$servername = "localhost";
$username = "root"; 
$password = "";     
$dbname = "cdmirans";


$conn = new mysqli($servername, $username, $password, $dbname);


if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$student_no = $_SESSION['student_no'];


$stmt = $conn->prepare("SELECT profile_photo FROM client_ds WHERE student_no = ?");
$stmt->bind_param("s", $student_no);
$stmt->execute();
$stmt->bind_result($profile_photo);
$stmt->fetch();
$stmt->close();
$conn->close();


if (!$profile_photo) {
    $profile_photo = 'images/avatar.png';
}
?>  

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profile</title>
    <link href="css/profile.css" rel="stylesheet" />
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



    <div class="profile-container">
        <div class="profile-header">
            <h1>Your Profile</h1>
        </div>

       
        <div class="profile-avatar">
            <img src="<?php echo $profile_photo; ?>" alt="User Avatar">
        </div>

        
        <div class="profile-details">
            <p><strong>Student No:</strong> <?php echo $_SESSION['student_no']; ?></p>
            <p><strong>Name:</strong> <?php echo $_SESSION['fullname']; ?></p>
            <p><strong>Email:</strong> <?php echo $_SESSION['email']; ?></p>
        </div>

           <div class="change-photo-container">
         <button class="change-photo" onclick="window.location.href='chgprof.php'">Change Photo</button>
     </div>
    </div>

   
    <div class="footer">
        CDMIRANS@2024
    </div>

</body>
</html>
