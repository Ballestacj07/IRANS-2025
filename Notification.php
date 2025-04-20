<?php
session_start();
$studentNo = $_SESSION['student_no']; // Assuming the user is logged in and the student number is stored in the session

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "cdmirans";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Fetch notifications for the logged-in user based on their student number
$sql = "SELECT n.message, n.created_at 
        FROM notifications n 
        JOIN inci_reports r ON n.report_id = r.id 
        WHERE r.student_no = ? 
        ORDER BY n.created_at DESC"; // Fetch the notifications in descending order based on creation time

$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $studentNo);
$stmt->execute();
$result = $stmt->get_result();

$conn->close();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Notifications</title>
    <link href="css/notification.css" rel="stylesheet" />
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

    <div class="notifications-container">
        <h2>Your Notifications</h2> &nbsp;
        <?php
        if ($result->num_rows > 0) {
            echo "<ul>";
            while ($row = $result->fetch_assoc()) {
                echo "<li><strong>" . $row['message'] . "</strong><br><small>Received on: " . $row['created_at'] . "</small></li>";
            }
            echo "</ul>";
        } else {
            echo "<p>No new notifications.</p>";
        }
        ?>
    </div>
</body>
</html>