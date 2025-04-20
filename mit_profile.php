<?php
// Set the content type to JSON
header("Content-Type: application/json");

// Database connection
$servername = "mysql-irans.alwaysdata.net";
$username = "irans";
$password = "iransdatabase@2024";
$dbname = "irans_database";

// Get the student number from the URL or request
$student_no = $_GET['student_no'] ?? '';

if (empty($student_no)) {
    echo json_encode(["error" => "Student number not provided"]);
    exit();
}

// Create a database connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    echo json_encode(["error" => "Connection failed: " . $conn->connect_error]);
    exit();
}

// Query to get the user's profile data based on student_no
$sql = "SELECT student_no, fullname, email, phnumber FROM client_ds WHERE student_no = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $student_no);
$stmt->execute();
$result = $stmt->get_result();

if ($result->num_rows > 0) {
    $user = $result->fetch_assoc();
    echo json_encode($user); // Return user data as JSON
} else {
    echo json_encode(["error" => "User not found"]);
}

$stmt->close();
$conn->close();
?>
