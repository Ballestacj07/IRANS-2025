<?php
session_start();

// Check if the user is logged in and student_no is in session
if (!isset($_SESSION['student_no'])) {
    header('Location: login.php');
    exit;
}

// Retrieve session variables
$student_no = $_SESSION['student_no'];
$fullname = $_SESSION['fullname'];

// Database connection details
$servername = "mysql-irans.alwaysdata.net";
$username = "irans";
$db_password = "iransdatabase@2024";
$dbname = "irans_database";

// Create the database connection
$conn = new mysqli($servername, $username, $db_password, $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Handle report submission
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    if (isset($_POST['subject'], $_POST['report-date'], $_POST['report-time'], $_POST['incident-report'], $_POST['anonymous'])) {
        // Check if the anonymous toggle is set
        $isAnonymous = $_POST['anonymous'] === 'on';
        $reportStudentNo = $isAnonymous ? 'Anonymous' : $student_no;
        $reportFullname = $isAnonymous ? 'Anonymous' : $fullname;

        $subject = $_POST['subject'];
        $reportDate = $_POST['report-date'];
        $reportTime = $_POST['report-time'];
        $incidentReport = $_POST['incident-report'];

        $fileUpload = $_FILES['file-upload'];
        $uploadDir = 'uploads/';
        $uploadFile = $uploadDir . basename($fileUpload['name']);

        if ($fileUpload['size'] > 0) {
            if (move_uploaded_file($fileUpload['tmp_name'], $uploadFile)) {
                // Success message or handling can be added here if needed
            } else {
                echo "File upload failed.\n";
                exit();
            }
        } else {
            $uploadFile = null;
        }

        $sql = "INSERT INTO inci_reports (student_no, fullname, subject, report_date, report_time, incident_report, file_path) 
                VALUES (?, ?, ?, ?, ?, ?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('sssssss', $reportStudentNo, $reportFullname, $subject, $reportDate, $reportTime, $incidentReport, $uploadFile);

        if ($stmt->execute()) {
            header("Location: report.php?status=success");
            exit();
        } else {
            echo "Error: " . $stmt->error;
            exit();
        }
    }
}

$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Report Incident</title>
    <link href="css/report.css" rel="stylesheet" />
    <script>
        function showSuccessMessage() {
            const urlParams = new URLSearchParams(window.location.search);
            if (urlParams.get('status') === 'success') {
                alert('Incident report submitted successfully.');
            }
        }

        window.onload = showSuccessMessage;

        function toggleAnonymous() {
            const toggleButton = document.getElementById('anonymous');
            const identityFields = document.querySelectorAll('.identity-field');
            identityFields.forEach(field => {
                field.style.display = toggleButton.checked ? 'none' : 'block';
            });
        }

        function toggleMenu() {
            document.getElementById("sideMenu").classList.toggle("open");
        }
    </script>
</head>
<body>

<button class="menu-toggle" onclick="toggleMenu()">☰</button>

<div class="side-menu" id="sideMenu">
    <div class="side-logo-container">
        <span class="system-title">INCIDENT REPORTS AND NOTIFICATION SYSTEM</span>
        <img src="images/logo.png" alt="Logo" class="logo">
    </div>

    <a href="Home.php">Home</a>
    <a href="report.php">Report</a>
    <a href="Notification.php">Notification</a>
    <a href="send_message.php">Message</a>
    <a href="profile.php">Profile</a>
    <a href="login.html">Log Out</a>
</div>

<div class="content">
    <div class="container">
        <div class="header">
            <h1>Report the Incident</h1>
        </div>
        <br><br>
        <div class="form-container">
    <form id="incident-form" action="report.php" method="post" enctype="multipart/form-data">
        <!-- Anonymous Toggle -->
        <div class="anonymous-container">
            <label class="switch">
                <input type="checkbox" id="anonymous" name="anonymous" onchange="toggleAnonymous()">
                <span class="slider round"></span>
            </label>
            <span class="submit-as-anonymous">Submit as Anonymous</span>
        </div>

        <!-- Student Info (Visible when not anonymous) -->
        <div class="identity-info">
            <div class="identity-field">
                <p><strong>Student Number:</strong> <?php echo htmlspecialchars($student_no); ?></p>
                <p><strong>Student Name:</strong> <?php echo htmlspecialchars($fullname); ?></p>
            </div>
        </div>

        <label for="subject">Subject:</label>
        <input type="text" id="subject" name="subject" placeholder="Enter subject" required>

        <label for="report-date">Report Date:</label>
        <input type="date" id="report-date" name="report-date" required>
        
        <label for="report-time">Report Time:</label>
        <input type="time" id="report-time" name="report-time" required>
        
        <label for="incident-report">Incident Report:</label>
        <textarea id="incident-report" name="incident-report" placeholder="Enter the details of the incident" required></textarea>
        
        <label for="file-upload">Upload Image (optional):</label>
        <input type="file" id="file-upload" name="file-upload">
        
        <div class="form-buttons">
            <button type="submit" class="log-incident">Log Incident</button>
        </div>
    </form>
</div>

        <div class="footer">IRANS@2024</div>
    </div>
</div>

</body>
</html>
