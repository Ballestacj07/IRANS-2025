<?php
session_start();

// Check if the user is logged in and student_no is in session
if (!isset($_SESSION['student_no'])) {
    // Redirect to login if the user is not logged in
    header('Location: login.php');
    exit;
}

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

// Retrieve student_no and name from session
$student_no = $_SESSION['student_no'];
$fullname = $_SESSION['fullname']; // Assuming the name is also stored in the session

// Handle form submissions based on different actions
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    if (isset($_POST['subject']) && isset($_POST['report-date']) && isset($_POST['report-time']) && isset($_POST['incident-report'])) {
        // Handling incident report submission
        $subject = $_POST['subject'];
        $reportDate = $_POST['report-date'];
        $reportTime = $_POST['report-time'];
        $incidentReport = $_POST['incident-report'];

        $fileUpload = $_FILES['file-upload'];
        $uploadDir = 'C:\xampp\htdocs\uploads\upload';
        $uploadFile = $uploadDir . basename($fileUpload['name']);

        // File upload handling
        if ($fileUpload['size'] > 0) {
            if (move_uploaded_file($fileUpload['tmp_name'], $uploadFile)) {
                // File uploaded successfully
            } else {
                echo "File upload failed.\n";
                exit();
            }
        } else {
            // If no file is uploaded, set the file path as NULL
            $uploadFile = null;
        }

        // Insert report into the database
        $sql = "INSERT INTO inci_reports (student_no, fullname, subject, report_date, report_time, incident_report, file_path) 
                VALUES (?, ?, ?, ?, ?, ?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('sssssss', $student_no, $fullname, $subject, $reportDate, $reportTime, $incidentReport, $uploadFile);

        if ($stmt->execute()) {
            header("Location: report.php?status=success");
            exit();
        } else {
            echo "Error: " . $stmt->error;
            exit();
        }
    } elseif (isset($_POST['report-id'])) {
        // Handling report deletion
        $reportId = intval($_POST['report-id']);

        if ($reportId <= 0) {
            die("Invalid report ID.");
        }

        $sql = "DELETE FROM inci_reports WHERE id = ?";
        $stmt = $conn->prepare($sql);
        if (!$stmt) {
            die("Prepare failed: " . $conn->error);
        }

        $stmt->bind_param('i', $reportId);

        if ($stmt->execute()) {
            header("Location: report.php?status=deleted");
            exit();
        } else {
            echo "Error executing query: " . $stmt->error;
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
        function logout() {
            window.location.href = 'login.php';
        }

        function validateForm(event) {
            const subject = document.getElementById('subject').value;
            const reportDate = document.getElementById('report-date').value;
            const reportTime = document.getElementById('report-time').value;
            const incidentReport = document.getElementById('incident-report').value;

            if (!subject || !reportDate || !reportTime || !incidentReport) {
                alert('Please fill out all required fields.');
                event.preventDefault(); 
                return false;
            }
            return true;
        }

        function confirmDelete() {
            return confirm('Are you sure you want to delete this report?');
        }

        function handleFormSubmit(event) {
            if (!validateForm(event)) {
                return false; 
            }
            return true;
        }

        function showSuccessMessage() {
            const urlParams = new URLSearchParams(window.location.search);
            if (urlParams.get('status') === 'success') {
                alert('Incident report submitted successfully.');
            } else if (urlParams.get('status') === 'deleted') {
                alert('Incident report deleted successfully.');
            }
        }

        window.onload = showSuccessMessage;
    </script>
</head>
<body>

    <div class="top-nav">
        <button class="nav-button" onclick="window.location.href='Home.php'">HOME</button>
        <button class="nav-button" onclick="window.location.href='report.php'">REPORT</button>
        <button class="nav-button" onclick="window.location.href='Notification.php'">NOTIFICATION</button>
        <button class="nav-button" onclick="window.location.href='send_message.php'">MESSAGE</button>
        <button class="nav-button" onclick="window.location.href='profile.php'">PROFILE</button>
        <button class="nav-button" onclick="logout()">LOG OUT</button>
    </div>

    <div class="container">
        <div class="header">
            <img src="images/logo.png" alt="Logo" class="logo">
            <h1>CDM INCIDENT REPORTS AND NOTIFICATION SYSTEM</h1>
        </div>

        <div class="form-container">
            <!-- Form for logging incident -->
            <form id="incident-form" action="report.php" method="post" enctype="multipart/form-data" onsubmit="return handleFormSubmit(event)">
                <label for="subject">Subject:</label>
                <input type="text" id="subject" name="subject" placeholder="Enter subject" required>

                <!-- Student name is pulled from session -->
                <p><strong>Student Name:</strong> <?php echo htmlspecialchars($fullname); ?></p> &nbsp;

                <!-- Student number is also generated from session -->
                <p><strong>Student Number:</strong> <?php echo htmlspecialchars($student_no); ?></p> &nbsp;

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

            <!-- Form for deleting incident -->
            <form id="delete-form" action="report.php" method="post" onsubmit="return confirmDelete()">
                <input type="hidden" id="report-id" name="report-id">
                <button type="submit" class="delete-incident">Delete Incident</button>
            </form>
        </div>

        <div class="footer">
            CDMIRANS@2024
        </div>
    </div>
</body>
</html>
